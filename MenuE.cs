using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class MenuE
    {
        List<MenuE> prod = new List<MenuE>();
        public string nombre { get; set; }
        public double precioUnit { get; set; }
        public MenuE()
        {

        }
        public MenuE(string linea)
        {
            string[] dat = linea.Split(',');
            nombre = dat[0];
            precioUnit = double.Parse(dat[1]);
        }
        public string Data
        {
            get
            {
                return nombre + ',' + precioUnit;
            }
        }
    }
}
