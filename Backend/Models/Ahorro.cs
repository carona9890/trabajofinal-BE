using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalBE.Models
{
    public class Ahorro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? DescripcionMeta { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoObjetivo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoActual { get; set; }
        public bool EsActiva { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}