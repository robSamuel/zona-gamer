﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int _Idingreso;
        private int _Idproveedor;
        private int _Idempleado;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int idIngreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }

        public int idProveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }

        public int idEmpleado
        {
            get { return _Idempleado; }
            set { _Idempleado = value; }
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

        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idempleado, int idproveedor, 
            DateTime fecha, string tipo_comprobante, string serie, 
            string correlativo, decimal igv, string estado)
        {
            this.idIngreso = idingreso;
            this.idEmpleado = idempleado;
            this.idProveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }

        public string Insertar(DIngreso Ingreso, List <DDetalle_Ingreso> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();
            try
            {
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idIngreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idEmpleado";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Ingreso.idEmpleado;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Ingreso.idProveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@Tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Ingreso.Tipo_comprobante;
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@Correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@Igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Conexion.OpenCN()" : "NO se Ingreso el Registro";

                // TODO: Change these validations with rpta in order to use SqlCmd.ExecuteNonQuery()
                if (rpta.Equals("OK"))
                {
                    this.idIngreso = Convert.ToInt32(SqlCmd.Parameters["@idIngreso"].Value);

                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.idIngreso = this.idIngreso;
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (rpta.Equals("OK"))
                    SqlTra.Commit();
                else
                    SqlTra.Rollback();
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
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
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

        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spanular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idIngreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.idIngreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Registro anulado" : "NO se anulo el Ingreso";
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

        public DataTable BuscarFechas(String TextoBuscar, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
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
            DataTable DtResultado = new DataTable("Detalle_Ingreso");
            SqlConnection SqlCon = Conexion.OpenCN();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_ingreso";
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
