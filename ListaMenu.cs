using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1
{
    class ListaMenu
    {
        List<Menu_Productos> productos = new List<Menu_Productos>();
        public void agregarProducto(Menu_Productos productoNuevo)
        {
            productos.Add(productoNuevo);
        }
        public void eliminarProducto(int posicion)
        {
            productos.RemoveAt(posicion);
        }
        public List<Menu_Productos> getLista()
        {
            return productos;
        }

        public int cantidadProductos()
        {
            return productos.Count;
        }
        public void guardarEnArchivo()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Menú.txt", true);
                foreach (Menu_Productos aux in productos)
                {
                    sw.WriteLine(aux.Data);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Expecion: " + e.Message);
            }
        }
    }
}
