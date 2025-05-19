using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_ventas_y_stock___BD.CD;

namespace Sistema_de_ventas_y_stock___BD.CL
{
    internal class Cliente
    {
        public void mostrarClientes(DataGridView tablaTotalClientes)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("ID", typeof(int));
            modelo.Columns.Add("Nombre y Apellido", typeof(string));
            modelo.Columns.Add("DNI", typeof(int));
            modelo.Columns.Add("Telefono", typeof(string));
            modelo.Columns.Add("Email", typeof(string));

            tablaTotalClientes.DataSource = modelo;

            string sql = "select idcliente, nombres, dni, telefono, email from cliente;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                DataSet ds = new DataSet();

                adaptador.Fill(ds);

                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    objetoCliente.IdCliente = Convert.ToInt32(row["idcliente"]);
                    objetoCliente.Nombres = row["nombres"].ToString();
                    objetoCliente.Dni = Convert.ToInt32(row["dni"]);
                    objetoCliente.Telefono = row["telefono"].ToString();
                    objetoCliente.Email = row["email"].ToString();

                    modelo.Rows.Add(objetoCliente.IdCliente, objetoCliente.Nombres, objetoCliente.Dni, objetoCliente.Telefono, objetoCliente.Email);

                }
                tablaTotalClientes.DataSource = modelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los clientes: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void agregarCliente(TextBox nombres, TextBox dni, TextBox telefono, TextBox email)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            string consulta = "insert into cliente (nombres, dni, telefono, email) values (@nombres, @dni, @telefono, @email);";

            try
            {
                objetoCliente.Nombres = nombres.Text;
                objetoCliente.Dni = Convert.ToInt32(dni.Text);
                objetoCliente.Telefono = telefono.Text;
                objetoCliente.Email = email.Text;

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombres", objetoCliente.Nombres);
                comando.Parameters.AddWithValue("@dni", objetoCliente.Dni);
                comando.Parameters.AddWithValue("@telefono", objetoCliente.Telefono);
                comando.Parameters.AddWithValue("@email", objetoCliente.Email);

                comando.ExecuteNonQuery();

                MessageBox.Show("Cliente agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el cliente: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }

        }

        public void seleccionarCliente(DataGridView tablaTotalClientes, TextBox idCliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email)
        {
            int fila = tablaTotalClientes.CurrentRow.Index;

            try
            {
                if (fila >= 0)
                {
                    idCliente.Text = tablaTotalClientes.Rows[fila].Cells[0].Value.ToString();
                    nombres.Text = tablaTotalClientes.Rows[fila].Cells[1].Value.ToString();
                    dni.Text = tablaTotalClientes.Rows[fila].Cells[2].Value.ToString();
                    telefono.Text = tablaTotalClientes.Rows[fila].Cells[3].Value.ToString();
                    email.Text = tablaTotalClientes.Rows[fila].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.ToString());
            }
        }
        public void modificarCliente(TextBox idCliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            string consulta = "update cliente set nombres=@nombres, dni=@dni, telefono=@telefono, email=@email where idcliente=@idcliente;";

            try
            {
                objetoCliente.IdCliente = int.Parse(idCliente.Text);
                objetoCliente.Nombres = nombres.Text;
                objetoCliente.Dni = int.Parse(dni.Text);
                objetoCliente.Telefono = telefono.Text;
                objetoCliente.Email = email.Text;

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@idcliente", objetoCliente.IdCliente);
                comando.Parameters.AddWithValue("@nombres", objetoCliente.Nombres);
                comando.Parameters.AddWithValue("@dni", objetoCliente.Dni);
                comando.Parameters.AddWithValue("@telefono", objetoCliente.Telefono);
                comando.Parameters.AddWithValue("@email", objetoCliente.Email);

                comando.ExecuteNonQuery();

                MessageBox.Show("Cliente modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el cliente: " + ex.ToString());
            }
            finally // para cerrar la conexion porque hace ingreso de datos
            {
                objetoConexion.Desconectar();
            }
        }
        public void limpiarCampos(TextBox idCliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email)
        {
            idCliente.Text= "";
            nombres.Text= "";
            dni.Text= "";
            telefono.Text= "";
            email.Text= "";
        }
        public void eliminarCliente(TextBox idCliente)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            string consulta = "delete from cliente where idcliente = @idcliente;";

            try
            {
                objetoCliente.IdCliente = int.Parse(idCliente.Text);

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@idcliente", objetoCliente.IdCliente);

                comando.ExecuteNonQuery();

                MessageBox.Show("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.ToString());
            }
            finally // para cerrar la conexion porque hace ingreso de datos
            {
                objetoConexion.Desconectar();
            }
        }

    }
}
