using SB_Admin.Filters;
using SB_Admin.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Controllers
{
    public class TrabajoController : Controller
    {
        // GET: Trabajo
        [HttpGet]
        public ActionResult Consultar()
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                if (Session["User"] != null)
                {

                    TrabajoModel CosultaTrabajos = new TrabajoModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    var respuesta = CosultaTrabajos.Consultar(token);


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
        public ActionResult ConsultarAsigMateri()
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                if (Session["User"] != null)
                {

                    TrabajoModel ConsultarAsigMateri = new TrabajoModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    var respuesta = ConsultarAsigMateri.ConsultarAsigMateri(token);


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
        public ActionResult AsignarTrabajoFrm()
        {

            TrabajoModel modelo = new TrabajoModel();
            try
            {

                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                    TrabajoModel modelos = new TrabajoModel();
                    ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                    TrabajoModel modeloza = new TrabajoModel();
                    ViewBag.listaprodu = modeloza.ConsultarProductoCombo();
                    TrabajoModel modelozas = new TrabajoModel();
                    ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                }
                return View("Asignar");

            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        //asignar materiales
        [HttpGet]
        public ActionResult AsignarMaterialesFrm()
        {

            TrabajoModel modelo = new TrabajoModel();
            try
            {

                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;
                
                    TrabajoModel modeloza = new TrabajoModel();
                    ViewBag.listaprodu = modeloza.ConsultarProductoCombo();
                    TrabajoModel modelozas = new TrabajoModel();
                    ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                }
                return View("Asignar");

            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        //guardar materiales
        [HttpPost]
        public ActionResult AsignarMateriales(MaterialesOBJ trabajo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];

            int Cantidad = trabajo.Cantidad; 
            int idProducto = trabajo.IdProducto;
            try
            {
                TrabajoModel modelo = new TrabajoModel();

                var respuestaV = modelo.VerifiStock(Cantidad,idProducto);
                ViewBag.listaPermisos = user.listaPermisos;


                //validacion
                if (ModelState.IsValid)
                {

                 
                    if (respuestaV == false)
                    {
                        TrabajoModel modelao = new TrabajoModel();
                        ViewBag.listaPermisos = user.listaPermisos;

                        ViewBag.MjsCrearMate = "Mensaje";

                        //TrabajoModel modeloza = new TrabajoModel();
                        //ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();
                        return View("Asignar");

                    }
                    else
                    {
                        
                        TrabajoModel modelao = new TrabajoModel();
                        ViewBag.listaPermisos = user.listaPermisos;
                        modelao.RegistrarMaterial(trabajo);
                        ViewBag.MjsCreadoMate = "Mensaje";
                        //TrabajoModel modeloza = new TrabajoModel();
                        //ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                        return View("Asignar");
                    }

                }


                return View(trabajo);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }


        //guardar trabajos
        [HttpPost]
        public ActionResult RegistrarTrabajo(TrabajoObj trabajo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];

            int idUsuario = trabajo.IdUsuario; //variables para la validación de existencia
            DateTime fecha = trabajo.Fecha;
            int idTrabajo = trabajo.IdTrabajo;


            try
            {
                TrabajoModel modelo = new TrabajoModel();
               
                var respuestaV = modelo.VerifiFecha(idUsuario, fecha);//metodo de existencia
                ViewBag.listaPermisos = user.listaPermisos;


                //validacion
                if (ModelState.IsValid)
                    {

                        //crea un empleado nuevo
                        if (respuestaV == false)
                        {
                          
                        ViewBag.listaPermisos = user.listaPermisos;
                  
                        ViewBag.MjsCrear = "Mensaje";
                        //TrabajoModel modelaos = new TrabajoModel();
                        //ViewBag.listaEstados = modelaos.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();
                        return View("Asignar");

                        }
                        else
                        {
                            //crea un empleado nuevo

                            TrabajoModel modelao = new TrabajoModel();
                            ViewBag.listaPermisos = user.listaPermisos;
                            modelao.RegistrarTrabajo(trabajo);
                            ViewBag.MjsCreado = "Mensaje";
                        //TrabajoModel modelaos = new TrabajoModel();
              
                        //ViewBag.listaEstados = modelaos.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                        return View("Asignar");
                        }

                    }
                
               
                return View(trabajo);
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }



    }





}
