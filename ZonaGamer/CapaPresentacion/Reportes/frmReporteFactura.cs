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
    public partial class frmReporteFactura : Form
    {
        private int _idVenta;
        public int idVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }
        public frmReporteFactura()
        {
            InitializeComponent();
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            try
            {

                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_venta' Puede moverla o quitarla según sea necesario.

                this.spreporte_ventaTableAdapter.Fill(this.dsPrincipal.spreporte_venta, idVenta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();

            }
        }
    }

}

