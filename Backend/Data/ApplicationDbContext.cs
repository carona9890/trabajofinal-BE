using Microsoft.EntityFrameworkCore;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ahorro> Ahorros { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Ahorros)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Transferencias)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}