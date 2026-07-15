using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistem_supplier.DLL.services;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DTO;
using sistem_supplier.API.Utilidad;

namespace sistem_supplier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioProveedorController : ControllerBase
    {
        private readonly IServicioProveedorRepository _ServicioProveedorReposirory;

        public ServicioProveedorController(IServicioProveedorRepository servicioProveedorReposirory)
        {
            _ServicioProveedorReposirory = servicioProveedorReposirory;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Utilidad.Response<List<ServicioProveedorDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _ServicioProveedorReposirory.Lista();
            }

            catch (Exception ex)
            {
                rsp.Msg = ex.Message;
            }

            return Ok(rsp);

        }

    }
}
