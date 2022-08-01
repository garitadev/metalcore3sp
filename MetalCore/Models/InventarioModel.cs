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
    public class InventarioModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        //Obtiene la lista de proveedores
        public List<ProductosObj> ObtenerProveedor()
        {
            try
            {
                List<ProductosObj> objetos = new List<ProductosObj>();

                using (var client = new HttpClient())
                {
                    ruta += "ObtenerProveedor";

                    //Obtiene la info de la api
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;


                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        objetos = JsonConvert.DeserializeObject<List<ProductosObj>>(datos);

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

        //Crea los objetos para obtenerlos en la vista
        public List<SelectListItem> CosultarProveedores()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            InventarioModel model = new InventarioModel();
            var datos = model.ObtenerProveedor();

            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Text = item.PROVEEDOR });
            }
            return list;
        }










        public List<ProductosObj> ConsultarTodosProductos(string token)
        {
            try
            {
                List<ProductosObj> listaProductos = new List<ProductosObj>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarInventario";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaProductos = JsonConvert.DeserializeObject<List<ProductosObj>>(datos);
                    }
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Operaciones CRUD Inventario
        public string CrearProdcuto(ProductosObj producto)
        {
            using (var client = new HttpClient())
            {
                ruta += "CrearProducto";
                //Crea el json con el producto recibido 
                JsonContent contenido = JsonContent.Create(producto);

                //Consume el API y se envía el json por parametros
                HttpResponseMessage respuesta = client.PostAsync(ruta, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    return string.Empty;
                }
                else
                {
                    return "No se ha podido registrar el producto";
                }
            }
        }


        public bool ModificarProducto(ProductosObj producto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "ActualizarProducto";
                    //Crea el json con el producto recibido 
                    JsonContent contenido = JsonContent.Create(producto);


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

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    ruta += "BorrarProductos?idProducto=" + idProducto;
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


        //Consultar por un registro en especifico
        public ProductosObj ConsultarProductoEspecifico(int idProducto)
        {
            try
            {
                ProductosObj producto = new ProductosObj();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarProductoEspecifico?idProducto=" + idProducto;
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        producto = JsonConvert.DeserializeObject<ProductosObj>(datos);
                    }
                }
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Metodos para llenar combobox
        public List<SelectListItem> ConsultarTodosProductosCombo()
        {
            try
            {
                List<SelectListItem> listaProductos = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ConsultarInventarioCB";
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaProductos = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);
                    }
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}