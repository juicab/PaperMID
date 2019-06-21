using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class MensajeDAL
    {
        ConexionDAL oConexionDAL;

        ConexionMeridaDAL oConexionMeridaDAL;
        public MensajeDAL() { oConexionDAL = new ConexionDAL(); oConexionMeridaDAL = new ConexionMeridaDAL(); }

        public int Agregar(string mensaje, string nombre, string asunto, string telefono, string correo)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[Mensaje]([Mensaje],[Nombre],[Asunto],[Telefono],[Correo],[Usuario],[Estatus]) VALUES('"+mensaje+"','"+nombre+"','"+asunto+"','"+telefono+"','"+correo+"',"+11+","+1+")");
            return oConexionDAL.EjecutarSQL(query);
        }

        public int AgregarEnMerida(string nombre, string correo, string asunto, string telefono, string mensaje)
        {
            string query = "INSERT INTO [dbo].[Mensaje]([nombre],[correo],[asunto],[telefono],[pagina],[mensaje],[statusMen]) VALUES ('" + nombre + "','" + correo + "','" + asunto + "','" + telefono + "','PaperMID','" + mensaje + "',1)";
            return oConexionMeridaDAL.EjecutarSQL(query);
        }


    }
}