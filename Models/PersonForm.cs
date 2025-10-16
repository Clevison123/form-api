using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // <--- necessário

namespace FormAPI.Models
{
    [Table("FormDb")] // <-- aqui diz ao EF o nome da tabela real
    public class PersonForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string? Phone { get; set; }

        [Range(0, 120)]
        public int? Age { get; set; }

        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
