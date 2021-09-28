using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

using System.Security.Claims;
using System.Threading.Tasks;

namespace Inmobiliaria.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;
        private readonly RepositorioUsuarios repositorioUsuarios;
        public UsuariosController(IConfiguration configuration)
        {
            this.configuration = configuration;
#pragma warning disable CS1717 // Asignación a la misma variable. ¿Quería asignar otro elemento?
            this.environment = environment;
#pragma warning restore CS1717 // Asignación a la misma variable. ¿Quería asignar otro elemento?
            repositorioUsuarios = new RepositorioUsuarios(configuration);
        }

        // GET: Admin
        public ActionResult Index()
        {
            var lista = repositorioUsuarios.ObtenerTodos();
            return View(lista);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        [Authorize(Policy = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
#pragma warning disable CS0161 // 'UsuariosController.Create(Usuarios)': no todas las rutas de acceso de código devuelven un valor
        public ActionResult Create(Usuarios u)
#pragma warning restore CS0161 // 'UsuariosController.Create(Usuarios)': no todas las rutas de acceso de código devuelven un valor
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: u.Clave,
                        salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 1000,
                        numBytesRequested: 256 / 8));
                u.Clave = hashed;

                var nbreRnd = Guid.NewGuid();//posible nombre aleatorio
                int res = repositorioUsuarios.Alta(u);
                if (u.AvatarFile != null && u.IdUs > 0)
                {
                    string wwwPath = environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "img");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //Path.GetFileName(u.AvatarFile.FileName);//este nombre se puede repetir
                    string fileName = "avatar_" + u.IdUs + Path.GetExtension(u.AvatarFile.FileName);
                    string pathCompleto = Path.Combine(path, fileName);
                    u.Avatar = Path.Combine("/img", fileName);
                    using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                    {
                        u.AvatarFile.CopyTo(stream);
                    }
                    repositorioUsuarios.Modificacion(u);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id)
        {
            var i = repositorioUsuarios.ObtenerPorId(id);
            return View(i);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id, Usuarios i)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    i.Clave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: i.Clave,
                        salt: System.Text.Encoding.ASCII.GetBytes("Salt"),
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 1000,
                        numBytesRequested: 256 / 8));
                    int res = repositorioUsuarios.Modificacion(i);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar, verifique datos!!");
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioUsuarios.ObtenerPorId(id);
            return View(i);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Usuarios i)
        {
            try
            {
                int res = repositorioUsuarios.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginView login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                     password: login.Clave,
                     salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                     prf: KeyDerivationPrf.HMACSHA1,
                     iterationCount: 1000,
                     numBytesRequested: 256 / 8));

                    var e = repositorioUsuarios.ObtenerPorEmail(login.Email);
                    if (e == null /*|| e.Clave != hashed*/)
                    {
                        ModelState.AddModelError("", "El email y/o el password son incorrectos");
                        return View();
                    }
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, e.Email),
                        new Claim("FullName", e.Nombre + " " + e.Apellido),
                        new Claim(ClaimTypes.Role, e.Rol),
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));


                    return RedirectToAction(nameof(Index), "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


    }
}
