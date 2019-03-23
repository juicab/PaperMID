using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class ConfiguracionDAL
    {
        ConexionDAL oConexionDAL;
        public ConfiguracionDAL() { oConexionDAL = new ConexionDAL(); }

        public ConfiguracionModel Obtener_Empresa()
        {
            var Empresa = new ConfiguracionModel();
            String StrBuscar = string.Format("Select * from Papeleria where IdPapeleria= 1");
            DataTable Datos =oConexionDAL.TablaConnsulta(StrBuscar);
            DataRow row = Datos.Rows[0];
            Empresa.IdPapeleria = Convert.ToInt32(row["IdPapeleria"]);
            Empresa.NombrePape = row["NombrePape"].ToString();
            Empresa.MisionPape = row["MisionPape"].ToString();
            Empresa.VisionPape = row["VisionPape"].ToString();
            Empresa.ValoresPape = row["ValoresPape"].ToString();
            Empresa.CorreoPape = row["CorreoPape"].ToString();
            Empresa.TelefenoPape = row["TelefenoPape"].ToString();
            Empresa.IdDireccion1 = Convert.ToInt32(row["IdDireccion1"]);
            Empresa.FechaRegistroPape = Convert.ToDateTime(row["FechaRegistroPape"].ToString());
            Empresa.StatusPape = Convert.ToBoolean(row["StatusPape"]);
            return Empresa;
        }

        public int Modificar(string nombre, string correo, string telefono, string mision, string vision, string valores)
        {
            string query = "UPDATE [dbo].[Papeleria] SET [NombrePape] = '"+nombre+"',[MisionPape] ='"+mision+"',[VisionPape] = '"+vision+"',[ValoresPape]= '"+valores+"',[CorreoPape] ='"+correo+"',[TelefenoPape]='"+telefono+"' WHERE IdPapeleria=1";
            return oConexionDAL.EjecutarSQL(query);
        }




    }
}