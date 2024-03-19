using Microsoft.EntityFrameworkCore;
using TaxReceipt.API.Models;

namespace TaxReceipt.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contribuyente> Contribuyentes => Set<Contribuyente>();
        public DbSet<Comprobante> Comprobantes => Set<Comprobante>();



    }
}
