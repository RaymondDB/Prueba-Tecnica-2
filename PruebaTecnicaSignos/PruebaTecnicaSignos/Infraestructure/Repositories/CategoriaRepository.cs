using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;
using PruebaTecnicaSignos.Infraestructure.Data;

namespace PruebaTecnicaSignos.Infraestructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Categoria>> GetAllAsync() => await _context.Categorias.ToListAsync();
        public async Task<Categoria?> GetByIdAsync(int id) => await _context.Categorias.FindAsync(id);

        public async Task<Categoria> AddAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cat = await _context.Categorias.FindAsync(id);
            if (cat != null)
            {
                _context.Categorias.Remove(cat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
