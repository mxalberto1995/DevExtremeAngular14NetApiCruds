using Facturacion.DAL;
using Facturacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturacionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private FacturacionDBContext _context;

        public ProductoController(FacturacionDBContext context)
        {
            _context = context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            try
            {
                return Ok(await _context.Productos.ToListAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            try
            {
                Producto? producto = await _context.Productos.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (producto != null)
                    return Ok(producto);
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(int id, [FromBody] Producto producto)
        {
            try
            {

                var actual = _context.Productos.Find(id);
                if (actual != null)
                {
                    actual.Nombre = producto.Nombre;
                    actual.PrecioUnitario = producto.PrecioUnitario;
                    actual.CantidadExistencia = producto.CantidadExistencia;
                    actual.CategoriaId = producto.CategoriaId;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            try
            {
                var actual = _context.Productos.Find(id);
                if (actual != null)
                {
                    _context.Remove(actual);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
