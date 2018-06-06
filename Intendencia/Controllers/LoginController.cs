using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using System.Data.Entity;

namespace Intendencia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario u)
        {
            Session["expediente"] = null;
            if (ModelState.IsValid)
            {
                using (JuntaContext db = new JuntaContext())
                {
                    Usuario buscado = db.Usuarios.Find(u.Email);
                    if (buscado != null)
                    {
                        if (buscado.Password == u.Password)
                        {
                            Session["usuario"] = buscado.Email;
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
            }
            ViewBag.Mensaje = "Usuario o contraseña incorrecta";
            return View(u);
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}