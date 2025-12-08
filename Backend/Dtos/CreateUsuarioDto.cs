using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalBE.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}