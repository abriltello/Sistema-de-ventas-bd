using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas_y_stock___BD.CP
{
    public partial class FormFacturaCompra : Form
    {
        public FormFacturaCompra()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarF_Click(object sender, EventArgs e)
        {
            CL.Reporte objetoReporte = new CL.Reporte();
            objetoReporte.buscarFacturaMostrarDatosProveedor(txtBuscarF, lblNFact, lblFechaVenta, lblNomYAp, lblDniC, lblTelC, lblEmailC);
        }
    }
}
