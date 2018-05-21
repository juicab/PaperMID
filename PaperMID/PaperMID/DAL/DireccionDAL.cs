using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class DireccionDAL
    {
        ConexionDAL oConexionDAL;
        public DireccionDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string calle, string numinte, string numexte, string cruza, string colonia,string cp,int idMunicipio)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string completo = "Calle " + calle + " Num. inte. " + numinte + " Num. Exte. " + numexte + " por " + cruza + " Colonia " + colonia + " CP. " + cp;
            string query = ("INSERT INTO [dbo].[Direccion]([CalleDir],[NumInteDir],[NumExteDir],[CruzaDir],[ColoniaDir],[CPDir],[IdMunicipio1],[FechaRegistroDir],[StatusDir],[completo]) VALUES" +
                "('"+calle+"','"+numinte+"','"+numexte+"','"+cruza+"','"+colonia+"','"+cp+"',"+idMunicipio+",'"+date+"','True','"+completo+"')");
            return oConexionDAL.EjecutarSQL(query);
        }

        public int BuscarUltimaDireccion()
        {
            SqlCommand Cmd = new SqlCommand("select top (1) IdDireccion from Direccion order by IdDireccion desc");
            return oConexionDAL.EjecutarComando(Cmd);
        }

    }
}