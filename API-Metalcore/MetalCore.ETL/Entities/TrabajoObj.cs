using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.ETL.Entities
{
   public class TrabajoObj
    {
        public int IdTrabajo { get; set; }

        public int IdUsuario { get; set; }
        public int IdEstadoTrabajo { get; set; }


        [Required(ErrorMessage = "Digite una descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        public string TelefonoCliente { get; set; }
        public string NombreUsuario { get; set; }
        public string Estado { get; set; }
        public int prueba { get; set; }

        //Se añaden adiccional


    }

    public class MaterialesOBJ
    {

        public int IdMaterial { get; set; }
        public int IdTrabajo { get; set; }
        public string NombrePro { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string NombreUsuario { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
