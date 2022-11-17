using Facturacion.DAL;
using Facturacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturacionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private FacturacionDBContext _context;

        public ClienteController(FacturacionDBContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                return Ok(await _context.Clientes.ToListAsync());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            try
            {
                Cliente? cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
                if (cliente != null)
                    return Ok(cliente);
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {

                var actual = _context.Clientes.Find(id);
                if (actual != null)
                {
                    actual.Nombre = cliente.Nombre;
                    actual.Apellido = cliente.Apellido;
                    actual.Direccion = cliente.Direccion;
                    actual.Telefono = cliente.Telefono;
                    actual.Email = cliente.Email;
                    actual.FechaNacimiento = cliente.FechaNacimiento;
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

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            try
            {
                var actual = _context.Clientes.Find(id);
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
