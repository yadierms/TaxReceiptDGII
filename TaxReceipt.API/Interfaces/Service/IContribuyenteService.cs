using TaxReceipt.API.DTOs.Contribuyente;

namespace TaxReceipt.API.Interfaces.Service
{
    public interface IContribuyenteService

    {
        Task<IEnumerable<ContribuyenteDTO>> GetAllContribuyentes();


    }
}
