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
    public partial class FormDetalleCompra : Form
    {
        public FormDetalleCompra()
        {
            InitializeComponent();
            //PROVEEDORES
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

            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.mostrarUltimaFacturaCompra(lblUltimaFac);

        }

        //Proveedores
        private void txtBuscarF_TextChanged(object sender, EventArgs e)
        {
            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.buscarProveedor(txtBuscarF, dgvSelecCliente);
        }
        private void dgvSelecCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.seleccionarProveedorCompra(dgvSelecCliente, txtIDCliente, txtNomyAp, txtDni, txtTel, txtEmail);
        }

        //Productos
        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            CL.Venta objetoventa = new CL.Venta();
            objetoventa.buscarProducto(txtBuscarProd, dgvSelecProducto);
        } 
        private void dgvSelecProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Venta objetoVenta = new CL.Venta();
            objetoVenta.seleccionarProductoVenta(dgvSelecProducto, txtIDProducto, txtNomProd, txtPrecio, txtStock, txtPrecioVenta);
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
            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.pasarProductosCompra(dgvCarrito, txtIDProducto, txtNomProd, txtPrecioVenta,txtCantidadP, txtStock);
            objetoCompra.calcularTotalPagar(dgvCarrito, lblTotalFact);
        }
        

        private void btnEliminarFact_Click(object sender, EventArgs e)
        {
            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.eliminarProductoSeleccionado(dgvCarrito);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            CL.Compra objetoCompra = new CL.Compra();
            objetoCompra.crearFacturaCompra(txtIDCliente);
            objetoCompra.realizarCompra(dgvCarrito);
            objetoCompra.limpiarCamposAlPagar(txtBuscarF, dgvSelecCliente, txtBuscarProd, dgvSelecProducto, dgvCarrito, txtIDCliente, txtNomyAp, txtDni, txtTel,txtEmail, txtIDProducto, txtNomProd, txtPrecio, txtStock, txtCantidadP, lblTotalFact);
            objetoCompra.mostrarUltimaFacturaCompra(lblUltimaFac);
        }

        private void txtBuscarProd_TextChanged_1(object sender, EventArgs e)
        {
            CL.Venta objetoventa = new CL.Venta();
            objetoventa.buscarProducto(txtBuscarProd, dgvSelecProducto);
        }
    }
}
