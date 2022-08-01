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
    public class InventarioBLL
    {

        public List<ProductosObj> ObtenerProveedor()
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.ObtenerProveedor());
        }

        public List<ProductosObj> ConsultarProductos()
        {
            InventarioDAL DAL= new InventarioDAL();
            return (DAL.ConsultarProductos());
        }

        public List<SelectListItem> ConsultarProductosCombo()
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.ConsultarProductosCombo());
        }


        public ProductosObj ConsultarProducto(int idProducto)
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.ConsultarProducto(idProducto));
        }

        public ProductosObj RegistrarProductos(ProductosObj producto)
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.RegistrarProductos(producto));
        }

        public ProductosObj ActualizarProductos(ProductosObj producto)
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.ActualizarProductos(producto));
        }

        public ProductosObj BorrarProductos(int idProducto)
        {
            InventarioDAL DAL = new InventarioDAL();
            return (DAL.BorrarProductos(idProducto));
        }

    }
}
