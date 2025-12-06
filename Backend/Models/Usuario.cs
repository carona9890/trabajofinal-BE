using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TrabajoFinalBE.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Ahorro> Ahorros { get; set; }
        public List<Transferencia> Transferencias { get; set; }
    }
}