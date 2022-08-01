using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SB_Admin.Entities
{

    public class ConsultaRequest 
    {
        public string nombreAprox { get; set; }
        public List<ProveedoresOBJ> listaproveedores { get; set; }
    }

    public class ProveedoresOBJ
    {
        public int idProveedor { get; set; }
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        public string direccion { get; set; }
        [Display(Name = "telefono")]
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se admiten números del 0-9")]
        public string telefono { get; set; }
        [Display(Name = "email")]
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El texto no corresponde a un email")]
        public string email { get; set; }
    }

    public class ProveedoresRespuestaOBJ
    {
        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<ProveedoresOBJ> DatosRespuesta { get; set; }
    }
}