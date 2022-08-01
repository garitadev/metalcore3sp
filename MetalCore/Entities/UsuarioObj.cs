using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SB_Admin.Entities
{


    public class UsuarioObj
    {
        public int idUsuario { get; set; }


        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]

        public int idRol { get; set; }


        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        public string Apellido { get; set; }

        //Me permite validar el email
        [Display(Name = "Email")]
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Este email no es permitido")]
        public string email { get; set; }
        //Me permite validar la cedula
        [Display(Name = "cedula")]
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        [RegularExpression(@"^\(?([0-9]{1})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "El formato de la cedula no es permitido")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "No se puede dejar espacios en blanco")]
        public string password { get; set; }
        public string NombreRol { get; set; }
        public string NombreEstado { get; set; }
        public int idEstado { get; set; }


        public List<PermisosObj> listaPermisos { get; set; }


        public Rol rolId { get; set; }

    }
    public class UsuariosRespuestaOBJ
    {

        public int CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public List<UsuarioObj> DatosRespuesta { get; set; }
    }

    public class RolOBJ
    {

        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }

    public enum Rol
    {
        Administrador = 1,
        Empleado = 2


    }
}