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
    [Table("AsignacionGrupo")]
    public class AsignacionGrupo
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Tramite")]
        public int IdTramite { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }

        public Tramite Tramite { get; set; }
        public Grupo Grupo { get; set; }

        public AsignacionGrupo(int idGrupo, int idTramite)
        {
            this.IdGrupo = idGrupo;
            this.IdTramite = idTramite;
        }

        public AsignacionGrupo()
        {

        }
    }
}
