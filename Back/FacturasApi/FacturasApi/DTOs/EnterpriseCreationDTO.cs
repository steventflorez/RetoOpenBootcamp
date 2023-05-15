using System.ComponentModel.DataAnnotations;

namespace FacturasApi.DTOs
{
    public class EnterpriseCreationDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 150)]
        public string Address { get; set; } = null!;

        [ EmailAddress]
        public string Email { get; set; } = null!;
        public string Nif { get; set; } = null!;

        public List<int> Invoice { get; set; } = new List<int>();

    }
}
