using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class ListaProducto
    {
        List<Compra> productos = new List<Compra>();
        public void agregarProducto(Compra productoNuevo)
        {
            productos.Add(productoNuevo);
        }
        /// /no sirve
        public void eliminarProducto(int posicion)
        {
            productos.RemoveAt(posicion);
        }

        public List<Compra> getLista()
        {
            return productos;
        }

        public int cantidadProductos()
        {
            return productos.Count;
        }
    }
}
