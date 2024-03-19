using TaxReceipt.API.DTOs.Comprobante;

namespace TaxReceipt.API.Interfaces
{
    public interface IComprobanteService
    {

        Task<IEnumerable<ComprobanteDTO>> GetAllComprobantes();
        Task<IEnumerable<ComprobanteDTO>> GetAllComprobantesByRnc(long rncCedula);
    }
}
