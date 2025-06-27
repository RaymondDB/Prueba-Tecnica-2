using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;

namespace PruebaTecnicaSignos.Application.Services
{
    public class UnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _repo;

        public UnidadMedidaService(IUnidadMedidaRepository repo) => _repo = repo;

        public Task<IEnumerable<UnidadMedida>> GetAllAsync() => _repo.GetAllAsync();

        public Task<UnidadMedida?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<UnidadMedida> AddAsync(UnidadMedida unidad) => _repo.AddAsync(unidad);

        public Task UpdateAsync(UnidadMedida unidad) => _repo.UpdateAsync(unidad);

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
