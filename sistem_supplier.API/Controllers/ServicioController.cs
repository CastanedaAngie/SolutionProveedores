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
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }
        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ServicioDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioRepository.Lista();
            }

            catch (Exception ex)
            {
                rsp.Msg = ex.Message;
            }

            return Ok(rsp);

        }
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Create([FromBody] ServicioDTO estado)
        {
            var rsp = new Response<ServicioDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioRepository.Create(estado);
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
        public async Task<IActionResult> Update([FromBody] ServicioDTO estado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioRepository.Update(estado);
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
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _servicioRepository.Delete(id);
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
