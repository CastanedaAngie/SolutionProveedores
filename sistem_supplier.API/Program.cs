using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using sistem_supplier.DAL.DContext;
using sistem_supplier.DLL.services;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.IOC;
using Microsoft.AspNetCore.Builder;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddDbContext<TekusDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.InyectarDependencias(builder.Configuration);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");



builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        //app.WithOrigins(
        //    "https://providers.visualcodevelopment.com/",
        //    "http://providers.visualcodevelopment.com/"
        //);
        app.AllowAnyOrigin();
        app.AllowAnyHeader();
        app.AllowAnyMethod();
        // app.AllowCredentials();
    });

});
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseCors("NuevaPolitica");

var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Providers API v1");
    c.RoutePrefix = "swagger"; // URL: /swagger
});

// Redirección al swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();