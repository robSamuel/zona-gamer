using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEmpleado
    {
        //Método Insertar
        public static string Insertar(string Nombre,
            string Apellido, string Sexo, DateTime Fecha_nac,
            string Cedula, string Direccion, string Telefono,
            string Email, string Acceso, string Usuario, string Password
            )
        {
            DEmpleado Obj = new DEmpleado();
            
           
            Obj.nombre = Nombre;
            Obj.apellido = Apellido;
            Obj.sexo = Sexo;
            Obj.fecha_Nac = Fecha_nac;
            Obj.cedula = Cedula;
            Obj.direccion = Direccion;
            Obj.telefono = Telefono;
            Obj.email = Email;
            Obj.acceso = Acceso;
            Obj.usuario = Usuario;
            Obj.password = Password;
            

            return Obj.Insertar(Obj);
        }

        //Método Editar 
        public static string Editar(int idEmpleado, string Nombre,
            string Apellido, string Sexo, DateTime Fecha_nac,
            string Cedula, string Direccion, string Telefono,
            string Email, string Acceso, string Usuario, string Password
            )
        {
            DEmpleado Obj = new DEmpleado();
            Obj.idempleado = idEmpleado;
            Obj.nombre = Nombre;
            Obj.apellido = Apellido;
            Obj.sexo = Sexo;
            Obj.fecha_Nac = Fecha_nac;
            Obj.cedula = Cedula;
            Obj.direccion = Direccion;
            Obj.telefono = Telefono;
            Obj.email = Email;
            Obj.acceso = Acceso;
            Obj.usuario = Usuario;
            Obj.password = Password;
           
            return Obj.Editar(Obj);
        }

        //Método Eliminar 
        public static string Eliminar(int idEmpleado)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.idempleado = idEmpleado;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar 
        public static DataTable Mostrar()
        {
            return new DEmpleado().Mostrar();
        }

        //Método BuscarApellidos 
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarCedula
        public static DataTable BuscarCedula(string textobuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCedula(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.usuario = usuario;
            Obj.password = password;
            return Obj.Login(Obj);
        }

    }
}
