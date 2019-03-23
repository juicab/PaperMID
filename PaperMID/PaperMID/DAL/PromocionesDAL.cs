using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class PromocionesDAL
    {
        ConexionDAL oConexionDAL;
        public PromocionesDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string nombre,double desc, string fchini, string fchfin,string comentario,string prov)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[Promociones]([NombrePromo],[DescripcionPromo],[DescuentoPromo],[FechaInicioPromo],[FechaFinPromo],[IdProveedor1],[FechaRegistroPromo],[StatusPromo]) VALUES(" +
                "'"+nombre+"'" +
                ",'"+comentario+"'" +
                ","+desc+"" +
                ",'"+fchini+"'" +
                ",'"+fchfin+"'" +
                ","+prov+"" +
                ",'"+date+"'" +
                ",1)");
            return oConexionDAL.EjecutarSQL(query);
        }

        public DataTable Mostrar()
        {
            return oConexionDAL.TablaConnsulta("Select * From Promociones Where StatusPromo=1");
        }

    }
}