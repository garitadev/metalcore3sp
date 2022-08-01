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

        public List<TrabajoObj> VerTrabajos()
        {
            try
            {
                List<TrabajoObj> objetos = new List<TrabajoObj>();

                using (var client = new HttpClient())
                {
                    ruta += "VerTrabajos";

                    //Obtiene la info de la api
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;


                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        objetos = JsonConvert.DeserializeObject<List<TrabajoObj>>(datos);

                        return (objetos);
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
        public List<SelectListItem> ConsultarEstadosCombo()
        {
            try
            {
                List<SelectListItem> listaEstado = new List<SelectListItem>();
                using (var client = new HttpClient())
                {
                    //no sé por qué pero sobre carga la ruta con la anterior
                    ruta = "https://localhost:44340/api/ConsultarEstadoCombo";
                    //  ruta += "ConsultarProveedoresCombo"; si lo dejo así se concatena con la ruta anterior
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaEstado = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);
                    }
                }
                return listaEstado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TrabajoObj> ConsultarEstadoEspecifico(int idEstado)
        {
            try
            {
                List<TrabajoObj> estado = new List<TrabajoObj>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarEstadoEspecifico?idEstado=" + idEstado;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        estado = JsonConvert.DeserializeObject<List<TrabajoObj>>(datos);
                    }
                }
                return estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////

        public MaterialesOBJ ConsultarMaterialEspecifico(int idMaterial)
        {
            try
            {
                MaterialesOBJ producto = new MaterialesOBJ();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarMaterialEspecifico?idMaterial=" + idMaterial;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        producto = JsonConvert.DeserializeObject<MaterialesOBJ>(datos);
                    }
                }
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActuaTrabajo(TrabajoObj Actua)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "Trabajo/ActuaTrabajo";

                    //Crea el json con el trabajo recibido 
                    JsonContent contenido = JsonContent.Create(Actua);


                    HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActuaMaterial(MaterialesOBJ Actua)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "Trabajo/ActuaMaterial";

                    //Crea el json con el trabajo recibido 
                    JsonContent contenido = JsonContent.Create(Actua);


                    HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //stocks
        public bool VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    ruta += "VerifiStockActua?Cantidad=" + Cantidad + "&idProducto=" + idProducto + "&idMaterial=" + idMaterial;
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

        //borrar trabajo-----------------------------

        public bool BorrarTrabajo(int idTrabajo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "BorrarTrabajo?idTrabajo=" + idTrabajo;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool BorrarMaterial(int idMaterial)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "BorrarMaterial?idMaterial=" + idMaterial;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //verificar que no haya materiales relacionados a trabajos
        public bool VerifiExisTrabajo(int idTrabajo)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    ruta += "VerifiExisTrabajo?idTrabajo=" + idTrabajo;
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

        public MaterialesOBJ EncontrarPrecio(int idProducto)
        {
            try
            {
                MaterialesOBJ producto = new MaterialesOBJ();

                using (var client = new HttpClient())
                {
                    ruta += "EncontrarPrecio?idProducto=" + idProducto;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        producto = JsonConvert.DeserializeObject<MaterialesOBJ>(datos);
                    }
                }
                return producto;
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


        public List<SelectListItem> ProductoPrecio()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaTrabajos = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ProductoPrecio";
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

        //modificar

        public TrabajoObj ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            try
            {
                TrabajoObj producto = new TrabajoObj();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarUTrabajoEspecifico?idTrabajo=" + idTrabajo;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        producto = JsonConvert.DeserializeObject<TrabajoObj>(datos);
                    }
                }
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}