using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;

namespace PruebaTecnicaSignos.Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo) => _repo = repo;

        public Task<IEnumerable<Producto>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Producto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Producto> AddAsync(Producto producto) => _repo.AddAsync(producto);
        public Task UpdateAsync(Producto producto) => _repo.UpdateAsync(producto);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
