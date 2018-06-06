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
    [Table("Tramite")]
    public class Tramite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double Costo { get; set; }
        public int TiempoDias { get; set; }


        public List<Etapa> Etapas { get; set; }

        public List<AsignacionGrupo> GruposAsignados { get; set; }

        public Tramite(int id, string titulo, double costo, int tiempo)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Costo = costo;
            this.TiempoDias = tiempo;
        }

        public Tramite()
        {

        }
    }
}
