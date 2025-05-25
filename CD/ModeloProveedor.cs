using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas_y_stock___BD.CD
{
    internal class ModeloProveedor
    {
        int idProveedor;
        string nombre;
        string direccion;
        string telefono;
        string email;

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}

