using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1
{
    public partial class Form4 : Form
    {
        ListaMenuE listado = new ListaMenuE();
        List<MenuE> productos = new List<MenuE>();
        aviso P;
        public Form4()
        {
            InitializeComponent();
            P = new aviso();
        }
        public bool va()
        {
            double x, num;
            if (txtnombre.Text == "" || double.TryParse(txtnombre.Text, out x))
            {
                error.SetError(txtnombre, "El nombre que ingresaste no es válido");
                return false;
            }
            error.SetError(txtnombre, "");
            if (txtprecio.Text == "" || !(double.TryParse(txtprecio.Text, out num)))
            {
                error.SetError(txtprecio, "El precio que ingresaste no es válido");
                return false;
            }
            error.SetError(txtprecio, "");
            
            return true;
        }
        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
           if (va() == true)
            {
                MenuE nuevoProducto = new MenuE();
                nuevoProducto.nombre = txtnombre.Text;
                nuevoProducto.precioUnit = double.Parse(txtprecio.Text);
               //ORDEN
                listado.agregarProducto(nuevoProducto);             
                string error = listado.guardarEnArchivo();
                if (error != "")
                    MessageBox.Show(error);
               actualizarGrilla();
            }
           txtnombre.Text = "";
           txtprecio.Text = "";
        }
        public void actualizarGrilla()
        {
            List<MenuE> productos1 = listado.getLista();
            productos = productos1;
            dgv1.Rows.Clear();
            foreach (MenuE p in productos)
            {
                int indiceNuevaFila = dgv1.Rows.Add();
                DataGridViewRow filaNueva = dgv1.Rows[indiceNuevaFila];
                filaNueva.Cells[0].Value = p.nombre;
                filaNueva.Cells[1].Value = p.precioUnit;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            P.Show();
        }

        private void pbxRegresar_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < productos.Count; i++)
            {
                for (int j = 0; j < productos.Count - 1; j++)
                {
                    int comparar = -1;
                    if (rdPRODUCTO.Checked)
                    {
                        comparar = productos[j].nombre.CompareTo(productos[j + 1].nombre);
                    }
                    if (rdPrecio.Checked)
                    {
                        comparar = productos[j].precioUnit.CompareTo(productos[j + 1].precioUnit);
                    }

                    if (comparar > 0)
                    {
                        MenuE aux = productos[j + 1];
                        productos[j + 1] = productos[j];
                        productos[j] = aux;
                    }
                }
            }
            actualizarGrilla();
        }

        private int buscar(string buscar)
        {
           return busquedaBinaria(ref productos, buscar, 0, productos.Count-1);
        }

        int busquedaBinaria(ref List<MenuE> arreglo, string buscar, int inicio, int fin)
        {
            int centro;
            if (inicio <= fin)
            {
                centro = (inicio + fin) / 2;
                if (buscar == arreglo[centro].nombre)
                {
                    return centro;
                }
                int comparar = buscar.CompareTo(productos[centro].nombre);
                if (comparar > 0)
                {
                    inicio = centro + 1;
                }
                if (comparar < 0)
                {
                    fin = centro - 1;
                }
                return busquedaBinaria(ref arreglo, buscar, inicio, fin);
            }
            return -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             try
            {
                int posicion = buscar(txtBuscar.Text);
                dgv1.Rows[posicion].Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Producto incorrecto, vuelva a intentarlo", "ERROR DE BÚSQUEDA",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             txtBuscar.Clear();
             txtBuscar.Focus();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string error = listado.cargarDesdeArchivo();
            if (error != "")
                MessageBox.Show(error);
            actualizarGrilla();
        }
    }
}
