using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SB_Admin.Entities
{
 
    public class ProductosOBJ
    {

        [Required(ErrorMessage = "No se puede dejar campos vacios")]
        public int IDPRODUCTO { get; set; }
        [Required(ErrorMessage = "El IdProveedor es obligatorio no se permite campos vacíos")]
        public int IDPROVEEDOR { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio no se permite campos vacíos")]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "La Marca es obligatoria no se permite campos vacíos")]
        public string MARCA { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria no se permite campos vacíos")]
        public string CANTIDAD { get; set; }
        [Required]
        [StringLength(9, ErrorMessage = "El precio es invalido")]
        public string PROVEEDOR { get; set; }
        public string PRECIO { get; set; }
    }
    public class ProductosRespuestaOBJ
    {
        public int CodigoMensaje { get; set; }
        public string Mensaje { get; set; }
        public List<ProductosOBJ> DatosMensaje { get; set; }
    }
    
}