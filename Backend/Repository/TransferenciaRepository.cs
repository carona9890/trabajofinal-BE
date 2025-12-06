using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoFinalBE.Data;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly ApplicationDbContext _db;

        public TransferenciaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CrearTransferenciaAsync(Transferencia transferencia)
        {
            transferencia.Fecha = System.DateTime.Now;
            await _db.Transferencias.AddAsync(transferencia);
            return await GuardarAsync();
        }

        public async Task<Transferencia> GetTransferenciaAsync(int id)
        {
            return await _db.Transferencias.Include(u => u.Usuario).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ICollection<Transferencia>> GetTransferenciasAsync()
        {
            return await _db.Transferencias.OrderByDescending(t => t.Fecha).ToListAsync();
        }

        public async Task<bool> GuardarAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}