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
    public partial class FormProveedor : Form
    {
        public FormProveedor()
        {
            InitializeComponent();
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.mostrarProveedor(dgvProveedor);
            txtIDC.ReadOnly = true; // Deshabilitar el campo de ID al iniciar
        }

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.agregarProveedor(txtNomYAp, txtDni, txtTel, txtEmail);
            objetoProveedor.mostrarProveedor(dgvProveedor);
            objetoProveedor.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.eliminarProveedor(txtIDC);
            objetoProveedor.mostrarProveedor(dgvProveedor);
            objetoProveedor.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
            
        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.modificarProveedor(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
            objetoProveedor.mostrarProveedor(dgvProveedor);
            objetoProveedor.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void btnLimpiarC_Click(object sender, EventArgs e)
        {
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Proveedor objetoProveedor = new CL.Proveedor();
            objetoProveedor.seleccionarProveedor(dgvProveedor, txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }
    }
}
