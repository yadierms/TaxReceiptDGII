using TaxReceipt.API.Models;

namespace TaxReceipt.API.Interfaces.Repository
{
    public interface IContribuyenteRepository
    {
        Task<IEnumerable<Contribuyente>> GetAll();
        Task<Contribuyente> GetByRnc(long rncCedula);
    }
}
