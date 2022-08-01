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
    public class InventarioController : ApiController
    {


        [HttpGet]
        [Route("api/ObtenerProveedor")]
        public IHttpActionResult ObtenerProveedor()
        {
            InventarioModel model = new InventarioModel();
            try
            {
                var cbtenerProveedor = model.ObtenerProveedor();
                return Ok(cbtenerProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConsultarInventario")]
        public IHttpActionResult ConsultarInventario()
        {
            InventarioModel model = new InventarioModel();
            try
            {
                var listaInventario = model.ConsultarProductos();
                return Ok(listaInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpGet]
        [Route("api/ConsultarInventarioCB")]
        public IHttpActionResult ConsultarInventarioCombo()
        {
            InventarioModel model = new InventarioModel();
            try
            {
                var listaInventario = model.ConsultarProductosCombo();
                return Ok(listaInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/ConsultarProductoEspecifico")]
        public IHttpActionResult ConsultarProductoEspecifico(int idProducto)
        {
            InventarioModel model = new InventarioModel();
            try
            {
                var producto = model.ConsultarProducto(idProducto);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ActualizarProducto")]
        public IHttpActionResult ActualizarProducto(ProductosObj producto)
        {
            InventarioModel model = new InventarioModel();
            try
            {
                model.ActualizarProductos(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/CrearProducto")]
        public IHttpActionResult CrearProducto(ProductosObj producto)
        {
            try
            {
                InventarioModel inventario = new InventarioModel();
                inventario.RegistrarProductos(producto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/BorrarProductos")]
        public IHttpActionResult BorrarProductos(int idProducto)
        {
            try
            {
                InventarioModel inventario = new InventarioModel();
                inventario.BorrarProductos(idProducto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}

