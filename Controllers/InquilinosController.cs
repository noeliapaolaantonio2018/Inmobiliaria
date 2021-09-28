using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;


namespace Inmobiliaria.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioInquilinos repositorioInquilinos;
        public InquilinosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioInquilinos = new RepositorioInquilinos(configuration);
        }

        // GET: Inquilinos
         [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioInquilinos.ObtenerTodos();
            return View(lista);

        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inquilinos/Create
         [Authorize(Policy = "Permitidos")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Inquilinos i)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = repositorioInquilinos.Alta(i);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error de registro, verifique Datos!!!");
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
         [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            var i = repositorioInquilinos.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);

        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Inquilinos i = null;
            try
            {
                i = repositorioInquilinos.ObtenerPorId(id);
                i.Nombre = collection["Nombre"];
                i.Apellido = collection["Apellido"];
                i.Dni = collection["Dni"];
                i.Telefono = collection["Telefono"];
                i.DireccionTrabajo = collection["DireccionTrabajo"];
                i.Nombre_Garante = collection["Nombre_Garante"];
                i.Dni_Garante = collection["Dni_Garante"];
                repositorioInquilinos.Modificacion(i);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(i);

            }
        }

        // GET: Inquilinos/Delete/5
         [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioInquilinos.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inquilinos entidad)
        {
            try
            {
                repositorioInquilinos.Baja(id);
                return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(entidad);

            }
        }
    }
}
