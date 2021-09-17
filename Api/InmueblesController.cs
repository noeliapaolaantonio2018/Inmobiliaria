using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InmueblesController : Controller
    {
        private readonly DataContext contexto;

        public InmueblesController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<InmueblesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = User.Identity.Name;
                var res= contexto.Inmuebles.Include(e => e.Propietarios).Where(e => e.Propietarios.Email == usuarios);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<InmueblesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuarios = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Propietarios).Where(e => e.Propietarios.Email == usuarios).Single(e => e.IdInm == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<InmueblesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]Inmuebles entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entidad.IdProp = contexto.Propietarios.Single(e => e.Email == User.Identity.Name).IdProp;
                    contexto.Inmuebles.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.IdInm }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<InmueblesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inmuebles entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Inmuebles.AsNoTracking().Include(e => e.Propietarios).FirstOrDefault(e => e.IdProp == id && e.Propietarios.Email == User.Identity.Name) != null) 
                {
                    entidad.IdProp = id;
                    contexto.Inmuebles.Update(entidad);
                    contexto.SaveChanges();
                    return Ok(entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<InmueblesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entidad = contexto.Inmuebles.Include(e => e.Propietarios).FirstOrDefault(e => e.IdProp == id && e.Propietarios.Email == User.Identity.Name);
                if (entidad != null)
                {
                    contexto.Inmuebles.Remove(entidad);
                    contexto.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        // GET api/<InmueblesController>/disponibles
        [HttpGet("disponibles")]
        public async Task<IActionResult> InmueblesDisponibles()
        {
            try
            {
                var usuarios = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Propietarios).Where(e => e.Propietarios.Email == usuarios && e.Disponible).ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}