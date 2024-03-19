using AutoMapper;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Interfaces.Repository;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.API.Service
{
    public class ComprobanteService : IComprobanteService
    {
        private readonly IContribuyenteRepository _contribuyenteRepositroy;
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IMapper _mapper;
        public ComprobanteService(IComprobanteRepository comprobanteRepository, IMapper mapper, IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepositroy = contribuyenteRepository;
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
            var contribuyente = await _contribuyenteRepositroy.GetByRnc(rncCedula);

            if (contribuyente == null)
            {
                throw new Exception($"No se encontró un contribuyente con el RNC/Cédula {rncCedula}");
            }

            var comprobantes = await _comprobanteRepository.GetAllByRnc(rncCedula);

            return comprobantes.Select(b => _mapper.Map<ComprobanteDTO>(b));
        }
    }
}
