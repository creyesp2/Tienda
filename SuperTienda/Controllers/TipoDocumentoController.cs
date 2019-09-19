using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperTienda.Models;

namespace SuperTienda.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private SuperTiendaContext db = new SuperTiendaContext();

        // GET: /TipoDocumento/
        public ActionResult Index()
        {
            return View(db.TipoDocumentoes.ToList());
        }

        // GET: /TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // GET: /TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoDocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TipoDocumentoID,Descricion")] TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumentoes.Add(tipodocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodocumento);
        }

        // GET: /TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: /TipoDocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TipoDocumentoID,Descricion")] TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodocumento);
        }

        // GET: /TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: /TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            db.TipoDocumentoes.Remove(tipodocumento);
            try {
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }
           
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
