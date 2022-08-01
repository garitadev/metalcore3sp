using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SB_Admin.Models
{
    public class DashboardModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        //Obtiene total de productos
        public DashboardObj TotalProductos()
        {
            try
            {
                DashboardObj objeto = new DashboardObj();

                using (var client = new HttpClient())
                {
                    ruta += "TotalProductos";

                    //Obtiene la info de la api
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;


                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        objeto = JsonConvert.DeserializeObject<DashboardObj>(datos);

                        return (objeto);
                    }
                    else
                    {
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}