using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //Metodo insertar en la capaDatos

        public static string Insertar(string nombre, string descripcion) 
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //Metodo editar capaDatos
        public static string Editar(int idCategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        //metodo eliminar capadatos

        public static string Eliminar(int idCategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            

            return Obj.Eliminar(Obj);
        }

        //Metodo mostrar capa datos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //Buscar nombre capa dato

        public static DataTable BuscarNombre( string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }
    }
}
