using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.ETL.Entities
{
    public class UsuarioObj
    {

        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string NombreRol { get; set; }
        public string NombreEstado { get; set; }
        public string Nombre { get; set; }
        public string TokenJWT { get; set; }

        public string Apellido { get; set; }

        public string email { get; set; }

        public string cedula { get; set; }

        public string password { get; set; }
        public int idEstado { get; set; }
        public List<PermisosObj> listaPermisos { get; set; }

    }
}
