using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Inmobiliaria.Controllers
{
     [Authorize]
    public class PagosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioContratos repositorioContratos;
        private readonly RepositorioPagos repositorioPagos;
        private readonly RepositorioInmuebles repositorioInmuebles;

        public PagosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioContratos = new RepositorioContratos(configuration);
            repositorioPagos = new RepositorioPagos(configuration);
            repositorioInmuebles = new RepositorioInmuebles(configuration);
        }
        // GET: Pagos
         [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioPagos.ObtenerTodos();
            return View(lista);
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pagos/Create
         [Authorize(Policy = "Permitidos")]
        public ActionResult Create(int id)
        {
            ViewBag.Contratos = repositorioContratos.ObtenerPorInm(id);
            Contratos c = repositorioContratos.ObtenerPorInm(id);
            IList<Pagos> pagos = repositorioPagos.ObtenerPorContr(c.IdContr);
            if (pagos.Count == 0)
            {
                ViewBag.NumPago = 1;
            }
            else
            {
                int np = pagos.Count;
                ViewBag.NumPago = np + 1;
            }

            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Pagos p)
        {
            try
            {
                int res = repositorioPagos.Alta(p);
                return RedirectToAction(nameof(Ver), new { id = p.IdContr });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        [Authorize(Policy = "Permitidos")]
        public ActionResult Ver(int id)
        {
            ViewBag.Contratos = repositorioContratos.ObtenerPorId(id);
            IList<Pagos> pagos = repositorioPagos.ObtenerPorContr(id);
            return View(pagos);
        }

        // GET: Pagos/Edit/5
         [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            var p = repositorioPagos.ObtenerPorId(id);
            return View(p);

        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Pagos p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = repositorioPagos.Modificacion(p);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }


        // GET: Pagos/Delete/5
         [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var p = repositorioPagos.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(p);
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pagos p)
        {
            try
            {
                repositorioPagos.Baja(id);
                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(p);
            }
        }
    }
}
