using System.ComponentModel.DataAnnotations;

namespace FacturasApi.Models
{
    public class Enterprise
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = null!;
        [Required, StringLength(200)]
        public string Address { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Nif { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set;} = null!;

        public HashSet<Invoice> Invoices { get; set; } = new HashSet<Invoice>();

    }
}
