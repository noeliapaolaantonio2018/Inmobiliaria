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
    public class ContratosController : ControllerBase
    {
        private readonly DataContext contexto;

        public ContratosController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ContratosController>
        [HttpGet("inmueblesConContrato")]
        public async Task<ActionResult> InmueblesConContrato()
        {

            try
            {

                var usuario = User.Identity.Name;
                var contratosVigentes = contexto.Contratos

              .Include(x => x.Inquilinos)
              .Include(x => x.Inmuebles)
              .Where(c => c.Inmuebles.Propietarios.Email == usuario).ToList();
                // .ThenInclude(x => x.Propietarios)


                return Ok(contratosVigentes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<controller>/5
        [HttpGet("obtenerPorId/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                var contratoPorId = contexto.Contratos
                .Include(x => x.Inquilinos)
                .Include(x => x.Inmuebles)
                .Where(c => c.Inmuebles.Propietarios.Email == usuario)
                .Single(e => e.IdInm == id);

                return Ok(contratoPorId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // GET: api/<Contratos>
        [HttpGet("inmueble/{id}")]
        public async Task<ActionResult<IEnumerable<Contratos>>> GetContratosPorInmuebles(int id)
        {

            try
            {

                var contratos = await contexto.Contratos
                    .Include(cont => cont.Inmuebles)
                    .Include(cont => cont.Inquilinos)
                    .Include(cont => cont.Inmuebles.Propietarios)
                    .Where(cont => cont.IdInm == id && cont.Inmuebles.Propietarios.Email == User.Identity.Name)
                    .FirstOrDefaultAsync();


                if (contratos.FechaCierre < DateTime.Now)
                {
                    contratos.Vigente = false;
                }
                else if (contratos == null || contratos.Inmuebles.Propietarios.Email != User.Identity.Name)
                {

                    return NotFound("No existen Contratos Vigentes");

                }
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // GET api/<ContratosController>/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Contratos>> GetContratos(int id)
        {
            var contratos = await contexto.Contratos.FindAsync(id);

            if (contratos == null)
            {
                return NotFound();
            }
            return contratos;
        }

        // POST api/<ContratosController>
        [HttpPost]
        public async Task<ActionResult<Contratos>> Get(int id)
        {
            var contrato = await contexto.Contratos.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }
            return contrato;
        }


        // PUT api/<ContratosController>/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Contratos contratos)
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


        // DELETE api/<ContratoController>/5
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
