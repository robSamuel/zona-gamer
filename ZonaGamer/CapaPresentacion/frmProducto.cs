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
    public partial class frmProducto : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmProducto _Instancia;

        public static frmProducto GetInstancia()
        {
        if(_Instancia==null)
            {
            _Instancia = new frmProducto();
    }
            return _Instancia;

    }

        public void SetCategoria (string idcategoria, string nombre)
        {
            this.txtidCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }
        


        public frmProducto()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Producto");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Ingrese la Categoria del Producto");
            this.ttMensaje.SetToolTip(this.cbidPresentacion, "Ingrese la Presentacion del Producto");

            this.txtidCategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
        
        
        }

        //Mostrar mensaje de confirmacion

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Limpiar todos los controles del formulario

        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtidCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdProducto.Text = string.Empty;

        }

        //Habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbidPresentacion.Enabled = valor;
            this.txtIdProducto.ReadOnly = !valor;


        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //ALT+124
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

        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[7].Visible = false;




        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscarnombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void LlenarComboPresentacion()
        {
            cbidPresentacion.DataSource = NPresentacion.Mostrar();
            cbidPresentacion.ValueMember = "idPresentacion";
            cbidPresentacion.DisplayMember = "Nombre";
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                if (txtNombre.Text == string.Empty || txtidCategoria.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProducto.Insertar(this.txtCodigo.Text,this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(),Convert.ToInt32(this.txtidCategoria.Text),
                            Convert.ToInt32(this.cbidPresentacion.SelectedValue));

                    }

                    else
                    {
                        rpta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text),
                            this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), 
                            this.txtDescripcion.Text.Trim(), Convert.ToInt32(this.txtidCategoria.Text),
                            Convert.ToInt32(this.cbidPresentacion.SelectedValue));
                           
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Inserto de forma correcta el registro");

                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProducto.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }

            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idProducto"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);

            this.txtidCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            this.cbidPresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idPresentacion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;

            }
            else
            {
                this.dataListado.Columns[0].Visible = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registro", "Sistemas de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NProducto.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente el registro");

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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Producto form = new frmVistaCategoria_Producto();
            form.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteProducto frm = new frmReporteProducto();
            frm.ShowDialog();
        }
    }
}
