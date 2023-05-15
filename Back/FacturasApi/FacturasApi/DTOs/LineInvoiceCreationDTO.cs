using FacturasApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FacturasApi.DTOs
{
    public class LineInvoiceCreationDTO
    {
        [Required, StringLength(150)]
        public string ProductName { get; set; } = null!;
        
        public int Quantity { get; set; }
       
        public int UnitValue { get; set; }
        
        public int Total { get; set; }
       
    }
}
