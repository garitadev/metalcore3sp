using Newtonsoft.Json;
using SB_Admin.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]

    //Full
    public class AuthorizeUser : AuthorizeAttribute
    {
        private int idOperacion; // entero

        //se verifica si tiene permisos
        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }
        //hacemos la sobre carga
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //hacemos el llamado al api
            string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

            try
            {
                //Se valida la session
                if (HttpContext.Current.Session["User"] != null)
                {
                    UsuarioObj usuario = HttpContext.Current.Session["User"] as UsuarioObj;

                    using (var client = new HttpClient())
                    {
                        ruta += "ConsultarRol?idRol=" + usuario.idRol + "&idOperacion=" + idOperacion; //se va al api
                        HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                        if (respuesta.IsSuccessStatusCode) //se verifica si hay exito
                        {
                            var datos = respuesta.Content.ReadAsStringAsync().Result;
                            usuario = JsonConvert.DeserializeObject<UsuarioObj>(datos);



                            if (usuario == null) //se valida si datos enviados cumplen
                            {
                                filterContext.Result = new RedirectResult("/Home/SinPermiso");

                            }

                        }
                    }
                }

                

            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("/Home/SinPermiso");

            }

        }

    }
}