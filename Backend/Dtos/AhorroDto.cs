namespace TrabajoFinalBE.Dtos
{
    public class AhorroDto
    {
        public int Id { get; set; }
        public string? DescripcionMeta { get; set; } 
        public decimal MontoObjetivo { get; set; }
        public decimal MontoActual { get; set; }
        public bool EsActiva { get; set; }
        public int UsuarioId { get; set; }
    }
}