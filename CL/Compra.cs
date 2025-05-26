using MySql.Data.MySqlClient;
using Sistema_de_ventas_y_stock___BD.CD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas_y_stock___BD.CL
{
    internal class Compra
    {
        public void mostrarUltimaFacturaCompra(Label ultimaFactura)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            string sql = "select max(idFacturaCompra)as UltimaFacturaCompra from facturacompra;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    ultimaFactura.Text = reader["UltimaFacturaCompra"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar última factura: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void buscarProveedor(TextBox nombre, DataGridView tablaTotalProveedor)
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

            try
            {
                if (nombre.Text == "")
                {
                    tablaTotalProveedor.DataSource = null;
                }
                else
                {
                    string sql = "select * from proveedor where proveedor.nombre like concat('%', @nombre, '%');";

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre.Text);

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

        public void seleccionarProveedorCompra(DataGridView tablaTotalProveedor, TextBox idproveedor, TextBox nombre, TextBox direccion, TextBox telefono, TextBox email)
        {
            int fila = tablaTotalProveedor.CurrentRow.Index;

            try
            {
                if (fila >= 0)
                {
                    idproveedor.Text = tablaTotalProveedor.Rows[fila].Cells[0].Value.ToString();
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

        public void buscarProducto(TextBox nombre, DataGridView tablaTotalProductos)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProducto objetoProducto = new CD.ModeloProducto();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("ID", typeof(int));
            modelo.Columns.Add("Nombre Producto", typeof(string));
            modelo.Columns.Add("Precio", typeof(double));
            modelo.Columns.Add("Stock", typeof(int));

            tablaTotalProductos.DataSource = modelo;

            try
            {
                if (nombre.Text == "")
                {
                    tablaTotalProductos.DataSource = null;
                }
                else
                {
                    string sql = "select * from producto where producto.nombre like concat('%', @nombre, '%');";

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre.Text);

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);

                    DataSet ds = new DataSet();

                    adaptador.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        objetoProducto.IdProducto = Convert.ToInt32(row["idproducto"]);
                        objetoProducto.Nombre = row["nombre"].ToString();
                        objetoProducto.PrecioProducto = Convert.ToDouble(row["precioProducto"]);
                        objetoProducto.Stock = Convert.ToInt32(row["stock"]);


                        modelo.Rows.Add(objetoProducto.IdProducto, objetoProducto.Nombre, objetoProducto.PrecioProducto, objetoProducto.Stock);

                    }
                    tablaTotalProductos.DataSource = modelo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los productos: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void seleccionarProductoCompra(DataGridView tablaTotalProductos, TextBox id, TextBox nombre, TextBox precioProducto, TextBox stock, TextBox precioFinal)
        {
            int fila = tablaTotalProductos.CurrentRow.Index;

            try
            {
                if (fila >= 0)
                {
                    id.Text = tablaTotalProductos.Rows[fila].Cells[0].Value.ToString();
                    nombre.Text = tablaTotalProductos.Rows[fila].Cells[1].Value.ToString();
                    precioProducto.Text = tablaTotalProductos.Rows[fila].Cells[2].Value.ToString();
                    stock.Text = tablaTotalProductos.Rows[fila].Cells[3].Value.ToString();
                    precioFinal.Text = tablaTotalProductos.Rows[fila].Cells[2].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.ToString());
            }
        }
        public void pasarProductosCompra(DataGridView tablaTotalCompra, TextBox idproducto, TextBox nombre, TextBox precioCompra, TextBox cantidad, TextBox stock)
        {
            try
            {
                DataTable modelo = (DataTable)tablaTotalCompra.DataSource;

                if (modelo == null)
                {
                    modelo = new DataTable();
                    modelo.Columns.Add("ID", typeof(string));
                    modelo.Columns.Add("Nombre Producto", typeof(string));
                    modelo.Columns.Add("Precio Unitario", typeof(double));
                    modelo.Columns.Add("Cantidad", typeof(int));
                    modelo.Columns.Add("Subtotal", typeof(double));

                    tablaTotalCompra.DataSource = modelo;
                }

                string idProductoTexto = idproducto.Text;

                foreach (DataRow row in modelo.Rows)
                {
                    string idProductoExistente = (string)row["ID"];
                    if (idProductoExistente == idProductoTexto)
                    {
                        MessageBox.Show("El producto ya se encuentra en la lista de compra.");
                        return;
                    }
                }

                string nProducto = nombre.Text;
                double precio = Convert.ToDouble(precioCompra.Text);
                int cantidadProducto = Convert.ToInt32(cantidad.Text);

                if (cantidadProducto <= 0)
                {
                    MessageBox.Show("Debe ingresar una cantidad válida.");
                    return;
                }

                double subtotal = precio * cantidadProducto;

                modelo.Rows.Add(idproducto.Text, nProducto, precio, cantidadProducto, subtotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar productos a la compra: " + ex.ToString());
            }

        }

        public void calcularTotalPagar(DataGridView tablaCarrito, Label totalPagar)
        {
            double total = 0;

            NumberFormatInfo formato = new NumberFormatInfo();
            formato.NumberDecimalDigits = 2;

            foreach (DataGridViewRow row in tablaCarrito.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToDouble(row.Cells[4].Value);
                }
            }

            totalPagar.Text = total.ToString("N", formato);
        }

        public void eliminarProductoSeleccionado(DataGridView tablaCarrito)
        {
            try
            {
                int indiceSelect = tablaCarrito.CurrentRow.Index;

                if (indiceSelect >= 0)
                {
                    tablaCarrito.Rows.RemoveAt(indiceSelect);
                }
                else
                {
                    MessageBox.Show("Seleccione un producto para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.ToString());
            }
        }

        public void crearFacturaCompra(TextBox codigoProveedor)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProveedor objetoProveedor = new CD.ModeloProveedor();

            string consulta = "insert into facturacompra (fechaFacturaCompra, fkProveedor) values (curdate(),@fkProveedor);";

            try
            {
                objetoProveedor.IdProveedor = int.Parse(codigoProveedor.Text);


                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@fkProveedor", objetoProveedor.IdProveedor);


                comando.ExecuteNonQuery();

                MessageBox.Show("Factura creada");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la factura: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }

        }

        public void realizarCompra(DataGridView tablaCarritoCompra)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            string consultaCrearFactura = "INSERT INTO facturacompra (fechaFacturaCompra) VALUES (NOW());";
            string consultaUltimoId = "SELECT LAST_INSERT_ID();";
            string consultaDetalleCompra = "INSERT INTO detallecompra (fkFacturaCompra, fkProducto, cantidad, precioCompra) VALUES (@fkFacturaCompra, @fkProducto, @cantidad, @precioCompra);";
            string consultaActualizarStock = "UPDATE producto SET stock = stock + @cantidad WHERE idproducto = @idproducto;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                // Crear la factura
                MySqlCommand comandoFactura = new MySqlCommand(consultaCrearFactura, conexion);
                comandoFactura.ExecuteNonQuery();

                // Obtener el ID generado
                MySqlCommand comandoUltimoId = new MySqlCommand(consultaUltimoId, conexion);
                int idFacturaCompra = Convert.ToInt32(comandoUltimoId.ExecuteScalar());

                // Preparar comandos
                MySqlCommand comandoDetalleCompra = new MySqlCommand(consultaDetalleCompra, conexion);
                MySqlCommand comandoStock = new MySqlCommand(consultaActualizarStock, conexion);

                foreach (DataGridViewRow row in tablaCarritoCompra.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int idProducto = Convert.ToInt32(row.Cells[0].Value);
                        int cantidad = Convert.ToInt32(row.Cells[3].Value);
                        double precioCompra = Convert.ToDouble(row.Cells[2].Value);

                        comandoDetalleCompra.Parameters.Clear();
                        comandoDetalleCompra.Parameters.AddWithValue("@fkFacturaCompra", idFacturaCompra);
                        comandoDetalleCompra.Parameters.AddWithValue("@fkProducto", idProducto);
                        comandoDetalleCompra.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoDetalleCompra.Parameters.AddWithValue("@precioCompra", precioCompra);
                        comandoDetalleCompra.ExecuteNonQuery();

                        comandoStock.Parameters.Clear();
                        comandoStock.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoStock.Parameters.AddWithValue("@idproducto", idProducto);
                        comandoStock.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Compra registrada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la compra: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }


        public void limpiarCamposAlPagar(TextBox buscarCliente, DataGridView tablaCliente, TextBox buscarProducto, DataGridView tablaProducto, DataGridView tablaCarrito, TextBox idCliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email, TextBox idProducto, TextBox nombreProducto, TextBox precioProducto, TextBox stockProducto, TextBox cantidadProducto, Label totalPagar)
        {
            buscarCliente.Clear();
            tablaCliente.DataSource = null;
            idCliente.Clear();
            nombres.Clear();
            dni.Clear();
            telefono.Clear();
            email.Clear();

            buscarProducto.Clear();
            tablaProducto.DataSource = null;
            idProducto.Clear();
            nombreProducto.Clear();
            precioProducto.Clear();
            stockProducto.Clear();
            cantidadProducto.Clear();

            tablaCarrito.DataSource = null;
            totalPagar.Text = "0.00";
            
        }

    }
}
