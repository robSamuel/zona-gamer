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
    public partial class frmImprimirConsulta : Form
    {
        public frmImprimirConsulta()
        {
            InitializeComponent();
        }

        private void frmImprimirConsulta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spstock_producto' Puede moverla o quitarla según sea necesario.
            this.spstock_productoTableAdapter.Fill(this.dsPrincipal.spstock_producto);

            this.reportViewer1.RefreshReport();

        }
    }
}
