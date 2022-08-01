using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.DAL.Passwords
{
    public class RecoveryPasswordDAL
    {
        public UsuarioObj RegistrarTokenPassword(string email, string token)
        {
           
            UsuarioObj usuario = new UsuarioObj();

            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuesta = (from x in contex.Empleado
                                     where x.email == email
                                     select x).FirstOrDefault();

                    if (respuesta != null)
                    {
                        //Se guarda el token en la base de datos
                        respuesta.token_recovery = token;
                        contex.SaveChanges();

                        //envia enmail

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    contex.Dispose();
                }

            }
        }


        public UsuarioObj RestablecerPassword(RecoveryPassword obj)
        {
            UsuarioObj usuario = new UsuarioObj();

            using (var contex = new DD_METALCOREEntities())
            {
                try
                {
                    var respuesta = (from x in contex.Empleado
                                     where x.token_recovery == obj.token
                                     select x).FirstOrDefault();

                    if (respuesta != null && obj.Password != null)
                    {
                        respuesta.password = obj.Password;
                        respuesta.token_recovery = null;

                        contex.SaveChanges();


                    }
                    if (respuesta == null)
                    {
                        return null;
                    }
                    else
                    {
                        return usuario;
                    }


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    contex.Dispose();
                }
            }
        }
    }
}
