using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _Idventas;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        //Propiedades
        public int idVentas
        {
            get { return _Idventas; }
            set { _Idventas = value; }
        }

        public int idCliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public int idEmpleado
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Tipo_comprobante
        {
            get { return _Tipo_Comprobante; }
            set { _Tipo_Comprobante = value; }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public string Correlativo
        {
            get { return _Correlativo; }
            set { _Correlativo = value; }
        }

        public decimal Igv
        {
            get { return _Igv; }
            set { _Igv = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        //Constructores
        public DVenta()
        {

        }
        public DVenta(int idventas, int idcliente, int idempleado, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado)
        {
            this.idVentas = idventas;
            this.idCliente = idcliente;
            this.idEmpleado = idempleado;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }

        //Disminuir Stock
        public string DisminuirStock(int idDetalle_ingreso, int Cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@idDetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = idDetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Se actualizó el Stock";

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

        //Métodos
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalles)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer la transacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parámtros
                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idVentas";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idCliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Venta.idCliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idEmpleado";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.idEmpleado;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@Tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Venta.Tipo_comprobante;
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@Correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@Igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Venta.Igv;
                SqlCmd.Parameters.Add(ParIgv);


                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
                if (rpta.Equals("OK"))
                {
                    //Obtenemos el codigo del ingreso que se genero por la base de datos

                    this.idVentas = Convert.ToInt32(SqlCmd.Parameters["@idVentas"].Value);
                    foreach (DDetalle_Venta det in Detalles)
                    {
                        //Establecemos el codigo del ingreso que se autogenero
                        det.idVentas = this.idVentas;
                        //Llamamos al metodo insertar de la clase DetalleIngreso
                        //y le pasamos la conexion y la transaccion que debe de usar
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            //Si ocurre un error al insertar un detalle de ingreso salimos del for
                            break;
                        }
                        else
                        {
                            //Actualizamos el Stock

                            rpta = DisminuirStock(det.idDetalle_Ingreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    //Se inserto todo los detalles y confirmamos la transaccion
                    SqlTra.Commit();
                }
                else
                {
                    //Algun detalle no se inserto y negamos la transaccion
                    SqlTra.Rollback();
                }

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

            

        public string Eliminar(DVenta Ventas)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idVentas";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Ventas.idVentas;
                SqlCmd.Parameters.Add(ParIdventa);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";

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

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Ventas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_venta";
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

        //Método BuscarFechas
        public DataTable BuscarFechas(String TextoBuscar, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ventas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_venta_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable MostrarDetalle(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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

        public DataTable MostrarProducto_Venta_Nombre(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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

        public DataTable MostrarArticulo_Venta_Codigo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
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

