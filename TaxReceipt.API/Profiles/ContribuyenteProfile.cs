using AutoMapper;
using TaxReceipt.API.DTOs.Contribuyente;
using TaxReceipt.API.Models;

namespace TaxReceipt.API.Profiles
{
    public class ContribuyenteProfile : Profile
    {
        public ContribuyenteProfile()
        {
            CreateMap<Contribuyente, ContribuyenteDTO>();
        }
    }
}
