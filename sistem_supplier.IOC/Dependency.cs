using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using sistem_supplier.DAL.DContext;
using sistem_supplier.DAL.Repository.Interfaces;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DLL.services;
using sistem_supplier.DAL.Repository;
using sistem_supplier.UTILITY;


namespace sistem_supplier.IOC
{
    public static class Dependency
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TekusDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            services.AddScoped<IServicioRepository, ServicioRepository>();

            services.AddScoped<IServicioProveedorRepository, ServicioProveedorRepository>();

            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<DbContext,TekusDbContext>();

        }
    }
}
