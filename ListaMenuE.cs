using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _1
{
    class ListaMenuE
    {
        List<MenuE> prod = new List<MenuE>();
        public void agregarProducto(MenuE productoNuevo)
        {
            prod.Add(productoNuevo);
        }

        public List<MenuE> getLista()
        {
            return prod;
        }
        public int cantidadProductos()
        {
            return prod.Count;
        }
        public string guardarEnArchivo()
        {
            string error = "";
            try
            {
                StreamWriter sw = new StreamWriter("Menú.txt");
                foreach (MenuE aux in prod)
                {
                    sw.WriteLine(aux.Data);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }
        public string cargarDesdeArchivo()
        {
            string error = "";
            try
            {
                prod = new List<MenuE>();
                StreamReader sr = new StreamReader("Menú.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    prod.Add(new MenuE(linea));
                    //Leer linea
                }
                sr.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }
 
    }
}
