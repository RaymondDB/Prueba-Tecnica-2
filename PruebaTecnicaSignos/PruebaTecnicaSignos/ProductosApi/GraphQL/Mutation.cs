using PruebaTecnicaSignos.Application.DTOs;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.GraphQL
{
    public class Mutation
    {
        public async Task<Producto> CreateProducto(
            CreateProductoInput input,
            [Service] ProductoService service)
        {
            var producto = new Producto
            {
                Nombre = input.Nombre,
                Precio = input.Precio,
                Stock = input.Stock,
                CategoriaId = input.CategoriaId,
                ProveedorId = input.ProveedorId,
                UnidadId = input.UnidadId
            };

            return await service.AddAsync(producto);
        }
    }
}
