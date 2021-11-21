using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Compra
    {
        private static char DIVISOR_TEXTO = '-';
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }        
        public Compra (){ }
        public Compra(string linea)
        {
            string[] datos = linea.Split(DIVISOR_TEXTO);            
            nombre = datos[0];            
            precio = double.Parse(datos[1]);
            cantidad =int.Parse(datos[2]);
            subtotal = double.Parse(datos[3]); 
        }
        public string DataParaArchivo
        {
            get
            {
                return nombre + DIVISOR_TEXTO
                    + precio + DIVISOR_TEXTO
                    + cantidad + DIVISOR_TEXTO
                    + subtotal + DIVISOR_TEXTO;
            }
        }
    }
}
