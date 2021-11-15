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

namespace CapaPresentacion
{
    public partial class frmEmpleado : Form
    {
        private bool IsNuevo = false;
        
        private bool IsEditar = false;
        public frmEmpleado()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Empleado");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese Los Apellidos del Empleado");
            this.ttMensaje.SetToolTip(this.txtCedula, "Ingrese el Documento del Empleado");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Empleado");
        }

        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpia los controles del formulario
        private void Limpiar()
        {
            this.txtIdEmpleado.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtCedula.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtIdEmpleado.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cbSexo.Enabled = Valor;
            this.dtFechaNac.Enabled = Valor;
            this.txtCedula.Enabled = Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtEmail.ReadOnly = !Valor;
            this.cbAcceso.Enabled = Valor;
            this.txtUsuario.ReadOnly = !Valor;
            this.txtPassword.ReadOnly = !Valor;
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NEmpleado.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NEmpleado.BuscarCedula(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idEmpleado"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_nac"].Value);
            this.txtCedula.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cedula"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || txtCedula.Text == string.Empty || this.txtDireccion.Text == string.Empty || txtUsuario.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellido, "Ingrese un Valor");
                    errorIcono.SetError(txtCedula, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar 
                        rpta = NEmpleado.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), 
                        this.cbSexo.Text,dtFechaNac.Value,
                        txtCedula.Text, txtDireccion.Text,
                        txtTelefono.Text, txtEmail.Text, 
                        this.cbAcceso.Text,this.txtUsuario.Text, 
                        this.txtPassword.Text);

                    }
                    else
                    {
                        //Vamos a modificar un Trabajador
                        rpta = NEmpleado.Editar(Convert.ToInt32(this.txtIdEmpleado.Text), 
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), 
                        this.cbSexo.Text,dtFechaNac.Value,
                        txtCedula.Text, txtDireccion.Text,
                        txtTelefono.Text, txtEmail.Text, cbAcceso.Text, 
                        this.txtUsuario.Text, this.txtPassword.Text);
                    }
                    
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }

                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdEmpleado.Text = "";

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdEmpleado.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdEmpleado.Text = string.Empty;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteEmpleado frm = new frmReporteEmpleado();
            frm.ShowDialog();
        }
    }
}
