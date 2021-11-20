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
            SqlConnection Cn = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            Cn.Open();
            return Cn;
        }

        public static SqlConnection CloseCN()
        {
            SqlConnection Cn = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            Cn.Close();
            return Cn;
        }

    }
}
