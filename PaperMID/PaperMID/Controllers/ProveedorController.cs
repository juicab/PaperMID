using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.DAL;

namespace PaperMID.Controllers
{
    public class ProveedorController : Controller
    {
        ProveedorDAL oProveedorDAL;
        // GET: Proveedor
        public ActionResult Proveedores()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(string nombre,string telefon,string correo)
        {
            oProveedorDAL = new ProveedorDAL();
            if (ModelState.IsValid)
            {
                int Resp = 0;
                Resp = oProveedorDAL.Agregar(nombre, telefon, correo);
                if (Resp == 1)
                {
                   
                    return RedirectToAction("Proveedores", "Proveedor");
                }
                else
                {
                    return RedirectToAction("Inicio", "Admin");
                }
            }
            else
            {
                return RedirectToAction("Inicio","Admin");
            }
             
        }
    }
}