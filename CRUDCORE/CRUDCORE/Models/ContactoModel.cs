//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }

        [Required (ErrorMessage = "El campo Nombres es Obligatorio.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "El campo Apellidos es Obligatorio.")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es Obligatorio.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es Obligatorio.")]
        public string? Correo { get; set;}
    }
}
