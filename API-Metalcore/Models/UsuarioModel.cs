

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetalCore.ETL.Entities;
using MetalCore.DAL;
using MetalCore.BLL.Passwords;
using MetalCore.BLL.Models;
using System.Web.Mvc;

namespace API_Metalcore.Models
{
    public class UsuarioModel
    {
        public List<UsuarioObj> ConsultarUsuarios()
        {
            UsuarioBLL BLL = new UsuarioBLL();

            return (BLL.ConsultarUsuarios());

        }


        public UsuarioObj RegistrarUsuario(UsuarioObj obj)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            var respuesta = BLL.RegistrarUsuario(obj);
            return (respuesta);
        }

        public void ActuaUsuario(UsuarioObj obj)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            BLL.ActuaUsuario(obj);
         
        }

        public List<SelectListItem> ConsultarRolesCombo()
        {
            UsuarioBLL BLL = new UsuarioBLL();
            return (BLL.ConsultarRolesCombo());
            //return (respuesta);
        }

        public List<SelectListItem> ConsultarEstadosCombo()
        {
            UsuarioBLL BLL = new UsuarioBLL();
             return (BLL.ConsultarEstadosCombo());
            //return (respuesta);
        }

        public UsuarioObj ValidarCredenciales(UsuarioObj obj)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            var respuesta = BLL.ValidarCredenciales(obj);
            return (respuesta);

        }

        public UsuarioObj ConsultarUsuarioEspecifico(int idUsuario)
        {
            UsuarioBLL BLL= new UsuarioBLL();
            var respuesta = BLL.ConsultarUsuarioEspecifico(idUsuario);
            return (respuesta);

        }


        public UsuarioObj GenerarTokenPassword(RecoveryPassword obj)
        {
            RecoveryPasswordBLL BLL = new RecoveryPasswordBLL();
            //SendEmail(obj.Email, obj.token);
            return(BLL.GenerarTokenPassword(obj));

        }


        public UsuarioObj RestablecerPassword(RecoveryPassword obj)
        {
            RecoveryPasswordBLL BLL = new RecoveryPasswordBLL();

            return (BLL.RestablecerPassword(obj));

        }

        public bool ValidarExistenciaEmail(string email)
        {
            UsuarioBLL BLL = new UsuarioBLL();

            return (BLL.ValidarExistenciaEmail(email));
        }

        public bool VerifiExistencia(string Email, string Cedula)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            return (BLL.VerifiExistencia(Email,Cedula));
        }


        //Helpers



        //Funcion Stephanny
        public UsuarioObj ConsultarRol(int idRol, int idOperacion)
        {
            // se verifica lo que hay en la BD
            var resultado = new UsuarioObj();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var proces = (from m in context.Rol_Operacion
                                  where m.idRol == idRol
                                  && m.idOperacion == idOperacion
                                  select m).FirstOrDefault();

                    //se valida los campos, con los enums
                    if (proces != null)
                    {
                        return resultado;
                    }
                    return null;
                   

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

      


     
     

        private string MontarCorreo(string token)

        {
            string plantilla =
                "<style>" +
                "@media only screen and (min-width: 620px){.u-row{width:600px!important}.u-row .u-col{vertical-align:top}.u-row .u-col-50{width:300px!important}.u-row .u-col-100{width:600px!important}}@media (max-width: 620px){.u-row-container{max-width:100%!important;padding-left:0!important;padding-right:0!important}.u-row .u-col{min-width:320px!important;max-width:100%!important;display:block!important}.u-row{width:calc(100% - 40px)!important}.u-col{width:100%!important}.u-col > div{margin:0 auto}}body{margin:0;padding:0}table,tr,td{vertical-align:top;border-collapse:collapse}p{margin:0}.ie-container table,.mso-container table{table-layout:fixed}*{line-height:inherit}a[x-apple-data-detectors='true']{color:inherit!important;text-decoration:none!important}table,td{color:#000}a{color:#161a39;text-decoration:underline}" +
                "</style>" +
                "</head><body class='clean-body u_body' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000'> <table style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%' cellpadding='0' cellspacing='0'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #f9f9f9;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span> </td></tr></tbody> </table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> <img align='center' border='0' src='images/image-3.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 29%;max-width: 168.2px;' width='168.2'/> </td></tr></table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #161a39;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:35px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> <img align='center' border='0' src='images/image-4.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 10%;max-width: 58px;' width='58'/> </td></tr></table> </td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:0px 10px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%; text-align: center;'><span style='font-size: 28px; line-height: 39.2px; color: #ffffff; font-family: Lato, sans-serif;'>Restablecimiento de contrase&ntilde;a</span></p></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Hola,</span></p><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #7f8d8d;'>Le hemos enviado este correo electr&oacute;nico en respuesta a su solicitud de restablecer su contrase&ntilde;a en nombre de la empresa.</span></p><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style='font-size: 14px; line-height: 140%;'><br/><span style='font-size: 18px; line-height: 25.2px; color: #7f8c8c;'><span style='color: #7f8d8d; font-size: 18px; line-height: 25.2px;'>Para restablecer su contrase&ntilde;a, siga el siguiente enlace</span>:</span></p></div></td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:0px 40px;font-family:'Lato',sans-serif;' align='left'> <div align='left'> <a href='https://localhost:44340/' target='_blank' style='box-sizing: border-box;display: inline-block;font-family:'Lato',sans-serif;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #FFFFFF; background-color: #18163a; border-radius: 1px;-webkit-border-radius: 1px; -moz-border-radius: 1px; width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;'> <span style='display:block;padding:15px 40px;line-height:120%;'><span style='font-size: 18px; line-height: 21.6px;'>Reset Password</span></span> </a> </div></td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='color: #888888; font-size: 14px; line-height: 19.6px;'><em><span style='font-size: 16px; line-height: 22.4px;'>Por favor, ignore este correo electr&oacute;nico si no ha solicitado un cambio de contrase&ntilde;a. </span></em></span></p></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #18163a;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 20px 20px 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='color: #fffefe; font-size: 14px; line-height: 19.6px;'>Grupo Artemetal</span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 14px; line-height: 19.6px; color: #ecf0f1;'>8432 2792 | Info@artemetal.com</span></p></div></td></tr></tbody></table> </div></div></div><div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px 0px 0px 20px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <div align='left'> <div style='display: table; max-width:93px;'> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 15px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.facebook.com/GrupoArteMetalCR' title='Facebook' target='_blank'> <img src='images/image-1.png' alt='Facebook' title='Facebook' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'> </a> </td></tr></tbody></table> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.instagram.com/grupoartemetalcr/' title='Instagram' target='_blank'> <img src='images/image-2.png' alt='Instagram' title='Instagram' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'> </a> </td></tr></tbody></table> </div></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #1c103b;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #1c103b;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span> </td></tr></tbody> </table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> </div></div></div></div></div></div></td></tr></tbody> </table> </body></html>";


            return plantilla;
        }
    }
}