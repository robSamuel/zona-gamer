using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //Metodo insertar 

        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //Metodo editar 
        public static string Editar(int idPresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idPresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        //metodo eliminar 

        public static string Eliminar(int idPresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idPresentacion;


            return Obj.Eliminar(Obj);
        }

        //Metodo mostrar
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //Buscar nombre  

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }
    }
}
