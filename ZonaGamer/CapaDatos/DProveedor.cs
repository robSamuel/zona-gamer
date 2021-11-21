using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        private int _IdProveedor;
        private string _Razon_Social;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int idProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }

        public string Razon_social
        {
            get { return _Razon_Social; }
            set { _Razon_Social = value; }
        }
        public string Tipo_documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }
        public string Num_documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DProveedor()
        {

        }

        public DProveedor(int idproveedor, string razon_social,string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.idProveedor = idproveedor;
            this.Razon_social = razon_social;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.email = email;
            this.TextoBuscar = textobuscar;
        }

        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "spinsertar_proveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazon_social = new SqlParameter();
                ParRazon_social.ParameterName = "@razon_social";
                ParRazon_social.SqlDbType = SqlDbType.NVarChar;
                ParRazon_social.Size = 20;
                ParRazon_social.Value = Proveedor.Razon_social;
                sqlCmd.Parameters.Add(ParRazon_social);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.NVarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Proveedor.Tipo_documento;
                sqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.NVarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_documento;
                sqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                sqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.email;
                sqlCmd.Parameters.Add(ParEmail);

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

        //Metodo Editar
        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speditar_proveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.idProveedor;
                sqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRazon_Social = new SqlParameter();
                ParRazon_Social.ParameterName = "@razon_social";
                ParRazon_Social.SqlDbType = SqlDbType.Int;
                ParRazon_Social.Value = Proveedor.Razon_social;
                sqlCmd.Parameters.Add(ParRazon_Social);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.NVarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.Tipo_documento;
                sqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.NVarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_documento;
                sqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                sqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.email;
                sqlCmd.Parameters.Add(ParEmail);

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

        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speliminar_proveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = Proveedor.idProveedor;
                sqlCmd.Parameters.Add(parIdProveedor);

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
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmpstrar_proveedor";
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

        public DataTable BuscarRazon_Social(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCon.ConnectionString = Conexion.OpenCN().ToString();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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

        public DataTable BuscarNum_documento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
