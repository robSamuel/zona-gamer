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
    public partial class frmIngreso : Form
    {
        public int idEmpleado;


        private bool IsNuevo = false;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;


        private static frmIngreso _Instancia;

        public static frmIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmIngreso();
            }
            return _Instancia;
        }

        public void setProveedor(string idproveedor, string nombre)
        {
            this.txtidProveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }

        public void setProducto(string idproducto, string nombre)
        {
            this.txtidProducto.Text = idproducto;
            this.txtProducto.Text = nombre;
        }
        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione un Proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtStockinicial, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtProducto, "Seleccione el artículo");
            this.txtidProveedor.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtidProducto.Visible = false;
            this.txtProducto.ReadOnly = true;
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
            this.txtIdIngreso.Text = string.Empty;
            this.txtidProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;

            this.txtIgv.Text = "18";
            this.crearTabla();

        }
        private void LimpiarDetalle()
        {
            this.txtidProducto.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtStockinicial.Text = string.Empty;
            this.txtstockActual.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }



        //Habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.Enabled = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtStockinicial.ReadOnly = !valor;
            this.txtstockActual.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFecha_Produccion.Enabled = valor;
            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo) //ALT+124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Método BuscarFecha
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
            this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void MostrarDetalles()
        {
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);


        }

        //Crea la tabla de Detalle 
        private void crearTabla()
        {
            //Crea la tabla con el nombre de Detalle
            this.dtDetalle = new DataTable("Detalle");
            //Agrega las columnas que tendra la tabla
            this.dtDetalle.Columns.Add("idProducto", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Precio_Compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Stock_Inicial", System.Type.GetType("System.Int32"));

            this.dtDetalle.Columns.Add("Stock_Actual", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionamos nuestro datagridview con nuestro datatable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }




        private void frmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso vista = new frmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmVistaProducto_Ingreso vista = new frmVistaProducto_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registro", "Sistemas de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anulo Correctamente el Ingreso");

                            }

                            else
                            {
                                this.MensajeError(rpta);
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
                this.dataListado.Columns[0].Visible = true;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.LimpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string rpta = "";
                if (this.txtidProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty || txtCorrelativo.Text == string.Empty || txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtProveedor, "Seleccione un Proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese la serie del comprobante");
                    errorIcono.SetError(txtCorrelativo, "Ingrese el número del comprobante");
                    errorIcono.SetError(txtIgv, "Ingrese el porcentaje de IGV");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(idEmpleado, Convert.ToInt32(txtidProveedor.Text),
                        dtFecha.Value, cbTipo_Comprobante.Text,
                        txtSerie.Text, txtCorrelativo.Text,
                        Convert.ToDecimal(txtIgv.Text), "EMITIDO", dtDetalle);

                    }

                    if (rpta.Equals("OK"))
                    {
                        if(this.IsNuevo)
                        {
                            this.MensajeOk("Se insertó de forma correcta el registro");
                        }
                        


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtidProducto.Text == string.Empty || this.txtStockinicial.Text == string.Empty || this.txtstockActual.Text == string.Empty || txtPrecio_Compra.Text == string.Empty || txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtProducto, "Seleccione un Artículo");
                    errorIcono.SetError(txtStockinicial, "Ingrese el stock inicial");
                    errorIcono.SetError(txtPrecio_Compra, "Ingrese el precio de Compra");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese el precio de Venta");
                }
                else
                {
                    //Variable que va a indicar si podemos registrar el detalle
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idProducto"]) == Convert.ToInt32(this.txtidProducto.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el artículo en el detalle");
                        }
                    }
                    //Si podemos registrar el producto en el detalle
                    if (registrar)
                    {
                        //Calculamos el sub total del detalle sin descuento
                        decimal subTotal = Convert.ToDecimal(this.txtStockinicial.Text) * Convert.ToDecimal(txtPrecio_Compra.Text);
                        totalPagado = totalPagado + subTotal;
                        //Agregamos al fila a nuestro datatable
                        DataRow row = this.dtDetalle.NewRow();
                        row["idProducto"] = Convert.ToInt32(this.txtidProducto.Text);
                        row["Producto"] = this.txtProducto.Text;
                        row["Precio_Compra"] = Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        row["Precio_Venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["Stock_inicial"] = Convert.ToInt32(this.txtStockinicial.Text);
                        row["Stock_Actual"] = Convert.ToInt32(this.txtStockinicial.Text);
                        row["Fecha_produccion"] = this.dtFecha_Produccion.Value;
                        row["subTotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                //Indice dila actualmente seleccionado y que vamos a eliminar
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                //Fila que vamos a eliminar
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuimos el total a pagar
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subTotal"].ToString());
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idIngreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Correlativo"].Value);

            this.MostrarDetalles();
            this.tabControl1.SelectedIndex = 1;
        }

        private void txtPrecio_Compra_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPagado_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblTotal_Pagado_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteIngreso frm = new frmReporteIngreso();
            frm.idIngreso = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idIngreso"].Value);


            frm.ShowDialog();
        }
    }
}
