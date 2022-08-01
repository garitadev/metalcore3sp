using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Models
{
    public class TrabajoModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();
        public List<TrabajoObj> Consultar(string token)
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<TrabajoObj> listaTrabajos = new List<TrabajoObj>();


                using (var client = new HttpClient())
                {
                    ruta += "ConsultarTrabajos";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaTrabajos = JsonConvert.DeserializeObject<List<TrabajoObj>>(datos);

                    }
                }
                return listaTrabajos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //consultar materiale asignados
        public List<MaterialesOBJ> ConsultarAsigMateri(string token)
        {
            try
            {
                //Se crea una lista para almacenar los materiales asignados
                List<MaterialesOBJ> listaMateriales = new List<MaterialesOBJ>();


                using (var client = new HttpClient())
                {
                    ruta += "ConsultarAsigMateri";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaMateriales = JsonConvert.DeserializeObject<List<MaterialesOBJ>>(datos);

                    }
                }
                return listaMateriales;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool VerifiFecha(int idUsuario, DateTime fecha)
        {
            try
            {
                TrabajoObj producto = new TrabajoObj();
               fecha.ToString("yyyy/MM/dd");
  

                using (var client = new HttpClient())
                {

                    ruta += "VerifiFechas?idUsuario=" + idUsuario + "&fecha=" + fecha.ToString("yyyy/MM/dd");
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
               
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //stocks
        public bool VerifiStock(int Cantidad, int idProducto)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    ruta += "VerifiStock?Cantidad=" + Cantidad + "&idProducto=" + idProducto;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> ConsultarEstadoTrabajosCombo()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaTrabajos = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarEstadoTrabajosCombo";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaTrabajos = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaTrabajos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SelectListItem> ConsultarProductoCombo()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaprodu = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarProductoCombo";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaprodu = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaprodu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<SelectListItem> ConsultarEmpleadoCombo()
        {
            try
            {
                //Se crea una lista para almacenar los empleados
                List<SelectListItem> listaUsuarios = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarEmpleadoCombo";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaUsuarios = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaUsuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Metodos CRUD Trabajos
        public string RegistrarTrabajo(TrabajoObj trabajo)
        {
            using (var client = new HttpClient())
            {
                ruta += "RegistrarTrabajo";

                //Crea el json con los datos del trabajo recibido 
                JsonContent contenido = JsonContent.Create(trabajo);

                //Se le envia el json al api para que se consuma
                HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    return string.Empty;

                }
                else
                {
                    return "no";
                }
            }
        }

        //prueba


        //Metodos para combo box

        public List<SelectListItem> ConsultarTrabajosCombo()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaTrabajos = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarTrabajosCombo";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaTrabajos = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaTrabajos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //registrar material

        public string RegistrarMaterial(MaterialesOBJ trabajo)
        {
            using (var client = new HttpClient())
            {
                ruta += "RegistrarMaterial";

                //Crea el json con los datos del trabajo recibido 
                JsonContent contenido = JsonContent.Create(trabajo);

                //Se le envia el json al api para que se consuma
                HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    return string.Empty;

                }
                else
                {
                    return "no";
                }
            }
        }
    }
}