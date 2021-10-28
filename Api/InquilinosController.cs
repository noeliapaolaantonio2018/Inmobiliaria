using System;
using System.Collections.Generic;
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
    public class InquilinosController : ControllerBase
    {
        private readonly DataContext contexto;


        public InquilinosController(DataContext contexto)
        {
            this.contexto = contexto;

        }

        // GET: api/<InquilinosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquilinos>>> Get()
        {
            try
            {
                var inquilinos = await contexto.Contratos
                    .Include(contratos => contratos.Inmuebles)
                    .ThenInclude(inmuebles => inmuebles.Propietarios)
                    .Include(contratos => contratos.Inquilinos)
                    .Where(contratos => contratos.Inmuebles.Propietarios.Email == User.Identity.Name && contratos.FechaCierre <= DateTime.Now && contratos.FechaCierre >= DateTime.Now)
                    .Select(contratos => new { contratos.Inmuebles, contratos.Inquilinos })
                    .ToListAsync();

                if (inquilinos == null)
                {
                    return NotFound("No existen inquilinos");
                }

                return Ok(inquilinos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<InquilinoController>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return NotFound();
            var res = contexto.Inquilinos.FirstOrDefault(x => x.IdInq == id);

            if (res != null)
                return Ok(res);
            else
                return NotFound();


        }


        // POST api/<InquilinoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Inquilinos inquilinos)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    contexto.Inquilinos.Add(inquilinos);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = inquilinos.IdInq }, inquilinos);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<InquilinoController>/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] Inquilinos inquilinos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Inquilinos.Update(inquilinos);
                    contexto.SaveChanges();
                    return Ok(inquilinos);
                }

                return BadRequest();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        private bool InquilinoExists(int id)
        {
            return contexto.Inquilinos.Any(e => e.IdInq == id);
        }

        // DELETE api/<InquilinoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var p = contexto.Inquilinos.Find(id);
                    if (p == null)
                        return NotFound();
                    contexto.Inquilinos.Remove(p);
                    contexto.SaveChanges();
                    return Ok(p);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
