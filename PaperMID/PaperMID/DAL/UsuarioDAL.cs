using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;
using System.Security.Cryptography;
using System.Text;

namespace PaperMID.DAL
{
    public class UsuarioDAL
    {
        ConexionDAL oConexionDAL;
        DireccionDAL oDireccionDAL;
        DatosFiscalesDAL oDatosFiscalesDAL;
        public UsuarioDAL() { oConexionDAL = new ConexionDAL(); }
        //Seguridad - Encriptado.
        public string Encriptar(string str) //MD5
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }


        public int AgregarCliente(string usuario, string correo, string contraseña)
        {
            oDireccionDAL = new DireccionDAL();
            oDatosFiscalesDAL = new DatosFiscalesDAL();
            oDireccionDAL.Agregar("NA", "NA", "NA", "NA", "Mérida", "97000", 1);
            oDatosFiscalesDAL.Agregar("NA", "NA", "NA", "NA", "NA", "NA", "Mérida", "97000", 1);
            int IdDireccion = 0;IdDireccion = oDireccionDAL.BuscarUltimaDireccion();
            int IdDatoFiscal = 0; IdDatoFiscal = oDatosFiscalesDAL.BuscarUltimoDatoFiscal();
            string encri = Encriptar(contraseña);
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string date = year + "/" + month + "/" + day;
            string query = ("INSERT INTO [dbo].[Usuario]([Usuario],[ContraseñaUsu],[NombreUsu],[ApellidoPaternoUsu],[ApellidoMaternoUsu],[TelefonoUsu],[CorreoUsu],[FechaRegistroUsu],[IdTipoUsuario1],[IdDireccion2],[StatusUsu],[IdDatoFiscal1])VALUES" +
                "('"+usuario+"','"+encri+"','Nombres','ApellidoPateno','ApellidoMaterno','Telefono','"+correo+"','"+date+"',2,"+IdDireccion+",'True',"+IdDatoFiscal+")");
            return oConexionDAL.EjecutarSQL(query);
        }
    }
}