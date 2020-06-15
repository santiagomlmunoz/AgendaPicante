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
    public class CuentasController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public CuentasController(AgendaDeTurnosDbContext context)
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
        public async Task<IActionResult> Registrar(string password, Paciente paciente)
        {
            paciente.Rol = RolesEnum.CLIENTE;
            string username = paciente.Username.ToUpper();
            if(validarUsuarioExiste(username)){
                ViewBag.Error = "El usuario ya existe";
                return View();
            }
            paciente.Username = username; //Le seteo el username en mayuscula
            paciente.Password = password.Encriptar();
            _context.Add(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Ingresar");
        }
        public IActionResult NoAutorizado()
        {
            return View();
        }

        private Boolean validarUsuarioExiste(string username)
        {
             Usuario usuario = _context.Pacientes.FirstOrDefault(usr => usr.Username == username);
            if (usuario != null)
            {
                return true;
            }else{
                return false;
            }
        }
        private Usuario getUsuarioLogueado(Usuario admin, Usuario prof, Usuario paciente)
        {
            Usuario user = null;
            if(admin != null)
            {
                user = admin;
                return user;
            }else if(prof != null)
            {
                user = prof;
                return user;
            }else if(paciente != null)
            {
                user = paciente;
                return user;
            }
            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Ingresar(string username, string password, string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                username = username.ToUpper();
                Usuario paciente = _context.Pacientes.FirstOrDefault(usr => usr.Username == username);
                Usuario admin = _context.Administradores.FirstOrDefault(usr => usr.Username == username);
                Usuario prof = _context.Profesionales.FirstOrDefault(usr => usr.Username == username);

                Usuario usuario = getUsuarioLogueado(admin, prof, paciente);

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