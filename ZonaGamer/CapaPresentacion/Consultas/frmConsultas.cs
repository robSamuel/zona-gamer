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

namespace CapaPresentacion.Consultas
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();

            
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;





        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Stock_Producto();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimirConsulta frm = new frmImprimirConsulta();



            frm.ShowDialog();
        }
    }
}
