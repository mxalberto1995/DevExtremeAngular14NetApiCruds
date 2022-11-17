using Facturacion.DAL;
using Facturacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturacionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private FacturacionDBContext _context;

        public CategoriaController(FacturacionDBContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                return Ok(await _context.Categorias.ToListAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            try
            {
                Categoria? categoria = await _context.Categorias.Where(c => c.Id == id).FirstOrDefaultAsync();
                if (categoria != null)
                    return Ok(categoria);
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                var actual = _context.Categorias.Find(id);
                if (actual != null)
                {
                    actual.NombreCategoria = categoria.NombreCategoria;
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

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            try
            {
                var actual = _context.Categorias.Find(id);
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
