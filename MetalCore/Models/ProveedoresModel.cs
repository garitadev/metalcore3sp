using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Models
{
    public class ProveedoresModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        public List<SelectListItem> ConsultarTodosProveedoresCombo()
        {
            try
            {
                List<SelectListItem> listaProveedores = new List<SelectListItem>();
                using (var client = new HttpClient())
                {
                    //no sé por qué pero sobre carga la ruta con la anterior
                    ruta = "https://localhost:44340/api/ConsultarProveedoresCombo";
                    //  ruta += "ConsultarProveedoresCombo"; si lo dejo así se concatena con la ruta anterior
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaProveedores = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);
                    }
                }
                return listaProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}