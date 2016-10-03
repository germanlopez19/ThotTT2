using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TT2Thot.Models;

namespace TT2Thot.Controllers
{
    public class TemasController : Controller
    {
        private ThotDBContext db = new ThotDBContext();

        // GET: Temas
        public ActionResult Index()
        {
            var temas = db.Temas.Include(t => t.Unidad);
            return View(temas.ToList());
        }

        // GET: Temas/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Temas.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // GET: Temas/Create
        [Authorize (Users = "german.lopez19@ymail")]
        public ActionResult Create()
        {
            ViewBag.UnidadID = new SelectList(db.Unidads, "UnidadID", "Numero");
            return View();
        }

        // POST: Temas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemaID,Numero,Nombre,UnidadID,Contenido,Bibliografia")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Temas.Add(tema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadID = new SelectList(db.Unidads, "UnidadID", "Numero", tema.UnidadID);
            return View(tema);
        }

        // GET: Temas/Edit/5
        [Authorize(Users = "german.lopez19@ymail")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Temas.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadID = new SelectList(db.Unidads, "UnidadID", "Numero", tema.UnidadID);
            return View(tema);
        }

        // POST: Temas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemaID,Numero,Nombre,UnidadID,Contenido,Bibliografia")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadID = new SelectList(db.Unidads, "UnidadID", "Numero", tema.UnidadID);
            return View(tema);
        }

        // GET: Temas/Delete/5
        [Authorize(Users = "german.lopez19@ymail")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Temas.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tema tema = db.Temas.Find(id);
            db.Temas.Remove(tema);
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
