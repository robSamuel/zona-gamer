using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Método Insertar que llama al método Insertar de la clase DIngreso
        //de la CapaDatos
        public static string Insertar(int idempleado, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.idEmpleado = idempleado;
            Obj.idProveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List <DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.idProducto = Convert.ToInt32(row["idProducto"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["Precio_Compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["Precio_Venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["Stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["Stock_Actual"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["Fecha_Produccion"].ToString());             
                detalles.Add(detalle);
            }


            return Obj.Insertar(Obj, detalles);
        }

        //Método Anular que llama al método Anular de la clase DIngreso
        //de la CapaDatos
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.idIngreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCliente de la CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }

    }
}
