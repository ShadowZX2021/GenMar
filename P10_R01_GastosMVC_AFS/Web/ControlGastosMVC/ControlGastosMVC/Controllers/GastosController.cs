using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlGastosMVC.Models;

namespace ControlGastosMVC.Controllers
{
    public class GastosController : Controller
    {
        private ControlGastosEntities db = new ControlGastosEntities();

        // GET: Gastos
        public ActionResult Index()
        {
            var gastosVM = db.Gastos
                .Include(g => g.Categorias)
                .Include(g => g.Usuarios)
                .Select(g => new GastosVM
                {
                    IdGastos = g.IdGastos,
                    Monto = g.Monto,
                    Descripcion = g.Descripcion,
                    Fecha = g.Fecha,
                    IdEstatus = g.IdEstatus,
                    CategoriaNombre = g.Categorias.Descripcion ?? g.Categorias.Nombre, // depende de tu modelo
                    UsuarioNombre = g.Usuarios.Nombre
                }).ToList();

            return View(gastosVM);
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Incluimos Usuario y Categoría
            var gasto = db.Gastos
                          .Include(g => g.Usuarios)
                          .Include(g => g.Categorias)
                          .FirstOrDefault(g => g.IdGastos == id);

            if (gasto == null)
                return HttpNotFound();

            return View(gasto);
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.IdCategorias = new SelectList(db.Categorias, "IdCategorias", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Gastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGastos,IdUsuario,IdCategorias,Monto,Descripcion,Fecha,IdEstatus")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Gastos.Add(gastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategorias = new SelectList(db.Categorias, "IdCategorias", "Nombre", gastos.IdCategorias);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", gastos.IdUsuario);
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategorias = new SelectList(db.Categorias, "IdCategorias", "Nombre", gastos.IdCategorias);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", gastos.IdUsuario);
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGastos,IdUsuario,IdCategorias,Monto,Descripcion,Fecha,IdEstatus")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategorias = new SelectList(db.Categorias, "IdCategorias", "Nombre", gastos.IdCategorias);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", gastos.IdUsuario);
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gastos gastos = db.Gastos.Find(id);
            db.Gastos.Remove(gastos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
