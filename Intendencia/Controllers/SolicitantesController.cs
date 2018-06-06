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
    public class SolicitantesController : Controller
    {
        private JuntaContext db = new JuntaContext();

        
        // GET: Solicitantes/Create
        public ActionResult Index()
        {
            if (Session["usuario"] == null) return RedirectToAction("Index", "Home");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Cedula,Nombre,Apellido,Telefono,Email")] Solicitante solicitante)
        {

            if (ModelState.IsValid && db.Solicitantes.Find(solicitante.Cedula) == null)
            {
                db.Solicitantes.Add(solicitante);
                db.SaveChanges();
                TempData["cedula"] = solicitante.Cedula;
                return RedirectToAction("Index", "Expedientes");
            }

            return View(solicitante);
        }

        
    }
}
