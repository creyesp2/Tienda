﻿using System;
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
    public class PersonaController : Controller
    {
        private SuperTiendaContext db = new SuperTiendaContext();

        // GET: /Persona/
        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.TipoDocumento);
            return View(personas.ToList());
        }

        // GET: /Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: /Persona/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricion");
            return View();
        }

        // POST: /Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PersonaID,Nombre,Apellido,FechaNacimiento,sueldo,TipoDocumentoID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricion", persona.TipoDocumentoID);
            return View(persona);
        }

        // GET: /Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricion", persona.TipoDocumentoID);
            return View(persona);
        }

        // POST: /Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PersonaID,Nombre,Apellido,FechaNacimiento,sueldo,TipoDocumentoID")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "Descricion", persona.TipoDocumentoID);
            return View(persona);
        }

        // GET: /Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: /Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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
