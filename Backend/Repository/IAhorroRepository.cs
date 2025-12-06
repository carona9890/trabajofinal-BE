using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Repository
{
    public interface IAhorroRepository
    {
        Task<ICollection<Ahorro>> GetAhorrosAsync();
        Task<Ahorro> GetAhorroAsync(int id);
        Task<bool> ExisteAhorroAsync(int id);
        Task<bool> CrearAhorroAsync(Ahorro ahorro);
        Task<bool> ActualizarAhorroAsync(Ahorro ahorro);
        Task<bool> BorrarAhorroAsync(Ahorro ahorro);
        Task<bool> GuardarAsync();
    }
}