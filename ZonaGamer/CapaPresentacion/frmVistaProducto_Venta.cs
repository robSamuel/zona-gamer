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
    public partial class frmVistaProducto_Venta : Form
    {
        public frmVistaProducto_Venta()
        {
            InitializeComponent();
        }

        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }


        //Metodo BuscarNombre
        private void MostrarProducto_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void MostrarProducto_Venta_Codigo()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        

        private void frmVistaProducto_Venta_Load(object sender, EventArgs e)
        {
           
;        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarProducto_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarProducto_Venta_Nombre();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            Decimal par3, par4;
            int par5;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idDetalle_ingreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Stock_actual"].Value);
            form.setProducto(par1,par2,par3,par4,par5);
            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
