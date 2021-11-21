using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _idCategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }

            set { _Descripcion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DCategoria()
        {

        }

        public DCategoria(int idCategoria, string Nombre, string Descripcion, string TextoBuscar)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.TextoBuscar = TextoBuscar;
        }

        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "spinsertar_Categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                sqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Categoria.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Registro ingresado" : "No se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string Editar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speditar_Categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                sqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Categoria.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Registro actualizado" : "No se Actualizo el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speliminar_Categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Categoria.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Registro eliminado" : "No se Elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Categoria");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("Categoria");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_Categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
