
using API_Metalcore.Models;
using MetalCore.ETL.Entities;
using System;

using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class UsuarioController : ApiController
    {
        //Instancia general del modelo Usuario
        UsuarioModel modelo = new UsuarioModel();

        [HttpGet]
        //[Authorize]
        [Route("api/ConsultarTodosUsuarios")]
        public IHttpActionResult ConsultarTodosUsuarios()
        {
            var consultaUsuarios = modelo.ConsultarUsuarios();
            return Ok(consultaUsuarios);
        }

        //validar la existencia del usuario
        [HttpGet]
        [Route("api/VerifiExistencia")]
        public IHttpActionResult VerifiExistencia(string Email, string Cedula)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                if (model.VerifiExistencia(Email, Cedula))
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

        //consulta un usuario en especifico
        [HttpGet]
        [Route("api/ConsultarUsuarioEspecifico")]
        public IHttpActionResult ConsultarUsuarioEspecifico(int idUsuario)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                var UsuConsu = model.ConsultarUsuarioEspecifico(idUsuario);
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //consulta los roles que se encuentra ingresados
        [HttpGet]
        [Route("api/ConsultarRolesCombo")]
        public IHttpActionResult ConsultarRolesCombo()
        {


            UsuarioModel model = new UsuarioModel();
            try
            {

                var UsuConsu = model.ConsultarRolesCombo();
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ConsultarEstadosCombo")]
        public IHttpActionResult ConsultarEstadosCombo()
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                var UsuConsu = model.ConsultarEstadosCombo();
                return Ok(UsuConsu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/RegistrarUsuario")]
        public IHttpActionResult Registrar(UsuarioObj usuarioRegistro)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                model.RegistrarUsuario(usuarioRegistro);
                //var resultado = model.ConsultarTodosDatos();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //modificar los datos de un empleado

        [HttpPost]
        [Route("api/Usuario/ActualizarUsuario")]
        public IHttpActionResult ActuaUsuario(UsuarioObj Actua)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                model.ActuaUsuario(Actua);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Helpers

       

        [HttpPost]
        [AllowAnonymous]
        [Route("api/ValidarCredenciales")]
        public IHttpActionResult ValidarCredenciales(UsuarioObj obj)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                UsuarioObj usuario = modelo.ValidarCredenciales(obj);

                if (usuario != null)
                {
                    usuario.TokenJWT  = TokenGenerator.GenerateTokenJwt(obj.email);
                    return Ok(usuario);//hay que devolver todo el obj

                }
                else
                {
                    return Unauthorized();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ValidarExistenciaEmail")]
        public IHttpActionResult ValidarExistenciaEmail(string email)
        {
            if (modelo.ValidarExistenciaEmail(email))
            {
                return Ok();

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/GenerarTokenPassword")]
        public IHttpActionResult GenerarTokenPassword(RecoveryPassword obj)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                if (model.GenerarTokenPassword(obj) ==null)
                {
                    return BadRequest();

                }
                {
                    return Ok(obj);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("api/RestablecerPassword")]
        public IHttpActionResult RestablecerPassword(RecoveryPassword obj)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                if (model.RestablecerPassword(obj) == null)
                {
                    return BadRequest();

                }
                {
                    return Ok(obj);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/ConsultarRol")]
        public IHttpActionResult ConsultarRol(int idRol, int idOperacion)
        {
            UsuarioModel model = new UsuarioModel();
            try
            {
                var Consu = model.ConsultarRol(idRol, idOperacion);
                return Ok(Consu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
