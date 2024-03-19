using System.ComponentModel.DataAnnotations;

namespace TaxReceipt.API.Models
{

    public class Contribuyente
    {
        [Key]
        public long RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estatus { get; set; }


        public List<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
    }
}
