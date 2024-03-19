using TaxReceipt.API.DTOs.Contribuyente;

namespace TaxReceipt.API.Interfaces
{
    public interface IContribuyenteService

    {
        Task<IEnumerable<ContribuyenteDTO>> GetAllContribuyentes();


    }
}
