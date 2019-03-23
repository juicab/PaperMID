using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class DeptoModel
    {
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public DateTime FechaRegistroTpro { get; set; }
        public Boolean StatusTpro { get; set; }
    }
}