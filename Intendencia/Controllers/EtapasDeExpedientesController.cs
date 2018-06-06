using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos;

namespace Intendencia.Controllers
{
    public class EtapasDeExpedientesController : Controller
    {
        private JuntaContext db = new JuntaContext();

        // GET: EtapasDeExpedientes
        public ActionResult Index()
        {
            return View(db.EtapasDeExpedientes.ToList());
        }

        // GET: EtapasDeExpedientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapasDeExpediente etapasDeExpediente = db.EtapasDeExpedientes.Find(id);
            if (etapasDeExpediente == null)
            {
                return HttpNotFound();
            }
            return View(etapasDeExpediente);
        }

        // GET: EtapasDeExpedientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtapasDeExpedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaInicio,FechaFin,Finalizada,Foto")] EtapasDeExpediente etapasDeExpediente)
        {
            if (ModelState.IsValid)
            {
                db.EtapasDeExpedientes.Add(etapasDeExpediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapasDeExpediente);
        }

        // GET: EtapasDeExpedientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapasDeExpediente etapasDeExpediente = db.EtapasDeExpedientes.Where(et => et.Id == id).Include(e => e.Etapa).FirstOrDefault();
            if (etapasDeExpediente == null)
            {
                return HttpNotFound();
            }
            return View(etapasDeExpediente);
        }

        // POST: EtapasDeExpedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaInicio,FechaFin,Finalizada,Foto")] EtapasDeExpediente etapasDeExpediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapasDeExpediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BuscarExpediente", "Expedientes");
            }
            return View(etapasDeExpediente);
        }

        // GET: EtapasDeExpedientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapasDeExpediente etapasDeExpediente = db.EtapasDeExpedientes.Find(id);
            if (etapasDeExpediente == null)
            {
                return HttpNotFound();
            }
            return View(etapasDeExpediente);
        }

        // POST: EtapasDeExpedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EtapasDeExpediente etapasDeExpediente = db.EtapasDeExpedientes.Find(id);
            db.EtapasDeExpedientes.Remove(etapasDeExpediente);
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
