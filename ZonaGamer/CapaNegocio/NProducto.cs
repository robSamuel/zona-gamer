using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProducto
    {
        //Metodo insertar 

        public static string Insertar(string codigo,string nombre, string descripcion, int idcategoria, int idpresentacion)
        {
            DProducto Obj = new DProducto();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;

            return Obj.Insertar(Obj);
        }

        //Metodo editar 
        public static string Editar(int idproducto, string codigo, string nombre, string descripcion, int idcategoria, int idpresentacion)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idproducto;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.IdCategoria = idcategoria;
            Obj.IdPresentacion = idpresentacion;

            return Obj.Editar(Obj);
        }

        //metodo eliminar 

        public static string Eliminar(int idproducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idproducto;


            return Obj.Eliminar(Obj);
        }

        //Metodo mostrar
        public static DataTable Mostrar()
        {
            return new DProducto().Mostrar();
        }

        //Buscar nombre  

        public static DataTable BuscarNombre(string textobuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }

        //Metodo mostrar
        public static DataTable Stock_Producto()
        {
            return new DProducto().Stock_Producto();
        }

    }
}
