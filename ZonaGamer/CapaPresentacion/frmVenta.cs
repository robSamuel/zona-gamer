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
    public partial class frmVenta : Form
    {
        private bool IsNuevo = false;
        public int idEmpleado;
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void setCliente(string idCliente, string Nombre)
        {
            this.txtidCliente.Text = idCliente;
            this.txtCliente.Text = Nombre; 
        }

        public void setProducto(string idDetalle_ingreso, string Nombre,
            decimal Precio_Compra, decimal Precio_Venta, int stock)
        {
            this.txtidProducto.Text = idDetalle_ingreso;
            this.txtProducto.Text = Nombre;
            this.txtPrecio_Compra.Text = Convert.ToString(Precio_Compra);
            this.txtPrecioVenta.Text = Convert.ToString(Precio_Venta);
            this.txtStock_actual.Text = Convert.ToString(stock);
           
        }
        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el número del comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtProducto, "Seleccione el artículo");
            this.txtidCliente.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtidProducto.Visible = false;
            this.txtProducto.ReadOnly = true;
            this.txtPrecio_Compra.ReadOnly = true;
            this.txtStock_actual.ReadOnly = true;
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtidVentas.Text = string.Empty;
            this.txtidCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = "18";
            this.lblTotal_Pagado.Text = "0,0";
            this.txtDescuento.Text = "0";
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtidProducto.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtStock_actual.Text = String.Empty;
            this.txtDescuento.Text = "0";
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtidVentas.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.Enabled = valor;
            this.dtFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnBuscarProducto.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
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

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFecha
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Método BuscarDetalles
        private void MostrarDetalles()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtidVentas.Text);

        }

        //Crea la tabla de Detalle 
        private void crearTabla()
        {
            //Crea la tabla con el nombre de Detalle
            this.dtDetalle = new DataTable("Detalle");
            //Agrega las columnas que tendra la tabla
            this.dtDetalle.Columns.Add("idDetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            //Relacionamos nuestro datagridview con nuestro datatable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();

        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta vista = new frmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmVistaProducto_Venta vista = new frmVistaProducto_Venta();
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
                Opcion = MessageBox.Show("Realmente Desea Anular la(s) venta(s)", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente la venta");
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidVentas.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idVentas"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.MostrarDetalles();
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se inserto 
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtidCliente.Text == string.Empty || this.txtSerie.Text == string.Empty || txtCorrelativo.Text == string.Empty || txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCliente, "Seleccione un Proveedor");
                    errorIcono.SetError(txtSerie, "Ingrese la serie del comprobante");
                    errorIcono.SetError(txtCorrelativo, "Ingrese el número del comprobante");
                    errorIcono.SetError(txtIgv, "Ingrese el porcentaje de IGV");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Ingreso 
                        Rpta = NVenta.Insertar(Convert.ToInt32(txtidCliente.Text),
                            idEmpleado,
                        dtFecha.Value, cbTipo_Comprobante.Text,
                        txtSerie.Text, txtCorrelativo.Text,
                        Convert.ToDecimal(txtIgv.Text), "EMITIDO", dtDetalle);

                    }


                    if (Rpta.Equals("OK"))
                    {

                        this.MensajeOk("Se insertó de forma correcta el registro");


                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            this.txtidVentas.Text = string.Empty;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtProducto.Text == string.Empty || this.txtCantidad.Text == string.Empty
                    || this.txtDescuento.Text == string.Empty || txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtidProducto, "Seleccione un Artículo");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                    errorIcono.SetError(txtDescuento, "Ingrese el precio de Venta");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese el precio de Venta");
                }
                else
                {
                    //Variable que va a indicar si podemos registrar el detalle
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idDetalle_ingreso"]) == Convert.ToInt32(this.txtidProducto.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el artículo en el detalle");
                        }
                    }
                    //Si podemos registrar el producto en el detalle
                    if (registrar && Convert.ToInt32(this.txtCantidad.Text) <= Convert.ToInt32(this.txtStock_actual.Text)) 
                    {
                        //Calculamos el sub total del detalle sin descuento
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        //Agregamos al fila a nuestro datatable
                        DataRow row = this.dtDetalle.NewRow();
                        row["idDetalle_ingreso"] = Convert.ToInt32(this.txtidProducto.Text);
                        row["Producto"] = this.txtProducto.Text;
                        row["Cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["Precio_Venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["Descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subTotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }
                    else
                    {
                        this.MensajeError("No hay Cantidad Suficiente");
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

                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;

                DataRow row = this.dtDetalle.Rows[indiceFila];
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subTotal"].ToString());
                this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.idVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idVentas"].Value);
            frm.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.idVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idVentas"].Value);
            frm.ShowDialog();
        }
    }
}
