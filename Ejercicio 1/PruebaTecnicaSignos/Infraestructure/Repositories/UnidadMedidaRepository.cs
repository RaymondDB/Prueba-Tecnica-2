using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSignos.Domain.Entities;
using PruebaTecnicaSignos.Domain.Interfaces;
using PruebaTecnicaSignos.Infraestructure.Data;

namespace PruebaTecnicaSignos.Infraestructure.Repositories
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly ApplicationDbContext _context;

        public UnidadMedidaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UnidadMedida>> GetAllAsync()
        {
            return await _context.UnidadesMedida.ToListAsync();
        }

        public async Task<UnidadMedida?> GetByIdAsync(int id)
        {
            return await _context.UnidadesMedida.FindAsync(id);
        }

        public async Task<UnidadMedida> AddAsync(UnidadMedida unidad)
        {
            _context.UnidadesMedida.Add(unidad);
            await _context.SaveChangesAsync();
            return unidad;
        }

        public async Task UpdateAsync(UnidadMedida unidad)
        {
            _context.Entry(unidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unidad = await _context.UnidadesMedida.FindAsync(id);
            if (unidad != null)
            {
                _context.UnidadesMedida.Remove(unidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}
