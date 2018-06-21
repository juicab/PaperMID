using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PaperMID.Models;

namespace PaperMID.DAL
{
    public class PromocionesDAL
    {
        ConexionDAL oConexionDAL;
        public PromocionesDAL() { oConexionDAL = new ConexionDAL(); }

        public int Agregar(string nombre,double desc, string fchini, string fchfin,string comentario)
        {

            return 1;
        }
    }
}