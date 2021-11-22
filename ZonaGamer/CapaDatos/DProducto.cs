using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProducto
    {
        private int _idProducto;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private int _idCategoria;
        private int _idPresentacion;
        private string _TextoBuscar;

        public int IdProducto { 
            get { return _idProducto; }
            set { _idProducto = value; }
        }
        public string Codigo { 
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion { 
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IdCategoria { 
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        public int IdPresentacion { 
            get { return _idPresentacion; }
            set { _idPresentacion = value; }
        }
        public string TextoBuscar { 
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public DProducto()
        {

        }

        public DProducto(int idproducto, string codigo, string nombre, string descripcion, int idcategoria, int idpresentacion, string textobuscar)

        {
            this.IdProducto = idproducto;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.IdCategoria = idcategoria;
            this.IdPresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "spinsertar_producto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo";
                ParCodigo.SqlDbType = SqlDbType.NVarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Producto.Codigo;
                sqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Producto.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.NVarChar;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.NVarChar;
                ParIdPresentacion.Value = Producto.IdPresentacion;
                sqlCmd.Parameters.Add(ParIdPresentacion);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Ingreso registrado" : "No se Ingreso el Registro";
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

        public string Editar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speditar_Producto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParidProducto = new SqlParameter();
                ParidProducto.ParameterName = "@idProducto";
                ParidProducto.SqlDbType = SqlDbType.Int;
                ParidProducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParidProducto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo";
                ParCodigo.SqlDbType = SqlDbType.NVarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Producto.Codigo;
                sqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.NVarChar;
                ParDescripcion.Size = 250;
                ParDescripcion.Value = Producto.Descripcion;
                sqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.NVarChar;
                ParIdCategoria.Value = Producto.IdCategoria;
                sqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.NVarChar;
                ParIdPresentacion.Value = Producto.IdPresentacion;
                sqlCmd.Parameters.Add(ParIdPresentacion);

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

        public string Eliminar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speliminar_producto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idPresentacion";
                ParIdproducto.SqlDbType = SqlDbType.Int;
                ParIdproducto.Value = Producto.IdProducto;
                sqlCmd.Parameters.Add(ParIdproducto);

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
            DataTable DtResultado = new DataTable("producto");
            SqlConnection SqlCon = Conexion.OpenCN();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_producto";
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

        public DataTable BuscarNombre(DProducto Producto)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_producto_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;
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

        public DataTable Stock_Producto()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_producto";
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
    }
}
