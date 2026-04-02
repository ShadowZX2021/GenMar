using CamionesWebMVCGenMar.Models;
using CamionesWebMVCGenMar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CamionesWebMVCGenMar.Controllers
{
    public class CamionesController : Controller
    {
        private GenMarEntities db = new GenMarEntities();

        // GET: Camiones
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var query = db.Camiones.AsQueryable();
            int totalItems = query.Count();

            // Obtener los elementos paginados
            var items = query.OrderBy(x => x.IdCamion)
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            // Mapear a DTO
            var itemsDTO = items.Select(c => new CamionDTO
            {
                IdCamion = c.IdCamion,
                Matricula = c.Matricula,
                TipoCamion = c.TipoCamion,
                Modelo = c.Modelo,
                Marca = c.Marca,
                Capacidad = c.Capacidad,
                Kilometraje = c.Kilometraje,
                Disponible = c.Disponibilidad,
                URLFoto = c.URLFoto,
               
            }).ToList();

            // Crear PageResult<CamionDTO>
            var model = new PageResult<CamionDTO>
            {
                Items = itemsDTO,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
              
            };

            return View(model);
        }

        // GET: Camiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
                return HttpNotFound();

            return View(camiones);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,URLFoto,FechaRegistro")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Camiones.Add(camiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camiones);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
                return HttpNotFound();

            return View(camiones);
        }

        // POST: Camiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,URLFoto,FechaRegistro")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camiones);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
                return HttpNotFound();

            return View(camiones);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camiones camiones = db.Camiones.Find(id);
            db.Camiones.Remove(camiones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}