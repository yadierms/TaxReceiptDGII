using Microsoft.AspNetCore.Mvc;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Interfaces;

namespace TaxReceipt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteService _comprobanteService;

        public ComprobanteController(IComprobanteService comprobanteService)
        {
            _comprobanteService = comprobanteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprobanteDTO>>> GetAllComprobantes()
        {

            return Ok(await _comprobanteService.GetAllComprobantes());
        }
        [HttpGet("{rncCedula}")]
        public async Task<ActionResult<IEnumerable<ComprobanteDTO>>> GetAllComprobantesByRnc(long rncCedula)
        {

            return Ok(await _comprobanteService.GetAllComprobantesByRnc(rncCedula));
        }
    }
}
