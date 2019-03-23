using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string CodigoProd { get; set; }
        public string NombreProd { get; set; }
        public string DescripcionProd { get; set; }
        public double PrecioCompraProd { get; set; }
        public double PrecioVentaProd { get; set; }
        public double DescuentoProd { get; set; }
        public int CantidadDisponibleProd { get; set; }
        public int CantidadMinimaProd { get; set; }
        public string ImagenProd { get; set; }
        public int IdTipoProducto1 { get; set; }
        public int IdProveedor1 { get; set; }
        public DateTime FechaRegistroProd { get; set; }
        public Boolean StatusProd { get; set; }
        public List<ProveedorModel> Proveedores { get; set; }
        public List<DeptoModel> TiposProducto { get; set; }
    }
}