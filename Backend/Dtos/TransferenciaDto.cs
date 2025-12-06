using System;

namespace TrabajoFinalBE.Dtos
{
    public class TransferenciaDto
    {
        public int Id { get; set; }
        public string Destinatario { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int UsuarioId { get; set; }
    }
}