using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalBE.Dtos
{
    public class CreateAhorroDto
    {
        [Required]
        public string DescripcionMeta { get; set; }
        [Required]
        public decimal MontoObjetivo { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}