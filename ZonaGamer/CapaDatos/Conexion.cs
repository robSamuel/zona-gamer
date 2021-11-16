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
        try
            {
                connect = new SqlConnection("Server=DESKTOP-4CTFC2J\\SQLSERVER2017;Database=Clientes;UID=" + user + ";PWD=" + pass);
                connect.Open();
            }
            catch (Exception)
            {
              
                
            }
    }
}
