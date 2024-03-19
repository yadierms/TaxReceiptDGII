using AutoMapper;
using TaxReceipt.API.DTOs.Contribuyente;
using TaxReceipt.API.Interfaces.Repository;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.API.Service
{
    public class ContribuyenteService : IContribuyenteService
    {
        private readonly IContribuyenteRepository _contribuyenteRepositroy;
        private readonly IMapper _mapper;

        public ContribuyenteService(IContribuyenteRepository contribuyenteRepository, IMapper mapper)
        {
            _contribuyenteRepositroy = contribuyenteRepository;
            _mapper = mapper;

        }


        public async Task<IEnumerable<ContribuyenteDTO>> GetAllContribuyentes()
        {
            var contribuyentes = await _contribuyenteRepositroy.GetAll();

            return contribuyentes.Select(b => _mapper.Map<ContribuyenteDTO>(b));
        }
    }
}
