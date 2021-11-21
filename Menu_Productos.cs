using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Menu_Productos
    {
        List<Menu_Productos> productos = new List<Menu_Productos>();
        public string nombre { get; set; }
        public double precio { get; set; }
        public Menu_Productos()
        {

        }
        public Menu_Productos(string linea)
        {
            string[] datos = linea.Split(',');
            nombre = datos[0];
            precio = double.Parse(datos[1]);
        }
        public string Data
        {
            get
            {
                return nombre + ',' + precio;
            }
        }
    }
}
