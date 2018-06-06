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
    [Table("Solicitante")]
    public class Solicitante
    {
        [Key]
        [Required(ErrorMessage = "La cédula no se puede dejar vacía")]
        [MinLength(8, ErrorMessage = "La cédula debe contener 8 numeros sin puntos ni guiones"), MaxLength(8, ErrorMessage = "La cédula debe contener 8 numeros sin puntos ni guiones")]

        public string Cedula { get; set; }

        [Required(ErrorMessage = "El nombre no puede ser vacío")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido no puede ser vacío")]
        [MinLength(2, ErrorMessage = "El apellido debe tener al menos 2 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono no puede ser vacío")]
        [MinLength(5, ErrorMessage = "El nombre debe tener al menos 5 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El nombre no puede ser vacío")]
        [EmailAddress]
        public string Email { get; set; }

        public Solicitante()
        {

        }
    }
}
