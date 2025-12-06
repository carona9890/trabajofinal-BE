using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoFinalBE.Data;
using TrabajoFinalBE.Models;
using TrabajoFinalBE.Repository;

namespace TrabajoFinalBE.Repository
{
    public class AhorroRepository : IAhorroRepository
    {
        private readonly ApplicationDbContext _db;

        public AhorroRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ActualizarAhorroAsync(Ahorro ahorro)
        {
            _db.Ahorros.Update(ahorro);
            return await GuardarAsync();
        }

        public async Task<bool> BorrarAhorroAsync(Ahorro ahorro)
        {
            _db.Ahorros.Remove(ahorro);
            return await GuardarAsync();
        }

        public async Task<bool> CrearAhorroAsync(Ahorro ahorro)
        {
            await _db.Ahorros.AddAsync(ahorro);
            return await GuardarAsync();
        }

        public async Task<bool> ExisteAhorroAsync(int id)
        {
            return await _db.Ahorros.AnyAsync(a => a.Id == id);
        }

        public async Task<Ahorro> GetAhorroAsync(int id)
        {
            return await _db.Ahorros.Include(u => u.Usuario).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ICollection<Ahorro>> GetAhorrosAsync()
        {
            return await _db.Ahorros.Include(u => u.Usuario).ToListAsync();
        }

        public async Task<bool> GuardarAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}