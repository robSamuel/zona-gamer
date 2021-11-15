using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteProducto : Form
    {
        public frmReporteProducto()
        {
            InitializeComponent();
        }

        private void frmReporteProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_ingreso' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ingresoTableAdapter.Fill(this.dsPrincipal.spmostrar_ingreso);
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_producto' Puede moverla o quitarla según sea necesario.
            this.spmostrar_productoTableAdapter.Fill(this.dsPrincipal.spmostrar_producto);

            this.reportViewer1.RefreshReport();
        }
    }
}
