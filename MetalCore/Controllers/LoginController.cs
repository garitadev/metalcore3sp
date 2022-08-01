//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using SB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SB_Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard", "Home");


        }

        [HttpPost]
        public ActionResult Validar(UsuarioObj usuario)
        {
            string email = usuario.email;
            string clave = usuario.password;
            UsuarioModel modelo = new UsuarioModel();
            var respuesta = modelo.ValidarCrenciales(usuario);

            if (respuesta != null)
            {
                FormsAuthentication.SetAuthCookie(respuesta.email, false);

                //Se crea una nueva session (almacena toda la infomacion del usuario)
                Session["User"] = respuesta;


                return RedirectToAction("Dashboard", "Home" );

            }
            else
            {
                ViewBag.MsjError = "Credenciales Invalidas";
                return View("Login");
            }

        }


        [HttpGet]
        //Cuando se recibe un correo para ingresar el nuevo password
        public ActionResult GenerarTokenPassword()
        {

            return View();
        }

        [HttpPost]
        //Cuando se recibe un correo para ingresar el nuevo password
        public ActionResult GenerarTokenPassword(RecoveryPassword modelo)
        {
            UsuarioModel usuarioModel = new UsuarioModel();

            //Se valida que el correo ingreado exista en los registros de la bd
            if (usuarioModel.ValidarExistenciaEmail(modelo))
            {
                usuarioModel.GenerarTokenPassword(modelo);
            }
            else
            {
                ViewBag.MjsEmail = "El email ingresado no coincide con nuestro registros";
                return View();

            }

            ViewBag.MjsEmailEnviado = "Se le ha envidado un correo para cambiar su contraseña";
            return View("Login");

        }


        [HttpGet]
        public ActionResult RestablecerPassword(string token)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            RecoveryPassword modelo = new RecoveryPassword();
            modelo.token = token;

            if (usuarioModel.RestablecerPassword(modelo) ==null)
            {
                ViewBag.Error = "Token Expirado";
                return View("Login");
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult RestablecerPassword(RecoveryPassword model)
        {
            UsuarioModel usuarioModel = new UsuarioModel();

            if (usuarioModel.RestablecerPassword(model) != null)
            {
                ViewBag.Message = "Contraseña moficada con éxito";
                return View("Login");
            }

            return View(model);
        }
    }
}