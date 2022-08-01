using API_Metalcore.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class DashboardController : ApiController
    {

        [HttpGet]
        [Route("api/TotalProductos")]
        public IHttpActionResult TotalProductos()
        {
            DashboardModel model = new DashboardModel();
            try
            {
                var totalProducto = model.TotalProductos();
                return Ok(totalProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
