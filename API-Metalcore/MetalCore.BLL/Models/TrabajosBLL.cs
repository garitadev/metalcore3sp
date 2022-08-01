using MetalCore.DAL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.BLL.Models
{
    public class TrabajosBLL
    {
        public List<TrabajoObj> ConsultarTrabajos()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarTrabajos());
        }

        public List<MaterialesOBJ> ConsultarAsigMateri()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarAsigMateri());
        }


        //verificar fecha
        public bool VerifiFecha(int idUsuario, DateTime fecha)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.VerifiFecha(idUsuario, fecha));


        }


        //registar
        public TrabajoObj RegistrarTrabajo(TrabajoObj obj)
        {
            TrabajoDAL DAL = new TrabajoDAL();

            DAL.RegistrarTrabajo(obj);
            return obj;


        }

        public List<SelectListItem> ConsultarTrabajosCombo()
        {

            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarTrabajosCombo());

        }

        //registrar material
        public MaterialesOBJ RegistrarMaterial(MaterialesOBJ obj)
        {
            TrabajoDAL DAL = new TrabajoDAL();

            DAL.RegistrarMaterial(obj);
            return obj;


        }

        //verificar stock
        public bool VerifiStock(int Cantidad, int idProducto)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.VerifiStock(Cantidad, idProducto));


        }

        public List<SelectListItem> ConsultarEstadoTrabajosCombo()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarEstadoTrabajosCombo());
        }

        public List<SelectListItem> ConsultarEmpleadoCombo()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarEmpleadoCombo());
        }

        public List<SelectListItem> ConsultarProductoCombo()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarProductoCombo());
        }
    }
}

