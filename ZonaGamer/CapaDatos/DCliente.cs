using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _Idcliente;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private DateTime _Fecha_nac;
        private string _Tipo_documento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Textobuscar;

        public int idCliente 
        { get { return _Idcliente; }
                
         set { _Idcliente = value; }
        }
        public string Nombre 
        {  get { return _Nombre; }
                 set { _Nombre = value; }
        }
        public string Apellido
        {  get { return _Apellido; }
                set { _Apellido = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }
        public DateTime Fecha_nac 
        {  get { return _Fecha_nac; }
                 set { _Fecha_nac = value; }
        }
        public string Tipo_documento 
        {  get { return _Tipo_documento; }
                 set{ _Tipo_documento = value; }
        }
        public string Num_documento
        {  get { return _Num_documento; }
                 set { _Num_documento = value; }
        }
        public string Direccion
        { get { return _Direccion; }
                 set { _Direccion = value; }
        }
        public string Telefono
        {  get { return _Telefono; }
                 set { _Telefono = value; }
        }
        public string Email
        { get { return _Email; }
                 set { _Email = value; }
        }
        public string Textobuscar
        { get { return _Textobuscar; }
                set { _Textobuscar = value; }
        }

        public DCliente()
        {

        }

        public DCliente(int idcliente, string nombre, string apellido, string sexo, DateTime fecha_nac,
             string tipo_documento, string num_documento, string direccion, string telefono, string email,
             string textobuscar)
        {
            this.idCliente = idcliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Fecha_nac = fecha_nac;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Direccion = Direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Textobuscar = textobuscar;

        }

        public string Insertar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "spinsertar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.NVarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Cliente.Apellido;
                sqlCmd.Parameters.Add(ParApellido);


                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.NVarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Cliente.Sexo;
                sqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_nac = new SqlParameter();
                ParFecha_nac.ParameterName = "@fecha_nac";
                ParFecha_nac.SqlDbType = SqlDbType.NVarChar;
                ParFecha_nac.Size = 50;
                ParFecha_nac.Value = Cliente.Fecha_nac;
                sqlCmd.Parameters.Add(ParFecha_nac);

                SqlParameter ParTipo_documento = new SqlParameter();
                ParTipo_documento.ParameterName = "@tipo_documento";
                ParTipo_documento.SqlDbType = SqlDbType.NVarChar;
                ParTipo_documento.Size = 20;
                ParTipo_documento.Value = Cliente.Tipo_documento;
                sqlCmd.Parameters.Add(ParTipo_documento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@num_documento";
                ParNum_documento.SqlDbType = SqlDbType.NVarChar;
                ParNum_documento.Size = 11;
                ParNum_documento.Value = Cliente.Num_documento;
                sqlCmd.Parameters.Add(ParNum_documento);


                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                sqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Cliente.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
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

        public string Editar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speditar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.idCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.NVarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Cliente.Apellido;
                sqlCmd.Parameters.Add(ParApellido);


                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.NVarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Cliente.Sexo;
                sqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_nac = new SqlParameter();
                ParFecha_nac.ParameterName = "@fecha_nac";
                ParFecha_nac.SqlDbType = SqlDbType.NVarChar;
                ParFecha_nac.Size = 50;
                ParFecha_nac.Value = Cliente.Fecha_nac;
                sqlCmd.Parameters.Add(ParFecha_nac);

                SqlParameter ParTipo_documento = new SqlParameter();
                ParTipo_documento.ParameterName = "@tipo_documento";
                ParTipo_documento.SqlDbType = SqlDbType.NVarChar;
                ParTipo_documento.Size = 20;
                ParTipo_documento.Value = Cliente.Tipo_documento;
                sqlCmd.Parameters.Add(ParTipo_documento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@num_documento";
                ParNum_documento.SqlDbType = SqlDbType.NVarChar;
                ParNum_documento.Size = 11;
                ParNum_documento.Value = Cliente.Num_documento;
                sqlCmd.Parameters.Add(ParNum_documento);


                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                sqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Cliente.Telefono;
                sqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
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

        public string Eliminar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "speliminar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.idCliente;
                sqlCmd.Parameters.Add(ParIdCliente);

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
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_cliente";
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

        public DataTable BuscarApellido(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.Textobuscar;
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

        public DataTable BuscarNum_documento(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.Textobuscar;
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
