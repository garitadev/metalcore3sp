using API_Metalcore.Models;
using MetalCore.ETL.Entities;
using System;

using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class TrabajoController : ApiController
    {
        // GET: Trabajo
        TrabajoModel modelo = new TrabajoModel();

        [HttpGet]
        //[Authorize]
        [Route("api/ConsultarTrabajos")]
        public IHttpActionResult ConsultarTrabajos()
        {
            var consultaTrabajo = modelo.ConsultarTrabajos();
            return Ok(consultaTrabajo);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/ConsultarAsigMateri")]
        public IHttpActionResult ConsultarAsigMateri()
        {
            var ConsultarAsigMateri = modelo.ConsultarAsigMateri();
            return Ok(ConsultarAsigMateri);
        }


        [HttpGet]
        [Route("api/ConsultarEstadoTrabajosCombo")]
        public IHttpActionResult ConsultarEstadoTrabajosCombo()
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var UsuConsu = model.ConsultarEstadoTrabajosCombo();
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


     

        [HttpGet]
        [Route("api/VerifiFechas")]
        public IHttpActionResult VerifiFecha(int idUsuario, DateTime fecha)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                if (model.VerifiFecha(idUsuario, fecha))
                {
                    return Ok();

                }

                return BadRequest();




            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/VerifiStock")]
        public IHttpActionResult VerifiStock(int Cantidad, int idProducto)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                if (model.VerifiStock(Cantidad, idProducto))
                {
                    return Ok();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("api/ConsultarEmpleadoCombo")]
        public IHttpActionResult ConsultarEmpleadoCombo()
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var UsuConsu = model.ConsultarEmpleadoCombo();
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ConsultarProductoCombo")]
        public IHttpActionResult ConsultarProductoCombo()
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var UsuConsu = model.ConsultarProductoCombo();
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        [Route("api/RegistrarTrabajo")]
        public IHttpActionResult Registrar(TrabajoObj RegistrarTrabajo)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                model.RegistrarTrabajo(RegistrarTrabajo);

                return Ok(RegistrarTrabajo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //prueba

        [HttpGet]
        [Route("api/ConsultarTrabajosCombo")]
        public IHttpActionResult ConsultarTrabajosCombo()
        {
            try
            {
                var listaMaterialesXTrabajo = modelo.ConsultarTrabajosCombo();
                return Ok(listaMaterialesXTrabajo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]

        [Route("api/RegistrarMaterial")]
        public IHttpActionResult RegistrarMaterial(MaterialesOBJ RegistrarTrabajo)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                model.RegistrarMaterial(RegistrarTrabajo);

                return Ok(RegistrarTrabajo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}