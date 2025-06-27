using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSignos.Application.Services;
using PruebaTecnicaSignos.Domain.Entities;

namespace PruebaTecnicaSignos.ProductosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly UnidadMedidaService _service;

        public UnidadesMedidaController(UnidadMedidaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var unidad = await _service.GetByIdAsync(id);
            return unidad is null ? NotFound() : Ok(unidad);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnidadMedida unidad)
        {
            var created = await _service.AddAsync(unidad);
            return CreatedAtAction(nameof(GetById), new { id = created.UnidadId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UnidadMedida unidad)
        {
            if (id != unidad.UnidadId) return BadRequest();
            await _service.UpdateAsync(unidad);
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
