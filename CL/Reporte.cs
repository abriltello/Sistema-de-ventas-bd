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
