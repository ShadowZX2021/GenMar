using System.Linq;
using System.Web.Mvc;
using ControlGastosMVC.Models;
using ControlGastosMVC.Models.DTOs;

namespace ControlGastosMVC.Controllers
{
    public class AccountController : Controller
    {
        private ControlGastosEntities db = new ControlGastosEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = db.Usuarios
                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}