using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.DAL.Models
{
    public class TrabajoDAL
    {

        public List<TrabajoObj> VerTrabajos()
        {

            List<TrabajoObj> resultado = new List<TrabajoObj>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Trabajo
                                 join e in context.Empleado on x.idUsuario equals e.idUsuario
                                 join s in context.EstadoTrabajo on x.idEstadoTrabajo equals s.idEstado
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        var trabajo = (from x in context.Trabajo
                                       where x.idTrabajo == item.idTrabajo
                                       select x).FirstOrDefault();
                        resultado.Add(new TrabajoObj
                        {
                            IdTrabajo = item.idTrabajo,
                            IdUsuario = (int)item.idUsuario,
                            IdEstadoTrabajo = (int)item.idEstadoTrabajo,
                            Descripcion = item.descripcion,
                            Direccion = item.direccion,
                            Fecha = item.fecha.Value,
                            NombreCliente = item.nombreCliente,
                            TelefonoCliente = item.telefonoCliente,
                            Estado = item.EstadoTrabajo.estado,
                            Nombre = item.Empleado.nombre


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

        //Consulta las lista de los trabajos dependiendo de la opcion del usuario
        public List<TrabajoObj> ConsultarEstadoEspecifico(int idEstado)
        {
            TrabajoObj resultado = new TrabajoObj();

            List<TrabajoObj> listaTrabajos = new List<TrabajoObj>();


            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Trabajo
                                 where x.idEstadoTrabajo == idEstado
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        var nombreEmpleado = (from x in context.Empleado where x.idUsuario == item.idUsuario select x).FirstOrDefault();
                        var estadoTrabajo = (from x in context.EstadoTrabajo where x.idEstado == item.idEstadoTrabajo select x).FirstOrDefault();


                        listaTrabajos.Add(new TrabajoObj
                        {
                            IdTrabajo = item.idTrabajo,
                            Nombre = nombreEmpleado.nombre,
                            Estado = estadoTrabajo.estado

                        });

                    }
                    context.Dispose();
                    return listaTrabajos;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        //Obtiene los estados par el combo
        public List<SelectListItem> ConsultarEstadosCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.EstadoTrabajo
                                 select x).ToList();



                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idEstado.ToString(),
                            Text = item.estado

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




        ////////////////////////////////////////////////////////




        //actualizar informacion-------------------------------
        public TrabajoObj ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            TrabajoObj resultado = new TrabajoObj();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Trabajo
                                 where x.idTrabajo == idTrabajo
                                 select x).FirstOrDefault();
                    resultado.IdTrabajo = datos.idTrabajo;
                    resultado.IdUsuario = datos.idUsuario.Value;
                    resultado.IdEstadoTrabajo = datos.idEstadoTrabajo.Value;
                    resultado.Descripcion = datos.descripcion;
                    resultado.Direccion = datos.direccion;
                    resultado.Fecha = datos.fecha.Value;
                    resultado.NombreCliente = datos.nombreCliente;
                    resultado.TelefonoCliente = datos.telefonoCliente;
                    //llamado de los roles y de los estados
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }
        //materiales--------------------------------
        public MaterialesOBJ ConsultarMaterialEspecifico(int idMaterial)
        {
            MaterialesOBJ resultado = new MaterialesOBJ();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.MaterialesTrabajo
                                 where x.idMaterial == idMaterial
                                 select x).FirstOrDefault();
                    resultado.IdMaterial = datos.idMaterial;
                    resultado.IdTrabajo = datos.idTrabajo.Value;
                    resultado.IdProducto = datos.idProducto.Value;
                    resultado.Cantidad = datos.cantidad.Value;
                    resultado.Precio = datos.precio.Value;
                    //llamado de los roles y de los estados
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }
        public void ActuaTrabajo(TrabajoObj Actua)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Trabajo
                                     where x.idTrabajo == Actua.IdTrabajo
                                     select x).FirstOrDefault();
                    if (resultado != null)
                    {
                        resultado.idUsuario = Actua.IdUsuario;
                        resultado.idEstadoTrabajo = Actua.IdEstadoTrabajo;
                        resultado.descripcion = Actua.Descripcion;
                        resultado.direccion = Actua.Direccion;
                        resultado.fecha = Actua.Fecha;
                        resultado.nombreCliente = Actua.NombreCliente;
                        resultado.telefonoCliente = Actua.TelefonoCliente;
                        context.SaveChanges();
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        public void ActuaMaterial(MaterialesOBJ Actua)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.MaterialesTrabajo
                                     where x.idMaterial == Actua.IdMaterial
                                     select x).FirstOrDefault();
                    if (resultado != null)
                    {

                        resultado.idTrabajo = Actua.IdTrabajo;
                        resultado.idProducto = Actua.IdProducto;
                        resultado.cantidad = Actua.Cantidad;
                        resultado.precio = Actua.Precio;
                        context.SaveChanges();
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        //verifica el stock
        public bool VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {

            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuestaV = (from x in contex.MaterialesTrabajo
                                      where x.idMaterial == idMaterial
                                      select x);
                    foreach (var Stocks in respuestaV)
                    {
                        if (Stocks.cantidad == Cantidad)
                        {
                            return true;
                        }
                        else
                        {
                            var respuesta = (from x in contex.Productos
                                             where x.idProducto == idProducto
                                             select x);
                            foreach (var Stock in respuesta)
                            {
                                if (Stock.cantidad < Cantidad)
                                {
                                    return false;
                                }
                                else
                                {
                                    Stock.idProducto = idProducto;
                                    Stock.cantidad = Stock.cantidad - Cantidad;
                                    Stocks.cantidad = Cantidad;
                                }
                            }
                        }
                    }
                    contex.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }


        //Eliminar trabajo-------------------------------------------


        public MaterialesOBJ BorrarTrabajo(int idTrabajo)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Trabajo
                                     where x.idTrabajo == idTrabajo
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        context.Trabajo.Remove(resultado);
                        context.SaveChanges();

                        return new MaterialesOBJ();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }

        public MaterialesOBJ BorrarMaterial(int idMaterial)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.MaterialesTrabajo
                                     where x.idMaterial == idMaterial
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        context.MaterialesTrabajo.Remove(resultado);
                        context.SaveChanges();

                        return new MaterialesOBJ();
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }


        //validar que no haya material con trabajo relacionado
        public bool VerifiExisTrabajo(int idTrabajo)
        {
            MaterialesOBJ usuario = new MaterialesOBJ();
            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuesta = (from x in contex.MaterialesTrabajo
                                     where x.idTrabajo == idTrabajo
                                     select x).FirstOrDefault();

                    if (respuesta != null)
                    {
                        return false;

                    }
                    else
                    {
                        contex.Dispose();
                        return true;

                    }

                }
                catch (Exception ex)
                {

                    contex.Dispose();
                    throw ex;
                }
            }

        }

        public List<TrabajoObj> ConsultarTrabajos()
        {
            List<TrabajoObj> listaTrabajos = new List<TrabajoObj>();


            using (var contex = new DD_METALCOREEntities())
            {
                try
                {


                    //Se guardan los datos de la consulta
                    var datos = (from x in contex.Trabajo
                                 select x).ToList();

                    //Se almacenan los datos de la consulta en listaTrabajos
                    foreach (var item in datos)
                    {
                        var nombreUsuario = (from x in contex.Empleado where x.idUsuario == item.idUsuario select x).FirstOrDefault();
                        var estado = (from x in contex.EstadoTrabajo where x.idEstado == item.idEstadoTrabajo select x).FirstOrDefault();
                        listaTrabajos.Add(new TrabajoObj
                        {
                            IdTrabajo = item.idTrabajo,
                            Direccion = item.direccion,
                            Descripcion = item.descripcion,
                            Fecha = item.fecha.Value,
                            NombreCliente = item.nombreCliente,
                            TelefonoCliente = item.telefonoCliente,
                            NombreUsuario = nombreUsuario.nombre.ToString(),
                            Estado = estado.estado.ToString(),
                        });

                    }
                    contex.Dispose();
                    return listaTrabajos;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }

        public List<MaterialesOBJ> ConsultarAsigMateri()
        {
            List<MaterialesOBJ> listaMateriales = new List<MaterialesOBJ>();


            using (var contex = new DD_METALCOREEntities())
            {
                try
                {


                    //Se guardan los datos de la consulta
                    var datos = (from x in contex.MaterialesTrabajo
                                 select x).ToList();


                    foreach (var item in datos)
                    {
                        var nombreTrabajo = (from x in contex.Trabajo where x.idTrabajo == item.idTrabajo select x).FirstOrDefault();
                        var produ = (from x in contex.Productos where x.idProducto == item.idProducto select x).FirstOrDefault();
                        listaMateriales.Add(new MaterialesOBJ
                        {
                            IdMaterial = item.idMaterial,
                            Fecha = nombreTrabajo.fecha.Value,
                            NombreUsuario = nombreTrabajo.nombreCliente,
                            NombrePro = produ.nombre.ToString(),
                            Cantidad = item.cantidad.Value,
                            Precio = item.precio.Value,
                        });

                    }
                    contex.Dispose();
                    return listaMateriales;
                }
                catch (Exception ex)
                {
                    contex.Dispose();
                    throw ex;
                }
            }
        }

        public List<SelectListItem> ConsultarTrabajosCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Trabajo
                                 select x).ToList();

                    resultado.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = "Seleccione"
                    });

                    foreach (var item in datos)
                    {
                        var desc = item.fecha.Value;
                        var cliente = item.nombreCliente;
                        var detall = desc.ToShortDateString() + " - " + cliente;
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idTrabajo.ToString(),
                            Text = detall

                        });
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();

                    throw ex;
                }
            }
        }

        //consultar precio del producto

        public MaterialesOBJ EncontrarPrecio(int idProducto)
        {
            MaterialesOBJ resultado = new MaterialesOBJ();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Productos
                                 where x.idProducto == idProducto
                                 select x).FirstOrDefault();
                    if (datos != null)
                    {
                        resultado.IdProducto = datos.idProducto;
                        resultado.Precio = decimal.Parse(datos.precio);
                    }
                    else
                    {
                        resultado.IdProducto = 0;
                        resultado.Precio = 0;
                    }



                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();
                    throw ex;
                }
            }
        }

        //metodo para verificar la fecha de asignacion 
        public bool VerifiFecha(int idUsuario, DateTime fecha)
        {

            TrabajoObj usuario = new TrabajoObj();
            using (var contex = new DD_METALCOREEntities())
            {
                //var f=   Convert.ToDateTime(fecha).ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    var DateAndTime = DateTime.Now.Date;
                    var respuesta = (from x in contex.Trabajo
                                     where x.idUsuario == idUsuario

                                     select x);

                    foreach (var customerGroup in respuesta)
                    {
                        if (customerGroup.fecha == fecha)
                        {

                            return false;

                        }
                        else if (fecha < DateAndTime)
                        {

                            return false;
                        }

                    }
                    contex.Dispose();
                    return true;

                }
                catch (Exception ex)
                {

                    contex.Dispose();
                    throw ex;
                }
            }

        }

        //verifica el stock
        public bool VerifiStock(int Cantidad, int idProducto)
        {


            using (var contex = new DD_METALCOREEntities())
            {

                try
                {
                    var respuesta = (from x in contex.Productos
                                     where x.idProducto == idProducto
                                     select x);

                    foreach (var Stocks in respuesta)
                    {
                        if (Stocks.cantidad < Cantidad)
                        {

                            return false;

                        }
                        else
                        {
                            Stocks.idProducto = idProducto;
                            Stocks.cantidad = Stocks.cantidad - Cantidad;

                        }

                    }
                    contex.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {

                    contex.Dispose();
                    throw ex;
                }
            }

        }
        //registrar el material

        public MaterialesOBJ RegistrarMaterial(MaterialesOBJ datosTrabajo)
        {

            using (var bd = new DD_METALCOREEntities())
            {
                try
                {
                    MaterialesTrabajo trabajo = new MaterialesTrabajo();
                    trabajo.idMaterial = datosTrabajo.IdMaterial;
                    trabajo.idTrabajo = datosTrabajo.IdTrabajo;
                    trabajo.idProducto = datosTrabajo.IdProducto;
                    trabajo.cantidad = datosTrabajo.Cantidad;
                    trabajo.precio = datosTrabajo.Precio;


                    bd.MaterialesTrabajo.Add(trabajo);
                    bd.SaveChanges();

                    return datosTrabajo;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    bd.Dispose();

                }
            }
        }

        //registrar

        public TrabajoObj RegistrarTrabajo(TrabajoObj datosTrabajo)
        {

            using (var bd = new DD_METALCOREEntities())
            {
                try
                {
                    Trabajo trabajo = new Trabajo();
                    trabajo.idUsuario = datosTrabajo.IdUsuario;
                    trabajo.idEstadoTrabajo = 1;
                    trabajo.descripcion = datosTrabajo.Descripcion;
                    trabajo.direccion = datosTrabajo.Direccion;
                    trabajo.fecha = datosTrabajo.Fecha;
                    trabajo.nombreCliente = datosTrabajo.NombreCliente;
                    trabajo.telefonoCliente = datosTrabajo.TelefonoCliente;

                    bd.Trabajo.Add(trabajo);
                    bd.SaveChanges();

                    return datosTrabajo;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    bd.Dispose();

                }
            }
        }


        //Metodos para combobox
        public List<SelectListItem> ConsultarEstadoTrabajosCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.EstadoTrabajo
                                 select x).ToList();



                    foreach (var item in datos)
                    {

                        resultado.Add(new SelectListItem
                        {
                            Value = item.idEstado.ToString(),
                            Text = item.estado,

                        });
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();

                    throw ex;
                }
            }
        }

        public List<SelectListItem> ConsultarProductoCombo()
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
                    context.Dispose();

                    throw ex;
                }
            }
        }

        public List<SelectListItem> ConsultarEmpleadoCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Empleado
                                 select x).ToList();



                    foreach (var item in datos)
                    {

                        resultado.Add(new SelectListItem
                        {
                            Value = item.idUsuario.ToString(),
                            Text = item.nombre,

                        });
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    context.Dispose();

                    throw ex;
                }
            }
        }


    }
}
