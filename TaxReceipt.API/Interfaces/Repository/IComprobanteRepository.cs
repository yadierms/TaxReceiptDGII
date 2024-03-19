using TaxReceipt.API.Models;

namespace TaxReceipt.API.Interfaces.Repository
{
    public interface IComprobanteRepository
    {
        Task<IEnumerable<Comprobante>> GetAll();
        Task<IEnumerable<Comprobante>> GetAllByRnc(long rncCedula);

    }
}
