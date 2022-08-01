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




    }




}