//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using SB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Controllers
{
    public class UsuarioController : Controller
    {
       

        // GET: Usuario
        public ActionResult Consultar()
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                if (Session["User"] != null)
                {

                    UsuarioModel CosultaUsuarios = new UsuarioModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    var respuesta = CosultaUsuarios.ConsultarTodosUsuarios(token);
                  

                    return View(respuesta);

                }
                return View();

            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {

            var usuario = new UsuarioObj();
            return View(usuario);
        }

        public ActionResult CrearUsuarioFrm()
        {
            try
            {
                UsuarioModel usuarioModel = new UsuarioModel();

                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;

                    ViewBag.listaRoles = usuarioModel.ConsultarRolesCombo();
                    ViewBag.ListEstado = usuarioModel.ConsultarEstadosCombo();
                    return View("Crear");

                }



                return View("Crear");
            }
            catch (Exception e)
            {
                //bita.RegistrarError(e.Message);
                return View("../Shared/Error");
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioObj usuario)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            string Email = usuario.email; //variables para la validación de existencia
            string Cedula = usuario.cedula;
            try
            {
                UsuarioModel modelo = new UsuarioModel();

                var respuestaV = modelo.VerifiExistencia(Email, Cedula); //metodo de existencia
                  ViewBag.listaPermisos = user.listaPermisos;
                                                           //validacion
                if (ModelState.IsValid)
                {
                     if (respuestaV == false)
                    {
                        UsuarioModel modelos = new UsuarioModel();
                        ViewBag.listaPermisos = user.listaPermisos;
                        ViewBag.MjsCrear = "Mensaje"; //envia un mensaje de que el usuario ya esta registrado
                        ViewBag.listaRoles = modelos.ConsultarRolesCombo(); //llama la consulta de los roles 
                       
                        return View("Crear");

                    }
                    else
                    {
                        //crea un empleado nuevo
                        UsuarioModel modelos = new UsuarioModel();
                         ViewBag.listaPermisos = user.listaPermisos;
                        modelos.RegistrarUsuario(usuario, token);
                        ViewBag.MjsCreado = "Mensaje";
                        ViewBag.listaRoles = modelos.ConsultarRolesCombo(); //llama la consulta de los roles 
                      
                        return View("Crear");
                    }

                }
                else
                {
                    return View(usuario);
                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }


        //Modificar usuario
        [HttpPost]
        public ActionResult ModificarUsuarioForm(int idUsuario)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = usuario.ConsultarUsuarioEspecifico(idUsuario);
               
               
                ViewBag.listaRoles = usuario.ConsultarRolesCombo();
                UsuarioModel usuarioa = new UsuarioModel();
                ViewBag.listaEstados = usuarioa.ConsultarEstadosCombo();



                if (respuesta != null)
                {
                    return View("Actualizar", respuesta);
                }
                else
                {
                    return View("../Shared/Error");

                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

        }

        public ActionResult ActuaUsuario(UsuarioObj Actua)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                UsuarioModel modelo = new UsuarioModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modelo.ActuaUsuario(Actua);
              
                if (respuesta == true)
                {
                    ViewBag.MjsActua = "Mensaje";
                    return RedirectToAction("Consultar", "Usuario");
                }
                else
                {

                    return View("../Shared/Error");
                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }
    }


}
