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
            SqlConnection connect = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            connect.Open();
            return connect;
        }

        public static SqlConnection CloseCN()
        {
            SqlConnection connect = new SqlConnection("Server=localhost;Database=ZonaGamer;Integrated security=true");
            connect.Close();
            return connect;
        }

    }
}
