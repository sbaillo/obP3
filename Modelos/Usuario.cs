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
    [Table("Usuario")]
    public class Usuario
    {
        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress]

        [Key]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no se puede dejar vacía")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }
        public Grupo Grupo { get; set; }

        public Usuario()
        {

        }
    }
}
