using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos;
using Intendencia.Models;

namespace Intendencia.Controllers
{
    public class ExpedientesController : Controller
    {
        private JuntaContext db = new JuntaContext();

        // GET: Expedientes
        public ActionResult Index()
        {
            if (Session["usuario"] == null) return RedirectToAction("Index", "Home");
            Session["expediente"] = null;


            AltaExpedienteViewModel model = new AltaExpedienteViewModel();
            
            if(TempData["cedula"] != null)
            {
                model.CedulaSolicitante = TempData["cedula"].ToString();
            }

            return View(model);

        }

        [HttpPost]
        public ActionResult Index(AltaExpedienteViewModel model)
        {
            if (Session["usuario"] == null) return RedirectToAction("Index", "Home");
            string mail = Session["usuario"].ToString();

            Solicitante solicitante = db.Solicitantes.Find(model.CedulaSolicitante);
            if (ModelState.IsValid && solicitante != null)
            {
                Tramite tramite = db.Tramites.Where(m => m.Id == model.idTramiteSeleccionado).Include(t => t.Etapas).FirstOrDefault();
                Expediente e = new Expediente { Solicitante = solicitante, EmailFuncionario = mail, EstaCerrado = false, FechaActual = DateTime.Today, Tramite = tramite, EtapasDeExpediente = new List<EtapasDeExpediente>() };
               
                foreach (Etapa et in e.Tramite.Etapas)
                {
                    EtapasDeExpediente EtapaExpediente = new EtapasDeExpediente { Etapa = et, FechaInicio = e.FechaActual, FechaFin = e.FechaActual, Funcionario = null, Finalizada = false, Foto = ""};
                    e.EtapasDeExpediente.Add(EtapaExpediente);
                }

                db.Expedientes.Add(e);
                db.SaveChanges();
                ViewBag.Mensaje = "Alta de expediente exitosa";
                return View("Mensaje");
            }

            ViewBag.Error = "Error al ingresar un nuevo expediente";
            return View(model);
        }

        [HttpPost]
        public string existeSolicitante(string cedula)
        {
            if (db.Solicitantes.Find(cedula) == null) return "false";
            else
                return "true";
        }

        // GET: Expedientes
        public ActionResult BuscarExpediente()
        {
            if (Session["usuario"] == null) return RedirectToAction("Index", "Home");
            

            if (Session["expediente"] != null)
            {
                int id = (int)Session["expediente"];
                Expediente expediente = db.Expedientes.Where(m => m.Id == id).Include(t => t.EtapasDeExpediente).FirstOrDefault();
                if (expediente == null)
                {
                    ViewBag.Error = "No se encontró el expediente";
                    return View();
                }
                else
                {
                    return View(expediente.EtapasDeExpediente);
                }
            }

            return View();

        }
        


        [HttpPost]
        public ActionResult BuscarExpediente(string idExpediente)
        {
            if (Session["usuario"] == null) return RedirectToAction("Index", "Home");
            Session["expediente"] = null;

            int id;
            Expediente expediente = null;
            bool esNumero = Int32.TryParse(idExpediente, out id);

            if (esNumero)
            {
                expediente = db.Expedientes.Where(m => m.Id == id).Include(t => t.EtapasDeExpediente).FirstOrDefault();
            }

            if (expediente == null)
            {
                ViewBag.Error = "No se encontró el expediente";
                return View();
            }

            Session["expediente"] = id;
            return View(expediente.EtapasDeExpediente);

        }

    }
}
