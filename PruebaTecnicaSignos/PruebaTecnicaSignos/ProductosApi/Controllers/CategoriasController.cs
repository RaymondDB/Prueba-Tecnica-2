using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriasController(CategoriaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _service.GetByIdAsync(id);
            return cat is null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            var cat = await _service.AddAsync(categoria);
            return CreatedAtAction(nameof(GetById), new { id = cat.CategoriaId }, cat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId) return BadRequest();
            await _service.UpdateAsync(categoria);
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
