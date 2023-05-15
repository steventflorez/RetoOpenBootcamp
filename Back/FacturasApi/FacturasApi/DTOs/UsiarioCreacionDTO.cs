using System.ComponentModel.DataAnnotations;

namespace FacturasApi.DTOs
{
    public class UsiarioCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 150)]
        public string Password { get; set; } = null!;

        [StringLength(maximumLength: 150)]
        public string UserName { get; set; } = null!;


    }
}
