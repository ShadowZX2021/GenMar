using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamionesWebMVCGenMar.Models;

namespace CamionesWebMVCGenMar.Controllers
{
    public class RutasController : Controller
    {
        private GenMarEntities db = new GenMarEntities();

        // GET: Rutas
        public ActionResult Index()
        {
            var ruta = db.Ruta.Include(r => r.Camiones).Include(r => r.Chofer);
            return View(ruta.ToList());
        }

        // GET: Rutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula");
            ViewBag.IdChofer = new SelectList(db.Chofer, "IdChofer", "Nombre");
            return View();
        }

        // POST: Rutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Ruta.Add(ruta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", ruta.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Chofer, "IdChofer", "Nombre", ruta.IdChofer);
            return View(ruta);
        }

        // GET: Rutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", ruta.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Chofer, "IdChofer", "Nombre", ruta.IdChofer);
            return View(ruta);
        }

        // POST: Rutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", ruta.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Chofer, "IdChofer", "Nombre", ruta.IdChofer);
            return View(ruta);
        }

        // GET: Rutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ruta ruta = db.Ruta.Find(id);
            db.Ruta.Remove(ruta);
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
