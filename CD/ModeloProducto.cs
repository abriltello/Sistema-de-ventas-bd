using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas_y_stock___BD.CD
{
    internal class ModeloProducto
    {
        int idProducto;
        string nombre;
        double precioProducto;
        int stock;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double PrecioProducto { get => precioProducto; set => precioProducto = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
