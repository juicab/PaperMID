using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class LoginDAL
    {
        ConexionDAL oConexionDAL;
        public LoginDAL() { oConexionDAL = new ConexionDAL(); }

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

        public int verificarAdmin(string usu,string contra)
        {
            string contras = Encriptar(contra);
            string query = ("Select count(*) from Usuario where Usuario.Usuario = '" + usu + "' and Usuario.ContraseñaUsu = '" + contras + "' and Usuario.IdTipoUsuario1 = 1");
            return oConexionDAL.EjecutarSQL(query);
        }

        public int verificarCliente(string usu, string contra)
        {
            string contras = Encriptar(contra);
            string query = ("Select count(*) from Usuario where Usuario.Usuario = '" + usu + "' and Usuario.ContraseñaUsu = '" + contras + "' and Usuario.IdTipoUsuario1 = 2");
            return oConexionDAL.EjecutarSQL(query);
        }



    }
}