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
    public partial class FormPorVenta : Form
    {
        public FormPorVenta()
        {
            InitializeComponent();

            //CLIENTES
            txtIDCliente.ReadOnly = true;
            txtNomyAp.ReadOnly = true;
            txtDni.ReadOnly = true;
            txtTel.ReadOnly = true;
            txtEmail.ReadOnly = true;

            //PRODUCTOS
            txtIDProducto.ReadOnly = true;
            txtNomProd.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtStock.ReadOnly = true;
            txtPrecioVenta.ReadOnly = true;

            //FACTURA
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.mostrarUltimaFactura(lblUltimaFac);

        } 
        //CLIENTES
        private void txtBuscarF_TextChanged(object sender, EventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.buscarCliente(txtBuscarF, dgvSelecCliente);
        } 

        private void dgvSelecCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.seleccionarClienteVenta(dgvSelecCliente, txtIDCliente, txtNomyAp, txtDni, txtTel, txtEmail);
        }


        //PRODUCTOS
        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.buscarProducto(txtBuscarProd, dgvSelecProducto);
        }

        private void dgvSelecProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.seleccionarProductoVenta(dgvSelecProducto, txtIDProducto,txtNomProd, txtPrecio, txtStock, txtPrecioVenta);
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            txtPrecioVenta.ReadOnly = false;
        }

        private void btbDeshabilitar_Click(object sender, EventArgs e)
        {
            txtPrecioVenta.ReadOnly = true;
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.pasarProductosVenta(dgvCarrito, txtIDProducto, txtNomProd, txtPrecioVenta, txtCantidadP, txtStock);
            objetoVenta.calcularTotalPagar(dgvCarrito, lblTotalFact);
        }

        private void btnEliminarFact_Click(object sender, EventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.eliminarProductoSeleccionado(dgvCarrito);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.crearFactura(txtIDCliente);
            objetoVenta.realizarVenta(dgvCarrito);
            objetoVenta.limpiarCamposAlPagar(txtBuscarF, dgvSelecCliente, txtBuscarProd, dgvSelecProducto,
                                             dgvCarrito,txtIDCliente, txtNomyAp, txtDni, txtTel, txtEmail, txtIDProducto, txtNomProd,txtPrecio, txtStock, txtCantidadP, lblTotalFact, txtPrecioVenta);
            objetoVenta.mostrarUltimaFactura(lblUltimaFac);

        }

        private void FormPorVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarRep_Click(object sender, EventArgs e)
        {

        }

        private void dgvSelecCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {

        }
    }
}
