using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Metodo insertar

        public static string Insertar(string razon_social,string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_social = razon_social;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.email = email;
            return Obj.Insertar(Obj);
        }

        //Metodo editar 
        public static string Editar(int idproveedor,string razon_social, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();
            Obj.idProveedor = idproveedor;
            Obj.Razon_social = razon_social;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.email = email;
            return Obj.Editar(Obj);
        }

        //metodo eliminar 

        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.idProveedor = idproveedor;


            return Obj.Eliminar(Obj);
        }

        //Metodo mostrar 
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //BuscarRazon_social
        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);



        }

        //BuscarNum_documento

        public static DataTable BuscarNum_documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_documento(Obj);



        }
    }
}
