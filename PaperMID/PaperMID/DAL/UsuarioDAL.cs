using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class UsuarioDAL
    {
        ConexionDAL oConexionDAL;
        public UsuarioDAL() { oConexionDAL = new ConexionDAL(); }


        public int Agregar(string usuario, string correo, string contraseña)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("");
            return oConexionDAL.EjecutarSQL(query);
        }
    }
}