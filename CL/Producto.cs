using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sistema_de_ventas_y_stock___BD.CL
{
    internal class Producto
    {
        public void mostrarProductos(DataGridView tablaTotalProductos)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProducto objetoProducto = new CD.ModeloProducto();

            DataTable modelo = new DataTable();

            modelo.Columns.Add("ID", typeof(int));
            modelo.Columns.Add("Nombre Producto", typeof(string));
            modelo.Columns.Add("Precio", typeof(double));
            modelo.Columns.Add("Stock", typeof(int));


            tablaTotalProductos.DataSource = modelo;

            string sql = "select idproducto, nombre, precioProducto, stock from producto;";

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
                    objetoProducto.IdProducto = Convert.ToInt32(row["idproducto"]);
                    objetoProducto.Nombre = row["nombre"].ToString();
                    objetoProducto.PrecioProducto = Convert.ToDouble(row["precioProducto"]);
                    objetoProducto.Stock = Convert.ToInt32(row["stock"]);


                    modelo.Rows.Add(objetoProducto.IdProducto, objetoProducto.Nombre, objetoProducto.PrecioProducto, objetoProducto.Stock);

                }
                tablaTotalProductos.DataSource = modelo;
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
        public void agregarProducto(TextBox nombre, TextBox precio, TextBox stock)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProducto objetoProducto = new CD.ModeloProducto();

            string consulta = "insert into producto (nombre, precioProducto, stock) values (@nombre, @precioProducto, @stock);";

            try
            {
                objetoProducto.Nombre = nombre.Text;
                objetoProducto.PrecioProducto = Convert.ToDouble(precio.Text);
                objetoProducto.Stock = Convert.ToInt32(stock.Text);

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombre", objetoProducto.Nombre);
                comando.Parameters.AddWithValue("@precioProducto", objetoProducto.PrecioProducto);
                comando.Parameters.AddWithValue("@stock", objetoProducto.Stock);

                comando.ExecuteNonQuery();

                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }
        }
        public void seleccionarProducto(DataGridView tablaTotalProductos, TextBox id, TextBox nombre, TextBox precioProducto, TextBox stock)
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
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.ToString());
            }
        }
        public void modificarProducto(TextBox id, TextBox nombre, TextBox precioProducto, TextBox stock)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProducto objetoProducto = new CD.ModeloProducto();

            string consulta = "update producto set nombre=@nombre, precioProducto=@precioProducto, stock=@stock where idproducto=@id;";

            try
            {
                objetoProducto.IdProducto = Convert.ToInt32(id.Text);
                objetoProducto.Nombre = nombre.Text;
                objetoProducto.PrecioProducto = Convert.ToDouble(precioProducto.Text);
                objetoProducto.Stock = Convert.ToInt32(stock.Text);

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@id", objetoProducto.IdProducto);
                comando.Parameters.AddWithValue("@nombre", objetoProducto.Nombre);
                comando.Parameters.AddWithValue("@precioProducto", objetoProducto.PrecioProducto);
                comando.Parameters.AddWithValue("@stock", objetoProducto.Stock);

                comando.ExecuteNonQuery();

                MessageBox.Show("El producto se ha modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }
        }
        public void limpiarCampos(TextBox id, TextBox nombre, TextBox precioProducto, TextBox stock)
        {
            id.Text="";
            nombre.Text ="";
            precioProducto.Text = ""    ;
            stock.Text = "";
        }
        public void eliminarProducto(TextBox id)
        {
            CD.Conexion objetoConexion = new CD.Conexion();
            CD.ModeloProducto objetoProducto = new CD.ModeloProducto();

            string consulta = "delete from producto where idproducto=@id;";

            try
            {
                objetoProducto.IdProducto = Convert.ToInt32(id.Text);

                MySqlConnection conexion = objetoConexion.Conectar();

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@id", objetoProducto.IdProducto);

                comando.ExecuteNonQuery();

                MessageBox.Show("El producto se ha eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.ToString());
            }
            finally // para cerrar la conexion
            {
                objetoConexion.Desconectar();
            }
        }
    }
}
