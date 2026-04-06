using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ControlGastosMVC.Models;
using ControlGastosMVC.Models.DTOs;

public class HomeController : Controller
{
    ControlGastosEntities db = new ControlGastosEntities();

    public ActionResult Index(int? idUsuario)
    {
        if (Session["Usuario"] == null)
            return RedirectToAction("Login", "Account");

        var usuario = Session["Usuario"] as Usuarios;

        List<GraficaGastosDTO> listaFinal = new List<GraficaGastosDTO>();

        if (usuario.IdNivelUsuario == 1)
        {
            ViewBag.Usuarios = db.Usuarios.ToList();
        }

        if (usuario.IdNivelUsuario == 1)
        {
            if (idUsuario.HasValue)
            {
                var datos = db.sp_GastosPorUsuario(idUsuario.Value).ToList();

                listaFinal = datos.Select(x => new GraficaGastosDTO
                {
                    Categoria = x.Categoria,
                    Total = x.Total ?? 0
                }).ToList();
            }
            else
            {
                var usuarios = db.Usuarios.Select(u => u.IdUsuario).ToList();

                Dictionary<string, decimal> acumulado = new Dictionary<string, decimal>();

                foreach (var id in usuarios)
                {
                    var datos = db.sp_GastosPorUsuario(id).ToList();

                    foreach (var item in datos)
                    {
                        var total = item.Total ?? 0;

                        if (acumulado.ContainsKey(item.Categoria))
                            acumulado[item.Categoria] += total;
                        else
                            acumulado[item.Categoria] = total;
                    }
                }

                listaFinal = acumulado.Select(x => new GraficaGastosDTO
                {
                    Categoria = x.Key,
                    Total = x.Value
                }).ToList();
            }
        }
        else
        {
            var datos = db.sp_GastosPorUsuario(usuario.IdUsuario).ToList();

            listaFinal = datos.Select(x => new GraficaGastosDTO
            {
                Categoria = x.Categoria,
                Total = x.Total ?? 0
            }).ToList();
        }

        ViewBag.Datos = listaFinal;
        ViewBag.IdUsuarioSeleccionado = idUsuario;

        return View();
    }
}