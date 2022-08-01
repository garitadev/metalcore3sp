using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_Metalcore.Models
{
    public class TrabajoModel
    {


        public List<TrabajoObj> VerTrabajos()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.VerTrabajos());
        }

        public List<SelectListItem> ConsultarEstadosCombo()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarEstadosCombo());
        }

        public List<TrabajoObj> ConsultarEstadoEspecifico(int idEstado)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarEstadoEspecifico(idEstado));
        }

        /////////////////////
        public List<TrabajoObj> ConsultarTrabajos()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarTrabajos());
        }

        public List<MaterialesOBJ> ConsultarAsigMateri()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarAsigMateri());
        }


        public List<SelectListItem> ConsultarEstadoTrabajosCombo()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarEstadoTrabajosCombo());
        }

        public List<SelectListItem> ConsultarEmpleadoCombo()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarEmpleadoCombo());
        }

        public List<SelectListItem> ConsultarProductoCombo()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarProductoCombo());
        }

        public MaterialesOBJ EncontrarPrecio(int idProducto)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            var respuesta = BLL.EncontrarPrecio(idProducto);
            return (respuesta);

        }

        public bool VerifiFecha(int idUsuario, DateTime fecha)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.VerifiFecha(idUsuario, fecha));
        }

        public TrabajoObj RegistrarTrabajo(TrabajoObj producto)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.RegistrarTrabajo(producto));
        }

        public List<SelectListItem> ConsultarTrabajosCombo()
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarTrabajosCombo());
        }
        public bool VerifiStock(int Cantidad, int idProducto)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.VerifiStock(Cantidad, idProducto));
        }

        public MaterialesOBJ RegistrarMaterial(MaterialesOBJ producto)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.RegistrarMaterial(producto));
        }


        //modficar

        public TrabajoObj ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarUTrabajoEspecifico(idTrabajo));
        }

        public MaterialesOBJ ConsultarMaterialEspecifico(int idMaterial)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.ConsultarMaterialEspecifico(idMaterial));
        }


        public void ActuaTrabajo(TrabajoObj Actua)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            BLL.ActuaTrabajo(Actua);

        }

        public void ActuaMaterial(MaterialesOBJ Actua)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            BLL.ActuaMaterial(Actua);

        }

        public bool VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.VerifiStockActua(Cantidad, idProducto, idMaterial));
        }


        //borrar-----------

        public MaterialesOBJ BorrarTrabajo(int idTrabajo)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.BorrarTrabajo(idTrabajo));
        }

        public MaterialesOBJ BorrarMaterial(int idMaterial)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.BorrarMaterial(idMaterial));
        }

        public bool VerifiExisTrabajo(int idTrabajo)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            return (BLL.VerifiExisTrabajo(idTrabajo));
        }

    }

}