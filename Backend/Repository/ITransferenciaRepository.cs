using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoFinalBE.Models;

namespace TrabajoFinalBE.Repository
{
    public interface ITransferenciaRepository
    {
        Task<ICollection<Transferencia>> GetTransferenciasAsync();
        Task<Transferencia> GetTransferenciaAsync(int id);
        Task<bool> CrearTransferenciaAsync(Transferencia transferencia);
        Task<bool> GuardarAsync();
    }
}