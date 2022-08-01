using Newtonsoft.Json;
//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using MetalCore.BLL.Models;

namespace SB_Admin.Models
{
    public class UsuarioModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();


        public UsuarioObj ValidarCrenciales(UsuarioObj usuario)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            var respuesta = BLL.ValidarCredenciales(usuario);
            return (respuesta);
        }

        //verifica la existencia del usuario
        public bool VerifiExistencia(string Email, string Cedula)
        {
            try
            {
                UsuarioObj producto = new UsuarioObj();

                using (var client = new HttpClient())
                {

                    ruta += "VerifiExistencia?email=" + Email + "&cedula=" + Cedula;
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

        //registrar usuario

        public string RegistrarUsuario(UsuarioObj Usuario, string token)
        {
            using (var client = new HttpClient())
            {
                ruta += "RegistrarUsuario";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                JsonContent contenido = JsonContent.Create(Usuario);


                HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    return string.Empty;
                }
                else
                {
                    return "No se puede crear el registro";
                }
            }
        }

        public List<UsuarioObj> ConsultarTodosUsuarios(string token)
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<UsuarioObj> listaUsuarios = new List<UsuarioObj>();


                using (var client = new HttpClient())
                {
                    ruta += "ConsultarTodosUsuarios";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioObj>>(datos);

                    }
                }
                return listaUsuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //consulta un usuario  en especifico

        public UsuarioObj ConsultarUsuarioEspecifico(int idUsuario)
        {
            try
            {
                UsuarioObj producto = new UsuarioObj();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarUsuarioEspecifico?idUsuario=" + idUsuario;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        producto = JsonConvert.DeserializeObject<UsuarioObj>(datos);
                    }
                }
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //hace la consulta a los roles que se encuentran en la BD
        public List<SelectListItem> ConsultarRolesCombo()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaRoles = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta = "https://localhost:44340/api/ConsultarRolesCombo";
                   
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaRoles = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaRoles;
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
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaEstados = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarEstadosCombo";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaEstados = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaEstados;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ActuaUsuario(UsuarioObj Actua)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "Usuario/ActualizarUsuario";

                    //Crea el json con el Usuario recibido 
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

        public bool ValidarExistenciaEmail(RecoveryPassword obj)
        {
            try
            {
                UsuarioObj producto = new UsuarioObj();

                using (var client = new HttpClient())
                {
                    ruta += "ValidarExistenciaEmail?email=" + obj.Email;
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

        public RecoveryPassword GenerarTokenPassword(RecoveryPassword obj)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    ruta = "https://localhost:44340/api/GenerarTokenPassword";

                    JsonContent contenido = JsonContent.Create(obj);

                    HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return (obj);
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

        public RecoveryPassword RestablecerPassword(RecoveryPassword obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "RestablecerPassword";

                    JsonContent contenido = JsonContent.Create(obj);
                    HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;


                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        return (obj);
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