using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas_y_stock___BD.CD
{
    internal class Conexion
    {
        private MySqlConnection conexion = null;

        private static string usuario = "root";
        private static string contrasena = "";
        private static string servidor = "localhost";
        private static string puerto = "3306";
        private static string baseDatos = "sistemadeventas";
        
        private string cadena = $"Server={servidor};Port={puerto};Database={baseDatos};Uid={usuario};Pwd={contrasena};";

        public MySqlConnection Conectar()
        {
            try
            {
                conexion = new MySqlConnection(cadena);
                conexion.Open();
                //MessageBox.Show("Conexión exitosa a la base de datos.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: ");
            }
            return conexion;
        }
        public void Desconectar()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    //MessageBox.Show("Desconexión exitosa de la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar de la base de datos: " + ex.ToString());
            }
        }
    }
}
