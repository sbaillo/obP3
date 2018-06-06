using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Modelos
{
    [Table("Expediente")]
    public class Expediente
    {
        public int Id { get; set; }
        public bool EstaCerrado { get; set; }
        public Tramite Tramite { get; set; }
        public Solicitante Solicitante { get; set; }
        public string EmailFuncionario { get; set; }

        public DateTime FechaActual { get; set; }

        public List<EtapasDeExpediente> EtapasDeExpediente { get; set; }

        public Expediente()
        {

        }
    }
}
