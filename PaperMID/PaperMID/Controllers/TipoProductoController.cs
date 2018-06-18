using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;

namespace PaperMID.Controllers
{
    public class TipoProductoController : Controller
    {
        // GET: TipoProducto
        DeptoDAL oDeptoDAL;
        public ActionResult TipoProducto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(string depto)
        {
            oDeptoDAL = new DeptoDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0; Resp = oDeptoDAL.Agregar(depto);
                if (Resp == 1)
                {

                    return RedirectToAction("TipoProducto", "TipoProducto");
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

    }
}