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
    public class PRESTAMOController : Controller
    {
        private BIBLIOTECADBEntities db = new BIBLIOTECADBEntities();

        // GET: PRESTAMO
        public ActionResult Index()
        {
            var pRESTAMO = db.PRESTAMO.Include(p => p.ESTUDIANTES).Include(p => p.LIBROS);
            return View(pRESTAMO.ToList());
        }

        // GET: PRESTAMO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMO pRESTAMO = db.PRESTAMO.Find(id);
            if (pRESTAMO == null)
            {
                return HttpNotFound();
            }
            return View(pRESTAMO);
        }

        // GET: PRESTAMO/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_ESTUDIANTE = new SelectList(db.ESTUDIANTES, "CODIGO", "NOMBRE");
            ViewBag.ID_LIBRO = new SelectList(db.LIBROS, "ID", "NOMBRE");
            return View();
        }

        // POST: PRESTAMO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODIGO_ESTUDIANTE,ID_LIBRO,FECHA")] PRESTAMO pRESTAMO)
        {
            if (ModelState.IsValid)
            {
                db.PRESTAMO.Add(pRESTAMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_ESTUDIANTE = new SelectList(db.ESTUDIANTES, "CODIGO", "NOMBRE", pRESTAMO.CODIGO_ESTUDIANTE);
            ViewBag.ID_LIBRO = new SelectList(db.LIBROS, "ID", "NOMBRE", pRESTAMO.ID_LIBRO);
            return View(pRESTAMO);
        }

        // GET: PRESTAMO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMO pRESTAMO = db.PRESTAMO.Find(id);
            if (pRESTAMO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_ESTUDIANTE = new SelectList(db.ESTUDIANTES, "CODIGO", "NOMBRE", pRESTAMO.CODIGO_ESTUDIANTE);
            ViewBag.ID_LIBRO = new SelectList(db.LIBROS, "ID", "NOMBRE", pRESTAMO.ID_LIBRO);
            return View(pRESTAMO);
        }

        // POST: PRESTAMO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODIGO_ESTUDIANTE,ID_LIBRO,FECHA")] PRESTAMO pRESTAMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRESTAMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_ESTUDIANTE = new SelectList(db.ESTUDIANTES, "CODIGO", "NOMBRE", pRESTAMO.CODIGO_ESTUDIANTE);
            ViewBag.ID_LIBRO = new SelectList(db.LIBROS, "ID", "NOMBRE", pRESTAMO.ID_LIBRO);
            return View(pRESTAMO);
        }

        // GET: PRESTAMO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMO pRESTAMO = db.PRESTAMO.Find(id);
            if (pRESTAMO == null)
            {
                return HttpNotFound();
            }
            return View(pRESTAMO);
        }

        // POST: PRESTAMO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRESTAMO pRESTAMO = db.PRESTAMO.Find(id);
            db.PRESTAMO.Remove(pRESTAMO);
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
