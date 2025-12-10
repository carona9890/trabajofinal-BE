using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoFinalBE.Models
{
    public class Transferencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Destinatario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Concepto { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}