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
    public partial class frmReporteCategoria : Form
    {
        public frmReporteCategoria()
        {
            InitializeComponent();
        }

        private void frmReporteCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_Categoria' Puede moverla o quitarla según sea necesario.
            this.spmostrar_CategoriaTableAdapter.Fill(this.dsPrincipal.spmostrar_Categoria);

            this.reportViewer1.RefreshReport();
        }
    }
}
