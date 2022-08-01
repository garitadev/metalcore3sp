using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.DAL.Models
{
    public class UsuarioDAL
    {
        public UsuarioObj ValidarCredenciales(UsuarioObj obj, string epass)
        {
            UsuarioObj usuario = new UsuarioObj();
            List<PermisosObj> listaPermisos = new List<PermisosObj>();


            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuesta = (from x in contex.Empleado
                                     where x.email == obj.email && x.password == epass
                                     select x).FirstOrDefault();


                    //Asigna los permisos correspondientes al usuario logueado
                    if (respuesta != null)
                    {
                        var permisos = (from x in contex.Rol_Operacion
                                        where x.idRol == respuesta.idRol
                                        select x).ToList();
                        usuario.Nombre = respuesta.nombre;
                        usuario.Apellido = respuesta.apellido;
                        usuario.email = respuesta.email;
                        usuario.cedula = respuesta.cedula;
                        usuario.idRol = respuesta.idRol;




                        foreach (var item in permisos)
                        {
                            listaPermisos.Add(new PermisosObj
                            {
                                id = item.id
                            });
                        }
                        usuario.listaPermisos = listaPermisos;
                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    // modeloBitacora.RegistrarError(error);
                    contex.Dispose();
                    throw ex;
                }
            }

        }
        //Procedimientos para la creacion del CRUD del empleado/Usuario



        //metodo para verificar si existe un usuario
        public bool VerifiExistencia(string Email, string Cedula)
        {
            UsuarioObj usuario = new UsuarioObj();
            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuesta = (from x in contex.Empleado
                                     where x.email == Email || x.cedula == Cedula
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

        //consulta combobox roles
        public List<SelectListItem> ConsultarRolesCombo()
        {

            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Rol
                                 select x).ToList();



                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idRol.ToString(),
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

        //consultar combobox estado

        public List<SelectListItem> ConsultarEstadosCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Estado
                                 select x).ToList();



                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idEstado.ToString(),
                            Text = item.Nombre,

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


        //crear un nuevo usuario

        public UsuarioObj RegistrarUsuario(UsuarioObj obj)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    Empleado empleado = new Empleado();
                    empleado.idUsuario = 0;
                    empleado.idRol = obj.idRol;
                    empleado.nombre = obj.Nombre;
                    empleado.apellido = obj.Apellido;
                    empleado.email = obj.email;
                    empleado.cedula = obj.cedula;
                    empleado.password = obj.password;
                    empleado.idEstado = 1;

                    context.Empleado.Add(empleado);
                    context.SaveChanges();

                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    context.Dispose();

                }
            }
        }

        //Actualizar empleado

        public void ActuaUsuario(UsuarioObj Actua)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Empleado
                                     where x.cedula == Actua.cedula
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {

                        resultado.idRol = Actua.idRol;
                        resultado.nombre = Actua.Nombre;
                        resultado.apellido = Actua.Apellido;
                        resultado.email = Actua.email;
                        resultado.idEstado = Actua.idEstado;

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

        public bool ValidarExistenciaEmail(string email)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Empleado
                                 where x.email == email
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        return true;
                    }

                    return false;
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


        public List<UsuarioObj> ConsultarUsuarios()
        {
            List<UsuarioObj> resultado = new List<UsuarioObj>();

            //Se abre la base de datos
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Empleado
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        //Se obtiene el nombre del rol para poder mostrar el nombre
                        var nombreRol = (from x in context.Rol
                                         where x.idRol == item.idRol
                                         select x.nombre).FirstOrDefault();

                        var ESTADO = (from x in context.Estado where x.idEstado == item.idEstado select x).FirstOrDefault();

                        resultado.Add(new UsuarioObj
                        {
                            NombreRol = nombreRol,
                            idUsuario = item.idUsuario,
                            idRol = item.idRol,
                            Nombre = item.nombre,
                            Apellido = item.apellido,
                            email = item.email,
                            cedula = item.cedula,
                            password = item.password,
                            NombreEstado = ESTADO.Nombre
                        });
                    }

                    return resultado;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    context.Dispose();
                }
            }

        }

        //Consultar por un registro en especifico 

        public UsuarioObj ConsultarUsuarioEspecifico(int idUsuario)
        {
            UsuarioObj resultado = new UsuarioObj();

            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Empleado
                                 where x.idUsuario == idUsuario
                                 select x).FirstOrDefault();

                    resultado.idUsuario = datos.idUsuario;
                    resultado.idRol = (int)datos.idRol;
                    resultado.Nombre = datos.nombre;
                    resultado.Apellido = datos.apellido;
                    resultado.email = datos.email;
                    resultado.cedula = datos.cedula;
                    resultado.idEstado = (int)datos.idEstado;

                    //llamado de los roles y de los estados
                    var roles = (from x in context.Rol where x.idRol == resultado.idRol select x).FirstOrDefault();
                    resultado.NombreRol = roles.nombre.ToString();
                    var ESTADO = (from x in context.Estado where x.idEstado == resultado.idEstado select x).FirstOrDefault();
                    resultado.NombreEstado = ESTADO.Nombre.ToString();
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
