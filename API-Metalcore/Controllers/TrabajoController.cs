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
        [Route("api/VerTrabajos")]
        public IHttpActionResult VerTrabajos()
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var listaTrabajo = model.VerTrabajos();
                return Ok(listaTrabajo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ConsultarEstadoCombo")]
        public IHttpActionResult ConsultarEstadosCombo()
        {
            try
            {
                TrabajoModel estados = new TrabajoModel();

                var listaEstados = estados.ConsultarEstadosCombo();
                return Ok(listaEstados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/ConsultarEstadoEspecifico")]
        public IHttpActionResult ConsultarEstadoEspecifico(int idEstado)
        {
            try
            {
                TrabajoModel model = new TrabajoModel();

                var estado = model.ConsultarEstadoEspecifico(idEstado);
                return Ok(estado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        ///////////////////////////////////////////////

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
        [Route("api/EncontrarPrecio")]
        public IHttpActionResult EncontrarPrecio(int idProducto)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var consuPrecio = model.EncontrarPrecio(idProducto);

                return Ok(consuPrecio);

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

        //modificar material
        
        [HttpGet]
        [Route("api/ConsultarUTrabajoEspecifico")]
        public IHttpActionResult ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var TraConsu = model.ConsultarUTrabajoEspecifico(idTrabajo);
                return Ok(TraConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("api/ConsultarMaterialEspecifico")]
        public IHttpActionResult ConsultarMaterialEspecifico(int idMaterial)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                var TraConsu = model.ConsultarMaterialEspecifico(idMaterial);
                return Ok(TraConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Trabajo/ActuaTrabajo")]
        public IHttpActionResult ActuaTrabajo(TrabajoObj Actua)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                model.ActuaTrabajo(Actua);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Trabajo/ActuaMaterial")]
        public IHttpActionResult ActuaMaterial(MaterialesOBJ Actua)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                model.ActuaMaterial(Actua);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/VerifiStockActua")]
        public IHttpActionResult VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                if (model.VerifiStockActua(Cantidad, idProducto, idMaterial))
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

        //borrar'''''''''''''''''''

        [HttpGet]
        [Route("api/BorrarTrabajo")]
        public IHttpActionResult BorrarTrabajo(int idTrabajo)
        {
            try
            {
                TrabajoModel model = new TrabajoModel();
                model.BorrarTrabajo(idTrabajo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/BorrarMaterial")]
        public IHttpActionResult BorrarMaterial(int idMaterial)
        {
            try
            {
                TrabajoModel model = new TrabajoModel();
                model.BorrarMaterial(idMaterial);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/VerifiExisTrabajo")]
        public IHttpActionResult VerifiExisTrabajo(int idTrabajo)
        {
            TrabajoModel model = new TrabajoModel();
            try
            {
                if (model.VerifiExisTrabajo(idTrabajo))
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


    }
}