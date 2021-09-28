using System;

using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly DataContext contexto;

        public ContratosController(DataContext contexto)
        {
            this.contexto = contexto;
        }
        // GET: api/<ContratosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var usuarios = User.Identity.Name;
                var res = contexto.Contratos.Include(x => x.Inquilinos).Include(x => x.Inmuebles).ThenInclude(x => x.Propietarios).Where(c => c.Inmuebles.Propietarios.Email == usuarios);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // GET api/<ContratosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuarios = User.Identity.Name;
                var res = contexto.Contratos.Include(x => x.Inquilinos)
                    .Include(x => x.Inmuebles)
                    .ThenInclude(x => x.Propietarios)
                    .Where(c => c.Inmuebles.Propietarios.Email == usuarios)
                    .Single(e => e.IdContr == id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ContratosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Contratos contratos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contratos.IdInm = contexto.Inmuebles.FirstOrDefault(e => e.Propietarios.Email == User.Identity.Name).IdInm;
                    contratos.IdInq = contexto.Inquilinos.Single(e => e.IdInq == contratos.IdInq).IdInq;
                    contexto.Contratos.Add(contratos);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = contratos.IdContr }, contratos);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // GET api/<ContratosController>/3
        [HttpGet("inmueble/{IdInmueble}")]
        public async Task<ActionResult<Contratos>> GetObtenerTodosPorInm(int IdInm)
        {
            try
            {

                var list = await contexto.Contratos.Include(e => e.Inquilinos).Include(e => e.Inmuebles).Where(e => e.IdInm == IdInm).ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<ContratosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] Contratos contratos)
        {
            try
            {
                if (ModelState.IsValid && contexto.Contratos.AsNoTracking().Include(e => e.Inmuebles).ThenInclude(x => x.Propietarios).FirstOrDefault(e => e.IdInm == id && e.Inmuebles.Propietarios.Email == User.Identity.Name) != null)
                {

                    contratos.IdContr = id;
                    contexto.Contratos.Update(contratos);
                    contexto.SaveChanges();
                    return Ok(contratos);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        // DELETE api/<ContratosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contratos = await contexto.Contratos.FindAsync(id);
            if (contratos == null)
            {
                return NotFound();
            }

            contexto.Contratos.Remove(contratos);
            await contexto.SaveChangesAsync();

            return (IActionResult)contratos;
        }

        public async Task<IActionResult> GetPropietariosVigentes()
        {

            return Ok();
        }

    }
}
