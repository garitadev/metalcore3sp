using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.DAL.Models
{
    public class ProveedoresDAL
    {
        public List<SelectListItem> ConsultarProveedoresCombo()
        {


            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Proveedor
                                 select x).ToList();

                    resultado.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = "Seleccione"
                    });

                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idProveedor.ToString(),
                            Text = item.nombre

                        });
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();

                    throw ex;
                }
            }
        }
    }
}
