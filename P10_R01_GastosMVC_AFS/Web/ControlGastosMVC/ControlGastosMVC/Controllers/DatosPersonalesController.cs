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
    public class DatosPersonalesController : Controller
    {
        private ControlGastosEntities db = new ControlGastosEntities();

        // GET: DatosPersonales
        public ActionResult Index()
        {
            // Proyectar los datos al ViewModel para evitar proxies
            var datosPersonalesVM = db.DatosPersonales
                .Include(d => d.TipoSueldo)
                .Select(d => new DatosPersonalesVM
                {
                    IdDatos = d.IdDatos,
                    Nombre = d.Nombre,
                    ApPaterno = d.ApPaterno,
                    ApMaterno = d.ApMaterno,
                    Telefono = d.Telefono,
                    Direccion = d.Direccion,
                    SueldoBase = d.SueldoBase,
                    IdEstatus = d.IdEstatus,
                    TipoSueldoDescripcion = d.TipoSueldo.Descripcion
                }).ToList();

            return View(datosPersonalesVM);
        }

        // GET: DatosPersonales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoSueldo = new SelectList(db.TipoSueldo, "IdTipoSueldo", "Descripcion");
            return View();
        }

        // POST: DatosPersonales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDatos,Nombre,ApPaterno,ApMaterno,Telefono,Direccion,SueldoBase,IdTipoSueldo,IdEstatus")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.DatosPersonales.Add(datosPersonales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoSueldo = new SelectList(db.TipoSueldo, "IdTipoSueldo", "Descripcion", datosPersonales.IdTipoSueldo);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoSueldo = new SelectList(db.TipoSueldo, "IdTipoSueldo", "Descripcion", datosPersonales.IdTipoSueldo);
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDatos,Nombre,ApPaterno,ApMaterno,Telefono,Direccion,SueldoBase,IdTipoSueldo,IdEstatus")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosPersonales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoSueldo = new SelectList(db.TipoSueldo, "IdTipoSueldo", "Descripcion", datosPersonales.IdTipoSueldo);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            db.DatosPersonales.Remove(datosPersonales);
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
