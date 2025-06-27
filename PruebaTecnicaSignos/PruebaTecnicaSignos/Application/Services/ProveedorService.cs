using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;

namespace PruebaTecnicaSignos.Application.Services
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _repo;

        public ProveedorService(IProveedorRepository repo) => _repo = repo;

        public Task<IEnumerable<Proveedor>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Proveedor?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<Proveedor> AddAsync(Proveedor proveedor) => _repo.AddAsync(proveedor);

        public Task UpdateAsync(Proveedor proveedor) => _repo.UpdateAsync(proveedor);

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
