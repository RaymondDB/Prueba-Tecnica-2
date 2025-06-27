using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Producto>> GetProductos([Service] ProductoService service)
        {
            return await service.GetAllAsync();
        }
    }
}
