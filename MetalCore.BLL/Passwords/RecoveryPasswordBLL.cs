using MetalCore.BLL.Models;
using MetalCore.DAL.Passwords;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.BLL.Passwords
{
    public class RecoveryPasswordBLL
    {

        public UsuarioObj GenerarTokenPassword(RecoveryPassword obj)
        {
            string token = GetSha256(Guid.NewGuid().ToString());
            RecoveryPasswordDAL DAL = new RecoveryPasswordDAL();

            if(DAL.RegistrarTokenPassword(obj.Email, token) !=null)
            {
                EmailBLL sendEmail = new EmailBLL();
                sendEmail.PruebaPlantilla(obj.Email, token);
                return (DAL.RegistrarTokenPassword(obj.Email, token));

            }
            return null;
        }

        public UsuarioObj RestablecerPassword(RecoveryPassword obj)
        {
            string token = GetSha256(Guid.NewGuid().ToString());
            RecoveryPasswordDAL DAL = new RecoveryPasswordDAL();
            if (obj.Password != null)
            {
                obj.Password = GetSha256(obj.Password);
            }

            return (DAL.RestablecerPassword(obj));

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
    }
}
