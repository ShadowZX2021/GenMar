using CamionesWebMVCGenMar.Models;
using CamionesWebMVCGenMar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamionesWebMVCGenMar.Controllers
{
    public class AccountController : Controller
    {
        private GenMarEntities db = new GenMarEntities();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //  Buscar usuario
            var usuario = db.Usuarios
                .FirstOrDefault(u => u.Email == model.Email);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuario no existe");
                return View(model);
            }

            //  Validar password
            if (usuario.Password != model.Password)
            {
                ModelState.AddModelError("", "Contraseña incorrecta");
                return View(model);
            }

            //  GUARDAR SESIÓN
            Session["Usuario"] = usuario.Usuario;
            Session["IdUsuario"] = usuario.IdUsuario;

            // 🚀 REDIRIGIR AL MENÚ
            return RedirectToAction("Index", "Home");
        }

        // LOGOUT
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}