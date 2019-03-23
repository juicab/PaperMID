using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;


namespace PaperMID.DAL
{
    public class DeptoDAL
    {
        ConexionDAL oConexionDAL;
        public DeptoDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string depto)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[TipoProducto]([TipoProd],[FechaRegistroTpro],[StatusTpro])VALUES" +
                "('"+depto+"','"+date+"','True')");
            return oConexionDAL.EjecutarSQL(query);
        }

        public DataTable Mostrar()
        {
            return oConexionDAL.TablaConnsulta("Select *From TipoProducto Where StatusTpro=1");
        }


    }
}