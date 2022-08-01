using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.ETL.Entities
{
    public class ProductosObj
    {
        public int IDPRODUCTO { get; set; }
        public int IDPROVEEDOR { get; set; }
        public string PROVEEDOR { get; set; }
        public string NOMBRE { get; set; }
        public string MARCA { get; set; }
        public int CANTIDAD { get; set; }
        public string PRECIO { get; set; }
    }
}
