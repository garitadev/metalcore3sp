using API_Metalcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class ProveedorController : ApiController
    {
        [HttpGet]
        [Route("api/ConsultarProveedoresCombo")]
        public IHttpActionResult ConsultarTrabajosCombo()
        {
            try
            {
                ProveedoresModel proveedores = new ProveedoresModel();

                var listaProveedores = proveedores.ConsultarProveedoresCombo();
                return Ok(listaProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

