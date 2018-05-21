﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PaperMID.DAL
{
    public class ConexionDAL
    {
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter Adaptador;
        DataTable TablaVirtual;
        DataSet DAtaSetAdaptador;

        String Servidor = "Data Source=SQL7004.site4now.net;Initial Catalog=DB_A386B8_PaperMID;User Id=DB_A386B8_PaperMID_admin;Password=Cs18191819;";
        String localhost = "Data Source=JESUS;Initial Catalog=DB_A386B8_PaperMID;Integrated Security=True";
        String estadia = "Data Source=Estadia;Initial Catalog=DB_A386B8_PaperMID;Integrated Security=True";

        public SqlConnection EstablecerConexion()
        {
            Con = new SqlConnection(estadia);

            return Con;
        }

        public void AbrirConexion()
        {
            Con.Open();
        }

        public void CerrarConexion()
        {
            Con.Close();
        }

        public int EjecutarSQL(string Sentencia)
        {
            //Inserts,Deletes,Updates
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = EstablecerConexion();
                AbrirConexion();
                Cmd.CommandText = Sentencia;
                int Confirmacion = Cmd.ExecuteNonQuery();
                CerrarConexion();
                return 1;
            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public int EjecutarComando(SqlCommand SqlComando)
        {
            //Insert,Delete,Update
            Cmd = new SqlCommand();
            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            int id = 0; id = Convert.ToInt32(Cmd.ExecuteScalar());
            this.CerrarConexion();
            return id;
        }

        public DataTable TablaConnsulta(string Sentencia)
        {
            Adaptador = new SqlDataAdapter(Sentencia, EstablecerConexion());
            TablaVirtual = new DataTable();

            //Rellenar un objeto DataSet con los resultados del elemento SelectCommand.
            Adaptador.Fill(TablaVirtual);
            return TablaVirtual;
        }


        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }

        public DataSet EjecutarSentencia_string(string SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd.CommandText = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }
    }
}
