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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.mostrarProductos(dgvProducto);
            txtIDP.ReadOnly = true;
        }

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.agregarProducto(txtNombreP, txtPrecioP, txtStockP);
            objetoProducto.mostrarProductos(dgvProducto);
            objetoProducto.limpiarCampos(txtIDP, txtNombreP, txtPrecioP, txtStockP);
        }

        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.seleccionarProducto(dgvProducto, txtIDP, txtNombreP, txtPrecioP, txtStockP);

        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.modificarProducto(txtIDP, txtNombreP, txtPrecioP, txtStockP);
            objetoProducto.mostrarProductos(dgvProducto);
            objetoProducto.limpiarCampos(txtIDP, txtNombreP, txtPrecioP, txtStockP);
        }

        private void btnLimpiarP_Click(object sender, EventArgs e)
        {
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.limpiarCampos(txtIDP, txtNombreP, txtPrecioP, txtStockP);
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            CL.Producto objetoProducto = new CL.Producto();
            objetoProducto.eliminarProducto(txtIDP);
            objetoProducto.mostrarProductos(dgvProducto);
            objetoProducto.limpiarCampos(txtIDP, txtNombreP, txtPrecioP, txtStockP);
        }
    }
}
