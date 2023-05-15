using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations;

namespace FacturasApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required, StringLength(150)]
        public string UserName { get; set; } = null!;
       
    }
}
