using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LIBROSController : Controller
    {
        private BIBLIOTECADBEntities db = new BIBLIOTECADBEntities();

        // GET: LIBROS
        public ActionResult Index()
        {
            return View(db.LIBROS.ToList());
        }

        // GET: LIBROS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBROS lIBROS = db.LIBROS.Find(id);
            if (lIBROS == null)
            {
                return HttpNotFound();
            }
            return View(lIBROS);
        }

        // GET: LIBROS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LIBROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,AUTOR,GENERO")] LIBROS lIBROS)
        {
            if (ModelState.IsValid)
            {
                db.LIBROS.Add(lIBROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIBROS);
        }

        // GET: LIBROS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBROS lIBROS = db.LIBROS.Find(id);
            if (lIBROS == null)
            {
                return HttpNotFound();
            }
            return View(lIBROS);
        }

        // POST: LIBROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,AUTOR,GENERO")] LIBROS lIBROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIBROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIBROS);
        }

        // GET: LIBROS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBROS lIBROS = db.LIBROS.Find(id);
            if (lIBROS == null)
            {
                return HttpNotFound();
            }
            return View(lIBROS);
        }

        // POST: LIBROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIBROS lIBROS = db.LIBROS.Find(id);
            db.LIBROS.Remove(lIBROS);
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
