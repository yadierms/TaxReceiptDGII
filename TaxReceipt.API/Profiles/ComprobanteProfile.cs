using AutoMapper;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Models;

namespace TaxReceipt.API.Profiles
{
    public class ComprobanteProfile : Profile
    {
        public ComprobanteProfile()
        {
            CreateMap<Comprobante, ComprobanteDTO>();

        }
    }
}
