using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventas;
        private int _Iddetalle_Ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;
        public int idDetalle_venta
        {
            get { return _Iddetalle_venta; }
            set { _Iddetalle_venta = value; }
        }

        public int idVentas
        {
            get { return _Idventas; }
            set { _Idventas = value; }
        }

        public int idDetalle_Ingreso
        {
            get { return _Iddetalle_Ingreso; }
            set { _Iddetalle_Ingreso = value; }
        }


        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }


        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        //Constructores
        public DDetalle_Venta()
        {

        }
        public DDetalle_Venta(int iddetalle_venta, int idventas, int iddetalle_ingreso, int cantidad, decimal precio_venta, decimal descuento)
        {
            this.idDetalle_venta = iddetalle_venta;
            this.idVentas = idventas;
            this.idDetalle_Ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
            this.Descuento = descuento;

        }

        //Método Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_venta = new SqlParameter();
                ParIddetalle_venta.ParameterName = "@idDetalle_venta";
                ParIddetalle_venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idVentas";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_Venta.idVentas;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@idDetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = Detalle_Venta.idDetalle_Ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@Precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Venta.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@Descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);


                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
    }
}
