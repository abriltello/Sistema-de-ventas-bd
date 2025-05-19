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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
            // Cargar los datos de los clientes al iniciar el formulario
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.mostrarClientes(dgvCliente);
            txtIDC.ReadOnly = true; // Deshabilitar el campo de ID al iniciar
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.agregarCliente(txtNomYAp, txtDni, txtTel, txtEmail);
            objetoCliente.mostrarClientes(dgvCliente);
            objetoCliente.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.seleccionarCliente(dgvCliente, txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void btnModificarC_Click(object sender, EventArgs e)
        {
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.modificarCliente(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
            objetoCliente.mostrarClientes(dgvCliente);
            objetoCliente.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void btnLimpiarC_Click(object sender, EventArgs e)
        {
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }

        private void btnEliminarC_Click(object sender, EventArgs e)
        {
            CL.Cliente objetoCliente = new CL.Cliente();
            objetoCliente.eliminarCliente(txtIDC);
            objetoCliente.mostrarClientes(dgvCliente);
            objetoCliente.limpiarCampos(txtIDC, txtNomYAp, txtDni, txtTel, txtEmail);
        }
    }
}
