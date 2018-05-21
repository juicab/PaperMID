using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class DatosFiscalesDAL
    {
        ConexionDAL oConexionDAL;
        public DatosFiscalesDAL() { oConexionDAL = new ConexionDAL(); }
        public int Agregar(string rfc,string razonsocial, string calle, string numinte, string numexte, string cruza, string colonia, string cp, int idMunicipio)
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string completo = "Calle " + calle + " Num. inte. " + numinte + " Num. Exte. " + numexte + " por " + cruza + " Colonia " + colonia + " CP. " + cp;
            string query = ("INSERT INTO [dbo].[DatosFiscales]([RFC],[RazonSocial],[CalleFis],[NumInteFis],[NumExteFis],[CruzaFis],[ColoniaFis],[CPFis],[IdMunicipio4],[FechaRegistroFis],[StatusFis],[CompletoFis])VALUES" +
                "('"+rfc+"','"+razonsocial+"','"+calle+"','"+numinte+"','"+numexte+"','"+cruza+"','"+colonia+"','"+cp+"',"+idMunicipio+",'"+date+"','True','"+completo+"')");
            return oConexionDAL.EjecutarSQL(query);
        }

        public int BuscarUltimoDatoFiscal()
        {
            SqlCommand Cmd = new SqlCommand("select top(1) IdDatoFiscal from DatosFiscales order by IdDatoFiscal desc");
            return oConexionDAL.EjecutarComando(Cmd);
        }
    }
}