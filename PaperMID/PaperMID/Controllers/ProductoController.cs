﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Productos()
        {
            return View();
        }
    }
}