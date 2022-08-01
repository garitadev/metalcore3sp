using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Metalcore.Models
{
    public class DashboardModel
    {

        public DashboardObj TotalProductos()
        {
            DashboardBLL BLL = new DashboardBLL();
            return (BLL.TotalProductos());
        }


    }
}