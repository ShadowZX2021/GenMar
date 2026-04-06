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
    public class TipoSueldoesController : Controller
    {
        private ControlGastosEntities db = new ControlGastosEntities();

        // GET: TipoSueldoes
        public ActionResult Index()
        {
            return View(db.TipoSueldo.ToList());
        }

        // GET: TipoSueldoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSueldo tipoSueldo = db.TipoSueldo.Find(id);
            if (tipoSueldo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSueldo);
        }

        // GET: TipoSueldoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSueldoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoSueldo,Descripcion,IdEstatus")] TipoSueldo tipoSueldo)
        {
            if (ModelState.IsValid)
            {
                db.TipoSueldo.Add(tipoSueldo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSueldo);
        }

        // GET: TipoSueldoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSueldo tipoSueldo = db.TipoSueldo.Find(id);
            if (tipoSueldo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSueldo);
        }

        // POST: TipoSueldoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoSueldo,Descripcion,IdEstatus")] TipoSueldo tipoSueldo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSueldo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSueldo);
        }

        // GET: TipoSueldoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSueldo tipoSueldo = db.TipoSueldo.Find(id);
            if (tipoSueldo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSueldo);
        }

        // POST: TipoSueldoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoSueldo tipoSueldo = db.TipoSueldo.Find(id);
            db.TipoSueldo.Remove(tipoSueldo);
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
