using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Metodos

        //Metodo insertar

        public static string Insertar(string nombre, string apellido, string sexo, DateTime fecha_nac, 
            string tipo_documento,string num_documento,string direccion,string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_nac = fecha_nac;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Insertar(Obj);
        }

        //Metodo editar 
        public static string Editar(int idcliente, string nombre, string apellido, string sexo, DateTime fecha_nac,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.idCliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_nac = fecha_nac;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        //metodo eliminar 

        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.idCliente = idcliente;


            return Obj.Eliminar(Obj);
        }

        //Metodo mostrar 
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //BuscarRazon_social
        public static DataTable BuscarApellido(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarApellido(Obj);



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
