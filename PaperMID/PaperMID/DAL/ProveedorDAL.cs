using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class ProveedorDAL
    {
        ConexionDAL oConexionDAL;
        public ProveedorDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string nombre, string telefono, string correo)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[Proveedor]([NombreProv],[TelefonoProv],[CorreoProv],[FechaRegistroProv],[StatusProv])VALUES"+
           "('"+nombre+"'"+
           ",'"+telefono+"'"+
           ",'"+correo+"'"+
           ",'"+date+"'"+
           ",'"+true+"')");
            return oConexionDAL.EjecutarSQL(query);
        }

    }
}