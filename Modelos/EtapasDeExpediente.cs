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
    [Table("EtapasDeExpediente")]
    public class EtapasDeExpediente
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Usuario Funcionario { get; set; }
        public bool Finalizada { get; set; }
        public string Foto { get; set; }

        public Etapa Etapa { get; set; }

        public EtapasDeExpediente()
        {

        }
    }
}
