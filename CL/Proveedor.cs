using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas_y_stock___BD.CL
{
    internal class Proveedor
    {
            public void mostrarProveedor(DataGridView tablaTotalProveedor)
            {
                CD.Conexion objetoConexion = new CD.Conexion();
                CD.ModeloProveedor objetoProveedor = new CD.ModeloProveedor();

                DataTable modelo = new DataTable();

                modelo.Columns.Add("ID", typeof(int));
                modelo.Columns.Add("Nombre", typeof(string));
                modelo.Columns.Add("Direccion", typeof(string));
                modelo.Columns.Add("Telefono", typeof(string));
                modelo.Columns.Add("Email", typeof(string));

                tablaTotalProveedor.DataSource = modelo;

                string sql = "select idproveedor, nombre, direccion, telefono, email from proveedor;";

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
                        objetoProveedor.IdProveedor = Convert.ToInt32(row["idproveedor"]);
                        objetoProveedor.Nombre = row["nombre"].ToString();
                        objetoProveedor.Direccion = row["direccion"].ToString();
                        objetoProveedor.Telefono = row["telefono"].ToString();
                        objetoProveedor.Email = row["email"].ToString();

                        modelo.Rows.Add(objetoProveedor.IdProveedor, objetoProveedor.Nombre, objetoProveedor.Direccion, objetoProveedor.Telefono, objetoProveedor.Email);

                    }
                    tablaTotalProveedor.DataSource = modelo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar los proveedores: " + ex.ToString());
                }
                finally
                {
                    objetoConexion.Desconectar();
                }
            }

            public void agregarProveedor(TextBox nombre, TextBox direccion, TextBox telefono, TextBox email)
            {
                CD.Conexion objetoConexion = new CD.Conexion();
                CD.ModeloProveedor objetoProveedor = new CD.ModeloProveedor();

                string consulta = "insert into proveedor (nombre, direccion, telefono, email) values (@nombre, @direccion, @telefono, @email);";

                try
                {
                    objetoProveedor.Nombre = nombre.Text;
                    objetoProveedor.Direccion = direccion.Text;
                    objetoProveedor.Telefono = telefono.Text;
                    objetoProveedor.Email = email.Text;

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    comando.Parameters.AddWithValue("@nombre", objetoProveedor.Nombre);
                    comando.Parameters.AddWithValue("@direccion", objetoProveedor.Direccion);
                    comando.Parameters.AddWithValue("@telefono", objetoProveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", objetoProveedor.Email);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Proveedor agregado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el proveedor: " + ex.ToString());
                }
                finally // para cerrar la conexion
                {
                    objetoConexion.Desconectar();
                }

            }

            public void seleccionarProveedor(DataGridView tablaTotalProveedor, TextBox idProveedor, TextBox nombre, TextBox direccion, TextBox telefono, TextBox email)
            {
                int fila = tablaTotalProveedor.CurrentRow.Index;

                try
                {
                    if (fila >= 0)
                    {
                        idProveedor.Text = tablaTotalProveedor.Rows[fila].Cells[0].Value.ToString();
                        nombre.Text = tablaTotalProveedor.Rows[fila].Cells[1].Value.ToString();
                        direccion.Text = tablaTotalProveedor.Rows[fila].Cells[2].Value.ToString();
                        telefono.Text = tablaTotalProveedor.Rows[fila].Cells[3].Value.ToString();
                        email.Text = tablaTotalProveedor.Rows[fila].Cells[4].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el proveedor: " + ex.ToString());
                }
            }
            public void modificarProveedor(TextBox idProveedor, TextBox nombre, TextBox direccion, TextBox telefono, TextBox email)
            {
                CD.Conexion objetoConexion = new CD.Conexion();
                CD.ModeloProveedor objetoProveedor = new CD.ModeloProveedor();

                string consulta = "update proveedor set nombre=@nombre, direccion=@direccion, telefono=@telefono, email=@email where idproveedor=@idproveedor;";

                try
                {
                    objetoProveedor.IdProveedor = int.Parse(idProveedor.Text);
                    objetoProveedor.Nombre = nombre.Text;
                    objetoProveedor.Direccion = direccion.Text;
                    objetoProveedor.Telefono = telefono.Text;
                    objetoProveedor.Email = email.Text;

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    comando.Parameters.AddWithValue("@idproveedor", objetoProveedor.IdProveedor);
                    comando.Parameters.AddWithValue("@nombre", objetoProveedor.Nombre);
                    comando.Parameters.AddWithValue("@direccion", objetoProveedor.Direccion);
                    comando.Parameters.AddWithValue("@telefono", objetoProveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", objetoProveedor.Email);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Proveedor modificado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el proveedor: " + ex.ToString());
                }
                finally // para cerrar la conexion porque hace ingreso de datos
                {
                    objetoConexion.Desconectar();
                }
            }
            public void limpiarCampos(TextBox idProveedor, TextBox nombre, TextBox direccion, TextBox telefono, TextBox email)
            {
                idProveedor.Text = "";
                nombre.Text = "";
                direccion.Text = "";
                telefono.Text = "";
                email.Text = "";
            }
            public void eliminarProveedor(TextBox idProveedor)
            {
                CD.Conexion objetoConexion = new CD.Conexion();
                CD.ModeloProveedor objetoProveedor = new CD.ModeloProveedor();

                string consulta = "delete from proveedor where idproveedor = @idproveedor;";

                try
                {
                    objetoProveedor.IdProveedor = int.Parse(idProveedor.Text);

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);

                    comando.Parameters.AddWithValue("@idproveedor", objetoProveedor.IdProveedor);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Proveedor eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el proveedor: " + ex.ToString());
                }
                finally // para cerrar la conexion porque hace ingreso de datos
                {
                    objetoConexion.Desconectar();
                }
            }

    }
}

