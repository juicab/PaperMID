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

        //public int Comprobar_Usuario(LoginModel oLoginModel)
        //{
        //    try
        //    {
        //        SqlCommand Cmd = new SqlCommand("EXEC SP_Login @Usuario,@ContraseñaUsu", oConexionDAL.EstablecerConexion());
        //        Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oLoginModel.Usuario;
        //        Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = Encriptar(oLoginModel.ContraseñaUsu);
        //        string encrip = Encriptar(oLoginModel.ContraseñaUsu);
        //        Cmd.CommandType = CommandType.Text;
        //        var _oLogin_RespuestaModel = new Login_RespuestaModel();
        //        //Recolección de datos.
        //        oConexionDAL.AbrirConexion();
        //        SqlDataReader Datos = Cmd.ExecuteReader();
        //        while (Datos.Read())
        //        {
        //            _oLogin_RespuestaModel.IdUsuario = int.Parse(Datos[0].ToString());
        //            _oLogin_RespuestaModel.Usuario = Datos[1].ToString();
        //            _oLogin_RespuestaModel.Modulo = Datos[3].ToString();
        //            _oLogin_RespuestaModel.NombreUsu = Datos[4].ToString();

        //        }
        //        oConexionDAL.CerrarConexion();
        //        //Comprobación.
        //        return (_oLogin_RespuestaModel.IdUsuario > 0) ? _oLogin_RespuestaModel : null;

        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }

        //}
    }
}