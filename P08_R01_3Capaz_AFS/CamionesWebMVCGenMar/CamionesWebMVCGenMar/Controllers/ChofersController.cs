using CamionesWebMVCGenMar.Models;
using CamionesWebMVCGenMar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CamionesWebMVCGenMar.Controllers
{
    public class ChofersController : Controller
    {
        private GenMarEntities db = new GenMarEntities();

        // GET: Chofers
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var query = db.Chofer.AsQueryable();
            int totalItems = query.Count();

            // Obtener los elementos paginados
            var items = query.OrderBy(x => x.IdChofer)
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            // Mapear a DTO
            var itemsDTO = items.Select(c => new ChoferDTOs
            {
                IdChofer = c.IdChofer,
                Nombre = c.Nombre,
                ApPaterno = c.ApPaterno,
                ApMaterno = c.ApMaterno,
                Telefono = c.Telefono,
                FechaNacimiento = c.FechaNacimiento,
                Licencia = c.Licencia,
                UrlFoto = c.UrlFoto,
                Disponibilidad = c.Disponibilidad,

            }).ToList();

            // Crear PageResult<CamionDTO>
            var model = new PageResult<ChoferDTOs>
            {
                Items = itemsDTO,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,

            };

            return View(model);
        }

        // GET: Chofers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer chofer = db.Chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // GET: Chofers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chofers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.Chofer.Add(chofer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chofer);
        }

        // GET: Chofers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer chofer = db.Chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // POST: Chofers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chofer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chofer);
        }

        // GET: Chofers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer chofer = db.Chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // POST: Chofers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chofer chofer = db.Chofer.Find(id);
            db.Chofer.Remove(chofer);
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
