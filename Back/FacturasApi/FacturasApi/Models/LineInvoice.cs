using System.ComponentModel.DataAnnotations;

namespace FacturasApi.Models
{
    public class LineInvoice
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string ProductName { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int  UnitValue { get; set; }
        [Required]
        public int Total { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; } = null!;
    }
}
