using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;
using PaperMID.Models;

namespace PaperMID.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        ProductoDAL oProductoDAL;
        public ActionResult Productos()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(string nombre, double desc, string fchini, string fchfin, string comentario, string prov)
        {
            oProductoDAL = new ProductoDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0;
                Resp = oProductoDAL.Agregar(nombre, desc, fchfin, fchini, comentario, prov);
                if (Resp == 1)
                {

                    return RedirectToAction("Promociones", "Promocion");
                }
                else
                {
                    return RedirectToAction("Inicio", "Admin");
                }
            }
            else
            {
                return RedirectToAction("Inicio", "Admin");
            }

        }

        [ChildActionOnly]
        public ActionResult ParcialDeptos()
        {
            oProductoDAL = new ProductoDAL();
            var productoModel = new ProductoModel();
            productoModel.TiposProducto = oProductoDAL.ListaDeptos();
            return PartialView(productoModel);
        }

        [ChildActionOnly]
        public ActionResult ParcialProvedores()
        {
            oProductoDAL = new ProductoDAL();
            var proveedorModel = new ProductoModel();
            proveedorModel.Proveedores = oProductoDAL.ListaProveedores();
            return PartialView(proveedorModel);
        }

    }
}