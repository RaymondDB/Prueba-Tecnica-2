using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ProveedorService _service;

        public ProveedoresController(ProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            return proveedor is null ? NotFound() : Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            var created = await _service.AddAsync(proveedor);
            return CreatedAtAction(nameof(GetById), new { id = created.ProveedorId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Proveedor proveedor)
        {
            if (id != proveedor.ProveedorId) return BadRequest();
            await _service.UpdateAsync(proveedor);
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
