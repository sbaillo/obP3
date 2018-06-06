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
    [Table("Grupo")]
    public class Grupo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Grupo(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Grupo()
        {

        }
    }
}
