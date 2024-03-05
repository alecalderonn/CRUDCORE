using System.ComponentModel.DataAnnotations;
namespace CRUDCORE.Models
{
    public class ContactoModel

        ////referencia a los datos de las columnas
        ////definiendo variables y getters,setters

    {
        public int idContacto { get; set; }

        [Required(ErrorMessage="El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Correo { get; set; }
    }
}
