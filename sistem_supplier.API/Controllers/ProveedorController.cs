using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistem_supplier._Models.Models;
using sistem_supplier.API.Utilidad;
using sistem_supplier.DLL.services;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DTO;

namespace sistem_supplier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Utilidad.Response<List<ProveedorDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _proveedorRepository.Lista();
            }

            catch (Exception ex)
            {
                rsp.Msg = ex.Message;
            }
      
            return Ok(rsp);

        }
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Create([FromBody] ProveedorDTO estado)
        {
            var rsp = new Utilidad.Response<ProveedorDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _proveedorRepository.Create(estado);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] ProveedorDTO estado)
        {
            var rsp = new Utilidad.Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _proveedorRepository.Update(estado);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            
            return Ok(rsp);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rsp = new Utilidad.Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _proveedorRepository.Delete(id);
            }

            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            
            return Ok(rsp);
        }
    }
}
