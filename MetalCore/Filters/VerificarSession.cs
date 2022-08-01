using SB_Admin.Controllers;
//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Filters
{
    public class VerificarSession : ActionFilterAttribute
    {
        //Verifica que haya una sesion creada, si no es asi le niega el acceso al usuario de igual manera por url
        private UsuarioObj oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (UsuarioObj)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }

                }
            }
            catch (Exception)
            {

                filterContext.Result = new RedirectResult("~/Login/Login");
            }

        }
    }
}