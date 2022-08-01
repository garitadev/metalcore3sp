using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.DAL.Models
{
    public class InventarioDAL
    {
        public List<ProductosObj> ObtenerProveedor()
        {


            List<ProductosObj> dato = new List<ProductosObj>();

            using (var contex = new DD_METALCOREEntities())

            {
                try
                {
                    var provedores = (from x in contex.Proveedor
                                      orderby x.nombre
                                      select x).ToList();

                    foreach (var item in provedores)
                    {
                        dato.Add(new ProductosObj
                        {
                            PROVEEDOR = item.nombre

                        });

                    }
                    return dato;

                }

                catch (Exception ex)
                {

                    var error = ex.ToString();

                    contex.Dispose();
                    throw ex;
                }
            }

        }
        public ProductosObj RegistrarProductos(ProductosObj producto)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    Productos obj = new Productos();
                    obj.idProveedor = 1;

                    obj.nombre = producto.NOMBRE;
                    obj.marca = producto.MARCA;
                    obj.cantidad = producto.CANTIDAD;
                    obj.precio = producto.PRECIO;

                    context.Productos.Add(obj);
                    context.SaveChanges();
                    return producto;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();
                    return null;
                    throw ex;
                }
                finally
                {
                    context.Dispose();

                }
            }
        }
        //Consultar  registros en especifico
        public ProductosObj ConsultarProducto(int idProducto)
        {
            ProductosObj resultado = new ProductosObj();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Productos
                                 where x.idProducto == idProducto
                                 select x).FirstOrDefault();
                    resultado.IDPRODUCTO = datos.idProducto;
                    resultado.IDPROVEEDOR = datos.idProveedor;
                    resultado.NOMBRE = datos.nombre;
                    resultado.MARCA = datos.marca;
                    resultado.CANTIDAD = (int)datos.cantidad;
                    resultado.PRECIO = datos.precio;


                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                   // modeloBitacora.RegistrarError(error);
                    context.Dispose();
                    throw ex;
                }
            }
        }
        public List<ProductosObj> ConsultarProductos()
        {

            List<ProductosObj> resultado = new List<ProductosObj>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Productos
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        var nombreProveedor = (from x in context.Proveedor
                                               where x.idProveedor == item.idProveedor
                                               select x).FirstOrDefault();
                        resultado.Add(new ProductosObj
                        {
                            IDPRODUCTO = item.idProducto,
                            IDPROVEEDOR = item.idProveedor,
                            NOMBRE = item.nombre,
                            MARCA = item.marca,
                            CANTIDAD = (int)item.cantidad,
                            PRECIO = item.precio,
                            PROVEEDOR = nombreProveedor.nombre.ToString(),
                        });

                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    context.Dispose();

                    throw ex;
                }
            }
        }


        public ProductosObj ActualizarProductos(ProductosObj producto)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Productos
                                     where x.idProducto == producto.IDPRODUCTO
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        resultado.idProveedor = producto.IDPROVEEDOR;
                        resultado.nombre = producto.NOMBRE;
                        resultado.marca = producto.MARCA;
                        resultado.cantidad = producto.CANTIDAD;
                        resultado.precio = producto.PRECIO;


                        context.SaveChanges();
                        return producto;
                    }
                    return producto;


                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    return null;
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        public ProductosObj BorrarProductos(int idProducto)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Productos
                                     where x.idProducto == idProducto
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        context.Productos.Remove(resultado);
                        context.SaveChanges();

                        return new ProductosObj();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        //Metodos para combobox
        public List<SelectListItem> ConsultarProductosCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Productos
                                 select x).ToList();

                    resultado.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = "Seleccione"
                    });

                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idProducto.ToString(),
                            Text = item.nombre,

                        });
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();

                    throw ex;
                }
            }
        }
    }
}
