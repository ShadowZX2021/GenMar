using Microsoft.AspNetCore.Mvc;
using CalculadoraMVCGenMar.Models;

namespace CalculadoraMVCGenMar.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculadoraModel());
        }

        [HttpPost]
        public IActionResult Calcular(CalculadoraModel modelo)
        {
            if (modelo != null)
            {
                modelo.Calcular();

                // Manejo de errores
                if (modelo.Resultado == null && modelo.Operacion == "dividir")
                    ViewBag.Error = "No se puede dividir por cero";
                if (modelo.Operacion == "raiz" && modelo.Numero1 < 0)
                    ViewBag.Error = "No se puede sacar raíz de un número negativo";
                if (modelo.Operacion == "log" && modelo.Numero1 <= 0)
                    ViewBag.Error = "El logaritmo solo acepta números positivos";
            }

            return View("Index", modelo);
        }
    }
}