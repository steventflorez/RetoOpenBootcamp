using System.ComponentModel.DataAnnotations;

namespace FacturasApi.DTOs
{
    public class InvoiseCreationDTO
    {
        public int InvoiceNumber { get; set; }
        
        public int Tax { get; set; }
        
        
        public DateTime Date { get; set; }
       
        public int SubTotal { get; set; }

       
        public int Total { get; set; }

        public List<int> LineInvoice { get; set; } = new List<int>();

    }
}
