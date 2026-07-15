using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistem_supplier.DLL.services.conexion;

namespace sistem_supplier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;


        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var paises = await _paisRepository.GetAllPais();

            return Ok(paises);
        }
    }
}
