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



        public List<TrabajoObj> VerTrabajos()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.VerTrabajos());
        }

        public List<SelectListItem> ConsultarEstadosCombo()
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarEstadosCombo());
        }

        public List<TrabajoObj> ConsultarEstadoEspecifico(int idEstado)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.ConsultarEstadoEspecifico(idEstado));
        }




        //////////////////////////








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


        //encontrar precio

        public MaterialesOBJ EncontrarPrecio(int idProducto)
        {
            TrabajoDAL DAL = new TrabajoDAL();

            return (DAL.EncontrarPrecio(idProducto));
        }

        //modificar-------------------------------
        public TrabajoObj ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            var respuesta = DAL.ConsultarUTrabajoEspecifico(idTrabajo);
            return (respuesta);
        }

        public MaterialesOBJ ConsultarMaterialEspecifico(int idMaterial)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            var respuesta = DAL.ConsultarMaterialEspecifico(idMaterial);
            return (respuesta);
        }


        public TrabajoObj ActuaTrabajo(TrabajoObj Actua)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            DAL.ActuaTrabajo(Actua);
            return (Actua);


        }

        public MaterialesOBJ ActuaMaterial(MaterialesOBJ Actua)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            DAL.ActuaMaterial(Actua);
            return (Actua);


        }

        public bool VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.VerifiStockActua(Cantidad, idProducto, idMaterial));


        }

        //eliminar trabajos-------------------------------------
        public MaterialesOBJ BorrarTrabajo(int idTrabajo)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.BorrarTrabajo(idTrabajo));
        }

        public MaterialesOBJ BorrarMaterial(int idMaterial)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.BorrarMaterial(idMaterial));
        }

        public bool VerifiExisTrabajo(int idTrabajo)
        {
            TrabajoDAL DAL = new TrabajoDAL();
            return (DAL.VerifiExisTrabajo(idTrabajo));

        }

    }
}

