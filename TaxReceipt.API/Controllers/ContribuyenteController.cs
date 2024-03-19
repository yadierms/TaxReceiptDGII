using Microsoft.AspNetCore.Mvc;
using TaxReceipt.API.DTOs.Contribuyente;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteService _contribuyenteService;
        private readonly ILogger<ContribuyenteController> _logger;

        public ContribuyenteController(IContribuyenteService contribuyenteService, ILogger<ContribuyenteController> logger)
        {
            _contribuyenteService = contribuyenteService;
            _logger = logger;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContribuyenteDTO>>> GetAllContribuyentes()
        {

            try
            {
                var contribuyentes = await _contribuyenteService.GetAllContribuyentes();
                return Ok(contribuyentes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al obtener a los contribuyentes..");

                return StatusCode(500, "Se produjo un error al obtener a los contribuyentes..");
            }
        }


    }
}
