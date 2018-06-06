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
    [Table("Etapa")]
    public class Etapa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [ForeignKey("Tramite")]
        public int IdTramite { get; set; }
        public int LapsoMaximo { get; set; }
        public string Descripcion { get; set; }
        public Tramite Tramite { get; set; }

        public Etapa(int idTramite, int id, string desc, int lapso)
        {
            this.Id = id;
            this.LapsoMaximo = lapso;
            this.Descripcion = desc;
            this.IdTramite = idTramite;
        }

        public Etapa()
        {

        }
    }
}
