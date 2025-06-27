using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;

namespace PruebaTecnicaSignos.Application.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repo;
        public CategoriaService(ICategoriaRepository repo) => _repo = repo;

        public Task<IEnumerable<Categoria>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Categoria?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Categoria> AddAsync(Categoria categoria) => _repo.AddAsync(categoria);
        public Task UpdateAsync(Categoria categoria) => _repo.UpdateAsync(categoria);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
