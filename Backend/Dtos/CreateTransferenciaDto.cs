using System.ComponentModel.DataAnnotations;

namespace TrabajoFinalBE.Dtos
{
    public class CreateTransferenciaDto
    {
        [Required]
        public string? Destinatario { get; set; }
        [Required]
        public decimal Monto { get; set; }
        public string? Concepto { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}