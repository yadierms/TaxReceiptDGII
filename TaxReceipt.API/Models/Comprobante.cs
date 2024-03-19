using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxReceipt.API.Models
{
    public class Comprobante
    {
        [Key]
        public int Id { get; set; }
        public long RncCedula { get; set; }
        public string NCF { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [NotMapped]
        public decimal Itbis18
        {
            get
            {
                return Monto * 0.18m;
            }
        }
        [ForeignKey("RncCedula")]
        public Contribuyente Contribuyente { get; set; }

    }
}
