using MetalCore.DAL.Models;
using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.BLL.Models
{
    public class UsuarioBLL
    {

        public UsuarioObj ValidarCredenciales(UsuarioObj obj)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            string epass = GetSha256(obj.password);
            var respuesta = DAL.ValidarCredenciales(obj, epass);
            return (respuesta);


        }

        //verificar la existencia del usuario
        public bool VerifiExistencia(string Email, string Cedula)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            return (DAL.VerifiExistencia(Email,Cedula));


        }


        public UsuarioObj RegistrarUsuario(UsuarioObj obj)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            obj.password = GetSha256(obj.password);
            return (DAL.RegistrarUsuario(obj));
           


        }

        public UsuarioObj ActuaUsuario(UsuarioObj obj)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            DAL.ActuaUsuario(obj);
            return (obj);


        }

        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

//los combobox
        public List<SelectListItem> ConsultarRolesCombo()
        {
            UsuarioDAL DAL = new UsuarioDAL();
            return (DAL.ConsultarRolesCombo());


        }


        public List<SelectListItem> ConsultarEstadosCombo()
        {
            UsuarioDAL DAL = new UsuarioDAL();
            return  (DAL.ConsultarEstadosCombo());
            


        }

        public UsuarioObj ConsultarUsuarioEspecifico(int idUsuario)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            var respuesta = DAL.ConsultarUsuarioEspecifico(idUsuario);
            return (respuesta);


        }

        public bool ValidarExistenciaEmail(string email)
        {
            UsuarioDAL DAL = new UsuarioDAL();
            return (DAL.ValidarExistenciaEmail(email));


        }

        public List<UsuarioObj> ConsultarUsuarios()
        {
            UsuarioDAL DAL = new UsuarioDAL();
            return (DAL.ConsultarUsuarios());
        }
    }
}
