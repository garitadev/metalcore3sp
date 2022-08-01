using MetalCore.DAL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.BLL.Models
{
    public class DashboardBLL
    {
        public DashboardObj TotalProductos()
        {
            DashboardDAL DAL = new DashboardDAL();
            return (DAL.TotalProductos());
        }


    }
}
