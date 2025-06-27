using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.Domain.Interfaces
{
    public interface IUnidadMedidaRepository
    {
        Task<IEnumerable<UnidadMedida>> GetAllAsync();
        Task<UnidadMedida?> GetByIdAsync(int id);
        Task<UnidadMedida> AddAsync(UnidadMedida unidad);
        Task UpdateAsync(UnidadMedida unidad);
        Task DeleteAsync(int id);
    }
}
