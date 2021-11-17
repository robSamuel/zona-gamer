using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    class Conexion
    {
        public static SqlConnection OpenCN()
        {
            SqlConnection cn = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            cn.Open();
            return cn;
        }

        public static SqlConnection CloseCN()
        {
            SqlConnection cn = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            cn.Close();
            return cn;
        }

    }
}
