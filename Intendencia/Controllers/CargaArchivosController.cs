using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;


namespace Intendencia.Controllers
{
    public class CargaArchivosController : Controller
    {
        // GET: Archivos
        
        public ActionResult CargaArchivos()
        {
            Session["expediente"] = null;
            try
            {
                CargaDeArchivos.IniciarDB();
                CargaDeArchivos.CargarGrupos();
                CargaDeArchivos.CargarUsuarios();
                CargaDeArchivos.CargarTramites();
                CargaDeArchivos.CargarEtapas();
                CargaDeArchivos.CargarAsignacionGrupos();
                CargaDeArchivos.CargarUsuariosNuevos();
                return (RedirectToAction("MensajeOK"));
               
            }
            catch
            {
                return (RedirectToAction("MensajeError"));
                
            }
            
        }
           
               
        public ActionResult MensajeOK()
        {
            Session["expediente"] = null;
            ViewBag.Mensaje = "Carga de archivos exitosa";
            
            return View("MensajeCarga");
        }

        public ActionResult MensajeError()
        {
            Session["expediente"] = null;

            ViewBag.Mensaje = "Hubo un error en la carga de archivos";
            return View("MensajeCarga");
        }
    }
}