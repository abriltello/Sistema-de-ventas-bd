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
    public partial class FormReportePorFecha : Form
    {
        public FormReportePorFecha()
        {
            InitializeComponent();
        }

        private void btnBuscarRep_Click(object sender, EventArgs e)
        {
            CL.Reporte objetoReporte = new CL.Reporte();
            objetoReporte.mostrarTotalVentaPorFecha(dtpDesde, dtpHasta, dgvBuscarR, lblIngresosT);
        }
    }
}
