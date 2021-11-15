using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        //Método Insertar que llama al método Insertar de la clase DVenta
        //de la CapaDatos
        public static string Insertar(int idcliente, int idempleado, DateTime fecha, 
            string tipo_comprobante, string serie, string correlativo, 
            decimal igv, string estado, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.idCliente = idcliente;
            Obj.idEmpleado = idempleado;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List <DDetalle_Venta> Detalle = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.idDetalle_Ingreso = Convert.ToInt32(row["idDetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["Precio_Venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                Detalle.Add(detalle);

            }


            return Obj.Insertar(Obj, Detalle);
        }

        //Método Anular que llama al método Anular de la clase DVenta
        //de la CapaDatos
        public static string Eliminar(int idventas)
        {
            DVenta Obj = new DVenta();
            Obj.idVentas = idventas;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Método BuscarFechas que llama al método BuscarFechas
        //de la clase DVenta de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
    }
}
