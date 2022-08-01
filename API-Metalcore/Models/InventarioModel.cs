using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_Metalcore.Models
{
    public class InventarioModel
    {

        public List<ProductosObj> ObtenerProveedor()
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.ObtenerProveedor());
        }


        public List<ProductosObj> ConsultarProductos()
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.ConsultarProductos());
        }

        public List<SelectListItem> ConsultarProductosCombo()
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.ConsultarProductosCombo());
        }

        public ProductosObj ConsultarProducto(int idProducto)
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.ConsultarProducto(idProducto));
        }

        public ProductosObj ActualizarProductos(ProductosObj producto)
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.ActualizarProductos(producto));
        }

        public ProductosObj RegistrarProductos(ProductosObj producto)
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.RegistrarProductos(producto));
        }


        public ProductosObj BorrarProductos(int idProducto)
        {
            InventarioBLL BLL = new InventarioBLL();
            return (BLL.BorrarProductos(idProducto));
        }

    }




}