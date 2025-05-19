using MySql.Data.MySqlClient;
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
    internal class Venta
    {
        // CLIENTES
        public void buscarCliente(TextBox nombres, DataGridView tablaTotalClientes)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("IDCliente", typeof(int));
            modelo.Columns.Add("Nombre y Apellido", typeof(string));
            modelo.Columns.Add("DNI", typeof(int));
            modelo.Columns.Add("Telefono", typeof(string));
            modelo.Columns.Add("Email", typeof(string));


            tablaTotalClientes.DataSource = modelo;

            try
            {
                if (nombres.Text == "")
                {
                    tablaTotalClientes.DataSource = null;
                }
                else
                {
                    string sql = "select * from cliente where cliente.nombres like concat('%', @nombres, '%');";

                    MySqlConnection conexion = objetoConexion.Conectar();

                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombres", nombres.Text);

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

        public void seleccionarClienteVenta(DataGridView tablaTotalClientes, TextBox idcliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email)
        {
            int fila = tablaTotalClientes.CurrentRow.Index;

            try
            {
                if (fila >= 0)
                {
                    idcliente.Text = tablaTotalClientes.Rows[fila].Cells[0].Value.ToString();
                    nombres.Text = tablaTotalClientes.Rows[fila].Cells[1].Value.ToString();
                    dni.Text = tablaTotalClientes.Rows[fila].Cells[2].Value.ToString();
                    telefono.Text = tablaTotalClientes.Rows[fila].Cells[3].Value.ToString();
                    email.Text = tablaTotalClientes.Rows[fila].Cells[2].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.ToString());
            }
        }


        // PRODUCTOS
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

        public void seleccionarProductoVenta(DataGridView tablaTotalProductos, TextBox id, TextBox nombre, TextBox precioProducto, TextBox stock, TextBox precioFinal)
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
        public void pasarProductosVenta(DataGridView tablaTotalCarrito, TextBox idproducto, TextBox nombre, TextBox precioProducto, TextBox cantidad, TextBox stock)
        {
            //TODAVIA NO SE GUARDA EN LA BASE DE DATOS, SOLO SE GUARDAN EN UN ARRAY, CUANDO SE APRETE PAGAR SE GUARDA EN LA BD
            try
            {
                DataTable modelo = (DataTable)tablaTotalCarrito.DataSource;

                if (modelo == null)
                {
                    modelo = new DataTable();
                    modelo.Columns.Add("ID", typeof(string));
                    modelo.Columns.Add("Nombre Producto", typeof(string));
                    modelo.Columns.Add("Precio Unitario", typeof(double));
                    modelo.Columns.Add("Cantidad", typeof(int));
                    modelo.Columns.Add("Subtotal", typeof(double));

                    tablaTotalCarrito.DataSource = modelo;
                }

                int stockDisponible = Convert.ToInt32(stock.Text);

                string idProductoTexto = idproducto.Text;

                foreach (DataRow row in modelo.Rows) //para ver si se repite el producto y no lo repita
                {
                    string idProductoExistente = (string)row["ID"];
                    if (idProductoExistente == idProductoTexto)
                    {
                        MessageBox.Show("El producto ya se encuentra en el carrito.");
                        return;
                    }
                }

                string nProducto = nombre.Text;
                double precio = Convert.ToDouble(precioProducto.Text);
                int cantidadProducto = Convert.ToInt32(cantidad.Text);

                if (cantidadProducto > stockDisponible) //para no superar el stock
                {
                    MessageBox.Show("No hay suficiente stock.");
                    return;
                }

                double subtotal = precio * cantidadProducto;

                modelo.Rows.Add(idproducto.Text, nProducto, precio, cantidadProducto, subtotal);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los productos registrados: " + ex.ToString());
            }
            //NO HAY FINALLY PORQUE NO ESTOY TRABAJANDO NINGUNA CONEXION A UNA BASE DE DATOS
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

        //FACTURA
        public void crearFactura(TextBox codigoCliente)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloCliente objetoCliente = new CD.ModeloCliente();

            string consulta = "insert into factura (fechaFactura, fkCliente) values (curdate(),@fkCliente);";

            try
            {
                objetoCliente.IdCliente = int.Parse(codigoCliente.Text);
                

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@fkCliente", objetoCliente.IdCliente);
               

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

        public void mostrarUltimaFactura(Label ultimaFactura)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            string sql = "select max(idFactura)as UltimaFactura from factura;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    ultimaFactura.Text = reader["UltimaFactura"].ToString();
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

        //VENTA
        public void realizarVenta(DataGridView tablaCarritoVenta)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
           
            string consultaDetalle = "insert into detalle (fkFactura, fkProducto, cantidad, precioVenta) values ((select max(idFactura) from factura),@fkProducto,@cantidad,@precioVenta);";
            string consultaStock = "update producto set stock = stock - @cantidad where idproducto = @idproducto;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comandoDetalle = new MySqlCommand(consultaDetalle, conexion);
                MySqlCommand comandoStock = new MySqlCommand(consultaStock, conexion);
               
                foreach (DataGridViewRow row in tablaCarritoVenta.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int idProducto = Convert.ToInt32(row.Cells[0].Value);
                        int cantidad = Convert.ToInt32(row.Cells[3].Value);
                        double precioVenta = Convert.ToDouble(row.Cells[2].Value);

                        comandoDetalle.Parameters.Clear();
                        comandoDetalle.Parameters.AddWithValue("@fkProducto", idProducto);
                        comandoDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoDetalle.Parameters.AddWithValue("@precioVenta", precioVenta);

                        comandoDetalle.ExecuteNonQuery();

                        comandoStock.Parameters.Clear();
                        comandoStock.Parameters.AddWithValue("@cantidad", cantidad);
                        comandoStock.Parameters.AddWithValue("@idProducto", idProducto);

                        comandoStock.ExecuteNonQuery();

                    }
                }

                MessageBox.Show("Venta realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la venta: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }

        }
        
        public void limpiarCamposAlPagar(TextBox buscarCliente, DataGridView tablaCliente, TextBox buscarProducto, DataGridView tablaProducto, DataGridView tablaCarrito, TextBox idCliente, TextBox nombres, TextBox dni, TextBox telefono, TextBox email, TextBox idProducto, TextBox nombreProducto, TextBox precioProducto, TextBox stockProducto, TextBox cantidadProducto, Label totalPagar, TextBox precioVenta)
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
            precioVenta.Clear();
        }

        

    }
}
