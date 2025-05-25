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
    internal class Reporte
    {
        public void cargarClientes(ComboBox comboClientes)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                string sql = "SELECT idCliente, nombres FROM cliente ORDER BY nombres ASC;";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                comboClientes.DataSource = tabla;
                comboClientes.DisplayMember = "nombres";    // lo que se muestra
                comboClientes.ValueMember = "idCliente";    // lo que se usa internamente

                comboClientes.SelectedIndex = -1; // Opcional: para que no se seleccione ninguno al inicio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void buscarFacturaPorCliente(ComboBox comboClientes, Label lblFactura, Label lblFecha, Label lblNombre, Label lblDni, Label lblTelefono, Label lblEmail, DataGridView dgvProductos, Label lblTotal)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            try
            {
                int idCliente = Convert.ToInt32(comboClientes.SelectedValue);

                MySqlConnection conexion = objetoConexion.Conectar();

                // 1. Obtener la factura más reciente del cliente
                string sqlFactura = "SELECT idFactura, fechaFactura FROM factura WHERE fkCliente = @idcliente ORDER BY fechaFactura DESC LIMIT 1;";
                MySqlCommand cmdFactura = new MySqlCommand(sqlFactura, conexion);
                cmdFactura.Parameters.AddWithValue("@idcliente", idCliente);
                MySqlDataReader readerFactura = cmdFactura.ExecuteReader();

                if (readerFactura.Read())
                {
                    string idFactura = readerFactura["idFactura"].ToString();
                    string fecha = Convert.ToDateTime(readerFactura["fechaFactura"]).ToString("dd/MM/yyyy");
                    lblFactura.Text = idFactura;
                    lblFecha.Text = fecha;
                    readerFactura.Close();

                    // 2. Obtener datos del cliente
                    string sqlCliente = "SELECT nombres, dni, telefono, email FROM cliente WHERE idcliente = @idcliente;";
                    MySqlCommand cmdCliente = new MySqlCommand(sqlCliente, conexion);
                    cmdCliente.Parameters.AddWithValue("@idcliente", idCliente);
                    MySqlDataReader readerCliente = cmdCliente.ExecuteReader();

                    if (readerCliente.Read())
                    {
                        lblNombre.Text = readerCliente["nombres"].ToString();
                        lblDni.Text = readerCliente["dni"].ToString();
                        lblTelefono.Text = readerCliente["telefono"].ToString();
                        lblEmail.Text = readerCliente["email"].ToString();
                    }
                    readerCliente.Close();

                }
                else
                {
                    MessageBox.Show("No se encontró ninguna factura para este cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar factura: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void buscarFacturaYDatosCliente(TextBox numeroFactura, Label numeroFacturaEncontrado, Label fechaFacturaEncontrado,
                                               Label nombreClienteEncontrado, Label dniClienteEncontrado, Label telefonoClienteEncontrado, Label emailClienteEncontrado)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            string sql = "select factura.idFactura, factura.fechaFactura, cliente.nombres, cliente.dni, cliente.telefono, cliente.email from factura " + " INNER JOIN cliente ON cliente.idcliente = factura.fkCliente WHERE factura.idFactura = @idFactura;";

            try
            {
                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@idFactura", int.Parse(numeroFactura.Text));

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    numeroFacturaEncontrado.Text = reader["idFactura"].ToString();
                    fechaFacturaEncontrado.Text = DateTime.Parse(reader["fechaFactura"].ToString()).ToString("dd-MM-yyyy");
                    nombreClienteEncontrado.Text = reader["nombres"].ToString();
                    dniClienteEncontrado.Text = reader["dni"].ToString();
                    telefonoClienteEncontrado.Text = reader["telefono"].ToString();
                    emailClienteEncontrado.Text = reader["email"].ToString();

                }
                else
                {
                    numeroFacturaEncontrado.Text = "----";
                    fechaFacturaEncontrado.Text = "----";
                    nombreClienteEncontrado.Text = "----";
                    dniClienteEncontrado.Text = "----";
                    telefonoClienteEncontrado.Text = "----";
                    emailClienteEncontrado.Text = "----";

                    MessageBox.Show("No se encontró la factura con el número: ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar factura: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }



        public void buscarFacturaYDatosPorCliente(ComboBox comboClientes, Label labelFactura, Label fechaVenta,
    Label nombre, Label dni, Label telefono, Label email,
    DataGridView tablaTotalProductos, Label total)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            DataTable modelo = new DataTable();

            modelo.Columns.Add("Nombre del Producto", typeof(string));
            modelo.Columns.Add("Cantidad", typeof(int));
            modelo.Columns.Add("Precio de venta", typeof(double));
            modelo.Columns.Add("Subtotal", typeof(double));

            tablaTotalProductos.DataSource = modelo;

            NumberFormatInfo formatos = new NumberFormatInfo();
            formatos.NumberDecimalDigits = 2;

            try
            {
                int idCliente = Convert.ToInt32(comboClientes.SelectedValue);

                string sqlFactura = "SELECT * FROM factura WHERE fkCliente = @fkCliente ORDER BY fechaFactura DESC LIMIT 1;";
                MySqlConnection conexion = objetoConexion.Conectar();
                MySqlCommand comandoFactura = new MySqlCommand(sqlFactura, conexion);
                comandoFactura.Parameters.AddWithValue("@fkCliente", idCliente);
                MySqlDataReader readerFactura = comandoFactura.ExecuteReader();

                int idFactura = -1;
                string fecha = "";

                if (readerFactura.Read())
                {
                    idFactura = Convert.ToInt32(readerFactura["idFactura"]);
                    fecha = readerFactura["fechaFactura"].ToString();

                    labelFactura.Text = idFactura.ToString();
                    fechaVenta.Text = fecha;
                }
                else
                {
                    MessageBox.Show("Este cliente no tiene facturas registradas.");
                    return;
                }

                readerFactura.Close();

                // Datos del cliente
                string sqlCliente = "SELECT * FROM cliente WHERE idcliente = @idcliente;";
                MySqlCommand comandoCliente = new MySqlCommand(sqlCliente, conexion);
                comandoCliente.Parameters.AddWithValue("@idcliente", idCliente);
                MySqlDataReader readerCliente = comandoCliente.ExecuteReader();

                if (readerCliente.Read())
                {
                    nombre.Text = readerCliente["nombres"].ToString();
                    dni.Text = readerCliente["dni"].ToString();
                    telefono.Text = readerCliente["telefono"].ToString();
                    email.Text = readerCliente["email"].ToString();
                }

                readerCliente.Close();

                // Productos de la factura
                string sqlDetalle = @"SELECT producto.nombre, detalle.cantidad, detalle.precioVenta
                              FROM detalle 
                              INNER JOIN producto ON producto.idproducto = detalle.fkProducto 
                              WHERE detalle.fkFactura = @idFactura;";

                MySqlCommand comandoDetalle = new MySqlCommand(sqlDetalle, conexion);
                comandoDetalle.Parameters.AddWithValue("@idFactura", idFactura);
                MySqlDataReader readerDetalle = comandoDetalle.ExecuteReader();

                double totalFactura = 0.0;

                while (readerDetalle.Read())
                {
                    string nombreProducto = readerDetalle["nombre"].ToString();
                    int cantidad = Convert.ToInt32(readerDetalle["cantidad"]);
                    double precioVenta = Convert.ToDouble(readerDetalle["precioVenta"]);
                    double subtotal = cantidad * precioVenta;

                    totalFactura += subtotal;
                    modelo.Rows.Add(nombreProducto, cantidad, precioVenta, subtotal);
                }

                total.Text = totalFactura.ToString("N", formatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la factura: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }








        public void buscarFacturaYDatosProductos(TextBox numeroFactura, DataGridView tablaTotalProductos, Label total)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
           

            DataTable modelo = new DataTable();

            modelo.Columns.Add("Nombre del Producto", typeof(string));
            modelo.Columns.Add("Cantidad", typeof(int));
            modelo.Columns.Add("Precio de venta", typeof(double));
            modelo.Columns.Add("Subtotal", typeof(double));


            tablaTotalProductos.DataSource = modelo;

            NumberFormatInfo formatos = new NumberFormatInfo();
            formatos.NumberDecimalDigits = 2;

            try
            {
                string sql = "select  producto.nombre, detalle.cantidad, detalle.precioVenta from detalle " + "INNER JOIN factura ON factura.idFactura = detalle.fkFactura " + "INNER JOIN producto ON producto.idproducto = detalle.fkProducto " + "WHERE factura.idFactura = @idFactura;";

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@idFactura", int.Parse(numeroFactura.Text));

                MySqlDataReader reader = comando.ExecuteReader();

                double totalFactura = 0.0;

                while (reader.Read())
                {
                    string nombreProducto = reader["nombre"].ToString();
                    int cantidad = reader.GetInt32("cantidad");
                    double precioVenta = reader.GetDouble("precioVenta");
                    double subtotal = cantidad * precioVenta;

                    totalFactura += subtotal;

                    modelo.Rows.Add(nombreProducto, cantidad, precioVenta, subtotal);
                }

                total.Text = totalFactura.ToString("N", formatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }
        }

        public void mostrarTotalVentaPorFecha(DateTimePicker desde, DateTimePicker hasta, DataGridView tablaVentas, Label ingresosTotales)
        {
            CD.Conexion objetoConexion = new CD.Conexion();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("ID Factura", typeof(int));
            modelo.Columns.Add("Fecha de Factura", typeof(DateTime));
            modelo.Columns.Add("Nombre del producto", typeof(string));
            modelo.Columns.Add("Cantidad", typeof(int));
            modelo.Columns.Add("Precio de venta", typeof(double));
            modelo.Columns.Add("Subtotal", typeof(double));

            tablaVentas.DataSource = modelo;

            NumberFormatInfo formatos = new NumberFormatInfo();
            formatos.NumberDecimalDigits = 2;

            try
            {
                string sql = "select factura.idFactura, factura.fechaFactura, producto.nombre, detalle.cantidad, detalle.precioVenta from detalle " +
                    "INNER JOIN factura ON factura.idFactura = detalle.fkFactura " +
                    "INNER JOIN producto ON producto.idproducto = detalle.fkProducto " +
                    "WHERE factura.fechaFactura BETWEEN @fechaDesde AND @fechaHasta;";

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@fechaDesde", desde.Value);
                comando.Parameters.AddWithValue("@fechaHasta", hasta.Value);

                MySqlDataReader reader = comando.ExecuteReader();

                double totalVentas = 0.0;

                while (reader.Read())
                {
                    int idFactura = reader.GetInt32("idFactura");
                    DateTime fechaFactura = reader.GetDateTime("fechaFactura");
                    string nombreProducto = reader.GetString("nombre");
                    int cantidad = reader.GetInt32("cantidad");
                    double precioVenta = reader.GetDouble("precioVenta");
                    double subtotal = cantidad * precioVenta;

                    totalVentas += subtotal;

                    modelo.Rows.Add(idFactura, fechaFactura, nombreProducto, cantidad, precioVenta, subtotal);
                }

                ingresosTotales.Text = totalVentas.ToString("N", formatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.ToString());
            }
            finally
            {
                objetoConexion.Desconectar();
            }

        }
    }
}
