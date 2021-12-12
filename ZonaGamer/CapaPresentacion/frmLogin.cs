using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmLogin : Form 
    {

        public frmLogin()
        {
            InitializeComponent();
            LblHoras.Text = DateTime.Now.ToString();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHoras.Text = DateTime.Now.ToString();
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int intentos = 0;
        int contador = 3;
        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            if (intentos != 2)
            {

                DataTable Datos = NEmpleado.Login(this.txtUsuario.Text, (this.txtPassword.Text));

                if (Datos.Rows.Count == 0)
                {


                    MessageBox.Show("Error de autentificacion, verifique usuario y/o Contraseña por favor", "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos++;
                     
                }
                else
                {
                    frmPrincipal frm = new frmPrincipal();
                    frm.idEmpleado = Datos.Rows[0][0].ToString();
                    frm.Apellido = Datos.Rows[0][1].ToString();
                    frm.Nombre = Datos.Rows[0][2].ToString();
                    frm.Acceso = Datos.Rows[0][3].ToString();

                    frm.Show();
                    this.Hide();
                }
            
                }else

                    {
                MessageBox.Show("Ha Alcanzado el nivel maximo de intento");
                MessageBox.Show("El sistema de cerrara, Gracias");
                    Application.Exit();
                        }
            txtUsuario.Clear();
            txtPassword.Clear();
        }

       
        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
