
using SB_Admin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Controllers
{
    public class ProveedoresController : Controller
    {
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                //ProveedoresModel ConsultaActividadesDisponibles = new ProveedoresModel();
                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    return View("Consultar",user.listaPermisos);
                }
                return View("Consultar");
                
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (Session["User"] != null)
            {
                UsuarioObj user = (UsuarioObj)Session["User"];
                return View(user.listaPermisos);
            }
            return View("Consultar");
        }

        //Modificar 


        


    }

    
}
