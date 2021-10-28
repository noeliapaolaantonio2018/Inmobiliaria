using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly DataContext contexto;

        public PagoController(DataContext contexto)
        {
            this.contexto = contexto;
        }
        // GET: api/<PagosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagos>>> GetPagos()
        {
            try
            {
                var pago = await contexto.Pagos
                .Include(pagos => pagos.Contratos)
                .Include(pagos => pagos.Contratos.Inmuebles)
                .Where(pagos => pagos.Contratos.Inmuebles.Propietarios.Email == User.Identity.Name && pagos.Contratos.FechaInicio <= DateTime.Now && pagos.Contratos.FechaCierre >= DateTime.Now)
                .ToListAsync();
                if (pago == null)
                {
                    return NotFound("No se registraron pagos");
                }

                return Ok(pago);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<PagoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                var res = contexto.Pagos.Include(e => e.Contratos)
                                       .Where(e => e.Contratos.Inmuebles.Propietarios.Email == usuario && e.IdContr == id)
                                       .Select(x => new { x.NumPago, x.FechaPago, x.Importe });
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<PagoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Pagos pagos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = User.Identity.Name;
                    pagos.IdContr = contexto.Contratos.FirstOrDefault(e => e.Inmuebles.Propietarios.Email == User.Identity.Name).IdContr;
                    contexto.Pagos.Add(pagos);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = pagos.IdPago }, pagos);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<PagoController>/4
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] Pagos pagos)
        {
            try
            {
                if (ModelState.IsValid && contexto.Pagos.AsNoTracking().Include(e => e.Contratos.Inmuebles).ThenInclude(x => x.Propietarios).FirstOrDefault(e => e.IdPago == id && e.Contratos.Inmuebles.Propietarios.Email == User.Identity.Name) != null)
                {

                    pagos.IdPago = id;
                    contexto.Pagos.Update(pagos);
                    contexto.SaveChanges();
                    return Ok(pagos);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
