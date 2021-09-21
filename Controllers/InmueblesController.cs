using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;


namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioPropietarios repositorioPropietarios;
        private readonly RepositorioInmuebles repositorioInmuebles;

        public InmueblesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioPropietarios = new RepositorioPropietarios(configuration);
            repositorioInmuebles = new RepositorioInmuebles(configuration);
        }
        // GET: Inmuebles
        public ActionResult Index()
        {
            var lista = repositorioInmuebles.ObtenerTodos();
            return View(lista);
        }

        // GET: Inmuebles/Details/5
        public ActionResult Disponibles(int id)
        {
            var lista = repositorioInmuebles.ObtenerSiDisponible();
            return View(lista);
        }

        // GET: Inmuebles/Create
       // [Authorize(Policy = "Permitidos")]

        public ActionResult Create()
        {
            ViewBag.Propietarios = repositorioPropietarios.ObtenerTodos();
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         //[Authorize(Policy = "Permitidos")]
        public ActionResult Create(Inmuebles i)
        {
            try
            {
                int res = repositorioInmuebles.Alta(i);
                repositorioInmuebles.Disponible(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult InmPorProp(int id)
        {
            var i = repositorioInmuebles.BuscarPorPropietario(id);
            return View(i);

        }
        public ActionResult EditDeUs(int id)
        {
            var i = repositorioInmuebles.ObtenerPorId(id);
            return View(i);
        }
        // GET: Inmuebles/Edit/5
        // [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            var i = repositorioInmuebles.ObtenerPorId(id);
            ViewBag.Propietarios = repositorioPropietarios.ObtenerTodos();
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         //[Authorize(Policy = "Permitidos")]

        public ActionResult Edit(int id, Inmuebles i)
        {
            try
            {

                i.IdInm = id;
                repositorioInmuebles.Modificacion(i);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Propietarios = repositorioPropietarios.ObtenerTodos();
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(i);
            }
        }

        // GET: Inmuebles/Delete/5
         //[Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioInmuebles.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inmuebles i)
        {
            try
            {
                repositorioInmuebles.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(i);
            }
        }
        public ActionResult Filtrados()
        {
            return View();
        }
        public ActionResult Busqueda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Busqueda(BusquedaView busqueda)
        {
            try
            {
                if (busqueda.FechaInicio > busqueda.FechaCierre)
                {
                    ModelState.AddModelError("", "La Fecha de Inicio debe ser anterior a la de cierre");
                    return View();
                }
                else
                {
                    ViewBag.Filtrados = repositorioInmuebles.BuscarDesocupados(busqueda.FechaInicio, busqueda.FechaCierre);
                    if (ViewBag.Filtrados.Count == 0)
                    {
                        ModelState.AddModelError("", "No se encontraron resultados");
                        return View();
                    }
                    return View("Filtrados");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
