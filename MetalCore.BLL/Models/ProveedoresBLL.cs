using MetalCore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.BLL.Models
{
    public class ProveedoresBLL
    {
        public List<SelectListItem> ConsultarProveedoresCombo()
        {
            ProveedoresDAL DAL = new ProveedoresDAL();
            return (DAL.ConsultarProveedoresCombo());
        }
    }
}
