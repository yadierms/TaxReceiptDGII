using Microsoft.AspNetCore.Mvc;
using TaxReceipt.API.DTOs.Contribuyente;
using TaxReceipt.API.Interfaces;

namespace TaxReceipt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteService _contribuyenteService;

        public ContribuyenteController(IContribuyenteService contribuyenteService)
        {
            _contribuyenteService = contribuyenteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContribuyenteDTO>>> GetAllContribuyentes()
        {

            return Ok(await _contribuyenteService.GetAllContribuyentes());
        }


    }
}
