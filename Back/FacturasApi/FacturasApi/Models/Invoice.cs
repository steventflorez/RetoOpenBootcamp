using System.ComponentModel.DataAnnotations;

namespace FacturasApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public int InvoiceNumber { get; set; }
        [Required]
        public int Tax { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int SubTotal { get; set; }

        [Required]
        public int Total { get; set; }
        public int EnterpriseId { get; set; }

        public Enterprise Enterprise { get; set; } = null!;

        public HashSet<LineInvoice> LineInvoices { get; set; } = new HashSet<LineInvoice>();



    }
}
