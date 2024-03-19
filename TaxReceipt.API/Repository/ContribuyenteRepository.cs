using Microsoft.EntityFrameworkCore;
using TaxReceipt.API.Data;
using TaxReceipt.API.Interfaces;
using TaxReceipt.API.Models;

namespace TaxReceipt.API.Repository
{
    public class ContribuyenteRepository : IContribuyenteRepository
    {
        private readonly DataContext _context;
        public ContribuyenteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contribuyente>> GetAll()
        {
            var contribuyentes = await _context.Contribuyentes.ToListAsync();

            if (contribuyentes == null)
            {
                return null;
            }
            return contribuyentes;
        }
    }
}
