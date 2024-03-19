using TaxReceipt.API.Models;

namespace TaxReceipt.API.Interfaces
{
    public interface IContribuyenteRepository
    {
        Task<IEnumerable<Contribuyente>> GetAll();
    }
}
