using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class ProductoDAL
    {
        ConexionDAL oConexionDAL;
        public ProductoDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string nombre, double desc, string fchini, string fchfin, string comentario, string prov)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[Promociones]([NombrePromo],[DescripcionPromo],[DescuentoPromo],[FechaInicioPromo],[FechaFinPromo],[IdProveedor1],[FechaRegistroPromo],[StatusPromo]) VALUES(" +
                "'" + nombre + "'" +
                ",'" + comentario + "'" +
                "," + desc + "" +
                ",'" + fchini + "'" +
                ",'" + fchfin + "'" +
                "," + prov + "" +
                ",'" + date + "'" +
                ",1)");
            return oConexionDAL.EjecutarSQL(query);
        }

        public List<DeptoModel> ListaDeptos()
        {
            string query = ("Select IdTipoProducto,TipoProd from TipoProducto where StatusTpro=1");
            var result = oConexionDAL.TablaConnsulta(query);
            List<DeptoModel> listaDeptos = new List<DeptoModel>();
            foreach (DataRow depto in result.Rows)
            {
                var deptoModel = new DeptoModel();
                deptoModel.IdTipoProducto = int.Parse(depto[0].ToString());
                deptoModel.TipoProducto = depto[1].ToString();
                listaDeptos.Add(deptoModel);
            }
            return listaDeptos;

        }

        public List<ProveedorModel> ListaProveedores()
        {
            string query = ("select IdProveedor,NombreProv from Proveedor where StatusProv=1");
            var result = oConexionDAL.TablaConnsulta(query);
            List<ProveedorModel> listaProveedor = new List<ProveedorModel>();
            foreach (DataRow provee in result.Rows)
            {
                var proveedorModel = new ProveedorModel();
                proveedorModel.idProveedor = int.Parse(provee[0].ToString());
                proveedorModel.NombreProv = provee[1].ToString();
                listaProveedor.Add(proveedorModel);
            }
            return listaProveedor;

        }



    }
}