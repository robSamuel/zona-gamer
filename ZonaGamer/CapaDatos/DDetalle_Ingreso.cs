using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        //Variables
        private int _idDetalle_ingreso;
        private int _idIngreso;
        private int _idProducto;
        private decimal _Precio_Compra;
        private decimal _precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;


        //Propiedades
        public int idDetalle_ingreso
        {
            get { return _idDetalle_ingreso; }
            set { _idDetalle_ingreso = value; }
        }

        public int idIngreso
        {
            get { return _idIngreso; }
            set { _idIngreso = value; }
        }

        public int idProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public decimal Precio_Compra
        {
            get { return _Precio_Compra; }
            set { _Precio_Compra = value; }
        }

        public decimal Precio_Venta
        {
            get { return _precio_Venta; }
            set { _precio_Venta = value; }
        }

        public int Stock_Inicial
        {
            get { return _Stock_Inicial; }
            set { _Stock_Inicial = value; }
        }

        public int Stock_Actual
        {
            get { return _Stock_Actual; }
            set { _Stock_Actual = value; }
        }


        public DateTime Fecha_Produccion
        {
            get { return _Fecha_Produccion; }
            set { _Fecha_Produccion = value; }
        }

        //Constructores
        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idproducto, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion)
        {
            this.idDetalle_ingreso = iddetalle_ingreso;
            this.idIngreso = idingreso;
            this.idProducto = idproducto;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            

        }

        //Método Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, 
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@idDetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idIngreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.idIngreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idProducto";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Detalle_Ingreso.idProducto;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@Precio_Compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Decimal;
                ParPrecio_Compra.Precision = 4;
                ParPrecio_Compra.Scale = 2;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@Precio_Venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Decimal;
                ParPrecio_Venta.Precision = 4;
                ParPrecio_Venta.Scale = 2;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@Stock_Actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@Stock_Inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@Fecha_Produccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.DateTime;
                ParFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);


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
