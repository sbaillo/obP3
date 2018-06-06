using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intendencia.Models
{
    public class AltaExpedienteViewModel
    {
        [Display(Name = "Tramites")]
        public int idTramiteSeleccionado { get; set; }

        [Display(Name = "Cedula")]
        public string CedulaSolicitante { get; set; }

        public SelectList TramitesDisponibles { get; set; }
        public Expediente Expediente { get; set; }
        public AltaExpedienteViewModel()
        {
            cargarTramites();
        }

        private void cargarTramites()
        {
            JuntaContext db = new JuntaContext();
            this.TramitesDisponibles = new SelectList(db.Tramites, "Id", "Titulo");
        }



    }
}
