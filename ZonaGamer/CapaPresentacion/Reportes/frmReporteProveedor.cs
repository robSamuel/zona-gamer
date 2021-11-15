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
    public partial class frmReporteProveedor : Form
    {
        public frmReporteProveedor()
        {
            InitializeComponent();
        }

        private void frmReporteProveedor_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmpstrar_proveedor' Puede moverla o quitarla según sea necesario.
            this.spmpstrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmpstrar_proveedor);

            this.reportViewer1.RefreshReport();
        }
    }
}
