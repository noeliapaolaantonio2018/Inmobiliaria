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
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = User.Identity.Name;
                //var res = contexto.Inquilino.Select(x => new { x.Nombre, x.Apellido, x.Email }).SingleOrDefault(x => x.Email == inquilino);
                var res = contexto.Contratos.Include(x => x.Inquilinos)
                         .Include(e => e.Inmuebles.Propietarios)
                         .Where(e => e.Inmuebles.Propietarios.Email == usuarios)
                         .Select(x => x.Inquilinos).Distinct()
                         .ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<InquilinosController>/5
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


        // POST api/<InquilinosController>
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

        // PUT api/<InquilinosController>/5
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
            catch (DbUpdateConcurrencyException)
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

        // DELETE api/<InquilinosController>/5
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
