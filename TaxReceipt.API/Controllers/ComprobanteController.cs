using Microsoft.AspNetCore.Mvc;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteService _comprobanteService;

        private readonly ILogger<ComprobanteController> _logger;

        public ComprobanteController(IComprobanteService comprobanteService, ILogger<ComprobanteController> logger)
        {
            _comprobanteService = comprobanteService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprobanteDTO>>> GetAllComprobantes()
        {

            try
            {
                return Ok(await _comprobanteService.GetAllComprobantes());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los comprobantes"); // Registra el error en la consola
                return StatusCode(500, "Ocurrió un error al obtener todos los comprobantes");
            };
        }
        [HttpGet("{rncCedula}")]
        public async Task<ActionResult<IEnumerable<ComprobanteDTO>>> GetAllComprobantesByRnc(long rncCedula)
        {

            try
            {
                return Ok(await _comprobanteService.GetAllComprobantesByRnc(rncCedula));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener comprobantes por RNC/Cédula: {rncCedula}"); // Registra el error en la consola
                return StatusCode(500, $"Ocurrió un error al obtener comprobantes por RNC/Cédula: {rncCedula}");
            }
        }
    }
}
