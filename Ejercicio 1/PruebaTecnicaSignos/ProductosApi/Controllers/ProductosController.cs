using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;
        public ProductosController(ProductoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _service.GetByIdAsync(id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var p = await _service.AddAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = p.ProductoId }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            if (id != producto.ProductoId) return BadRequest();
            await _service.UpdateAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
