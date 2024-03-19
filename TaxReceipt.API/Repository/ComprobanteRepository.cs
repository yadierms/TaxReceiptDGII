using Microsoft.EntityFrameworkCore;
using TaxReceipt.API.Data;
using TaxReceipt.API.Interfaces;
using TaxReceipt.API.Models;

namespace TaxReceipt.API.Repository
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        private readonly DataContext _context;
        public ComprobanteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comprobante>> GetAll()
        {
            var comprobantes = await _context.Comprobantes.ToListAsync();

            if (comprobantes == null)
            {
                return null;
            }
            return comprobantes;

        }

        public async Task<IEnumerable<Comprobante>> GetAllByRnc(long rncCedula)
        {
            var comprobantes = await _context.Comprobantes.Where(x => x.RncCedula == rncCedula).ToListAsync();

            if (comprobantes == null)
            {
                return null;
            }
            return comprobantes;
        }
    }
}
