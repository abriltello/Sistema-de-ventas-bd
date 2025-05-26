using System;
using System.Windows.Forms;

namespace Sistema_de_ventas_y_stock___BD
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();

            CD.Conexion objetoConexion = new CD.Conexion();
            objetoConexion.Conectar();
        }

        private void vENDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormPorVenta objetoformPorVenta = new CP.FormPorVenta();
            objetoformPorVenta.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormClientes objetoformClientes = new CP.FormClientes();
            objetoformClientes.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormProducto objetoformProducto = new CP.FormProducto();
            objetoformProducto.Show();
        }

        private void buscarComprobateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormFactura objetoformFactura = new CP.FormFactura();
            objetoformFactura.Show();
        }

        private void consultarPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormReportePorFecha objetoformReportePorFecha = new CP.FormReportePorFecha();
            objetoformReportePorFecha.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormProveedor objetoformProveedor = new CP.FormProveedor();
            objetoformProveedor.Show();
        }

        private void cOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormDetalleCompra objetoformDetalleCompra = new CP.FormDetalleCompra();
            objetoformDetalleCompra.Show();
        }

        private void buscarComprobanteCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CP.FormFacturaCompra formFacturaCompra = new CP.FormFacturaCompra();
            formFacturaCompra.Show();
        }
    }
}
