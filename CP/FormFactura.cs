﻿using System;
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
    public partial class FormFactura : Form
    {
        public FormFactura()
        {
            InitializeComponent();
        }

        private void btnBuscarF_Click(object sender, EventArgs e)
        {
            CL.Reporte objetoReporte = new CL.Reporte();
            objetoReporte.buscarFacturaYDatosCliente(txtBuscarF, lblNFact, lblFechaVenta, lblNomYAp, lblDniC, lblTelC, lblEmailC);
            objetoReporte.buscarFacturaYDatosProductos(txtBuscarF, dataGridView1, lblTotalF);
        }
    }
}
