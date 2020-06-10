using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Extensions;
using Grupo1.AgendaDeTurnos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public CuentaController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Ingresar(string returnUrl)
        {
            //Se guardar URL
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
            public IActionResult Registrar()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registrar(Paciente paciente)
        {
            paciente.Rol = RolesEnum.CLIENTE;
            paciente.Username = paciente.Username.ToUpper();
            paciente.Password = paciente.nuevaPassword.Encriptar();
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Ingresar");
        }
        public IActionResult NoAutorizado()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Ingresar(string username, string password, string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                username = username.ToUpper();
                Usuario usuario = _context.Usuarios.FirstOrDefault(usr => usr.Username == username);
                var passwordEncriptada = password.Encriptar();
                

                if (usuario!=null && usuario.Password.SequenceEqual(passwordEncriptada))
                {

                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, username));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol.ToString()));
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                        return Redirect(returnUrl);

                    TempData["primerLogin"] = true;

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            //En caso de datos incorrectos
            ViewBag.Error = "Usuario o contraseña incorrectos";
            ViewBag.UserName = username;
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}