using AutoMapper;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Interfaces;

namespace TaxReceipt.API.Service
{
    public class ComprobanteService : IComprobanteService
    {
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IMapper _mapper;
        public ComprobanteService(IComprobanteRepository comprobanteRepository, IMapper mapper)
        {
            _comprobanteRepository = comprobanteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ComprobanteDTO>> GetAllComprobantes()
        {
            var comprobantes = await _comprobanteRepository.GetAll();

            return comprobantes.Select(b => _mapper.Map<ComprobanteDTO>(b));
        }

        public async Task<IEnumerable<ComprobanteDTO>> GetAllComprobantesByRnc(long rncCedula)
        {
            var comprobantes = await _comprobanteRepository.GetAllByRnc(rncCedula);

            return comprobantes.Select(b => _mapper.Map<ComprobanteDTO>(b));
        }
    }
}
