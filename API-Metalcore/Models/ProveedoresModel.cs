using MetalCore.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_Metalcore.Models
{
    public class ProveedoresModel
    {
        public List<SelectListItem> ConsultarProveedoresCombo()
        {
            ProveedoresBLL BLL= new ProveedoresBLL();
            return (BLL.ConsultarProveedoresCombo());
        }
    }
}