namespace TaxReceipt.API.DTOs.Comprobante
{
    public class ComprobanteDTO
    {
        public int Id { get; set; }

        public long RncCedula { get; set; }
        public string NCF { get; set; }

        public decimal Monto { get; set; }

        public decimal Itbis18
        {
            get
            {
                decimal itbis = Monto * 0.18m;
                return Math.Round(itbis, 2);
            }
        }

    }
}
