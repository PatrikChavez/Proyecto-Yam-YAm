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
using System.Collections;
using System.Diagnostics;

namespace _1
{
    public partial class Form3 : Form
    {
        aviso P;
        List<Menu_Productos> productos = new List<Menu_Productos>();
        public Form3()
        {
            InitializeComponent();
            P = new aviso();
        }
        ListaProducto lista2 = new ListaProducto();
        ListaMenu lista = new ListaMenu();
        private void Form3_Load(object sender, EventArgs e)
        {
            //DATOS DEL MENÚ 
            cargarProductos();
            actualizarGrilla();
        }
        public void cargarProductos()
        {
            cargarDesdeArchivo();
            foreach (Menu_Productos p in productos)
            {
                lista.agregarProducto(p);
            }
        }
        //Seleccionar productos desde el button Menu        
        int posicionSeleccionada = -1;
        private void dg1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dg1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dg1.SelectedRows[0];
                    posicionSeleccionada = filaSeleccionada.Index;
                }
            }
            catch (Exception ex)
            {

            }
        }        
        //Button Venta y Total
        private void btnagregar_Click(object sender, EventArgs e)
        {            
            if(va() == true)
            {
                Compra nuevoProducto = new Compra();
                nuevoProducto.nombre = txtnombre.Text;
                nuevoProducto.precio = double.Parse(txtprecio.Text);
                nuevoProducto.cantidad = int.Parse(txtcantidad.Text);
                nuevoProducto.subtotal = nuevoProducto.precio * nuevoProducto.cantidad;
                lista2.agregarProducto(nuevoProducto);
                actualizarGrilla2();                
                txtnombre.ResetText();
                txtnombre.Focus();
                txtprecio.ResetText();
                txtprecio.Focus();
                txtcantidad.ResetText();
                txtcantidad.Focus();
            }
        }
        private void actualizarGrilla2()
        {
            List<Compra> productos = lista2.getLista();
            dg1.Rows.Clear();
            foreach (Compra p in productos)
            {
                int indiceNuevaFila = dg1.Rows.Add();
                DataGridViewRow filaNueva = dg1.Rows[indiceNuevaFila];
                filaNueva.Cells[0].Value = p.nombre;
                filaNueva.Cells[1].Value = p.precio;
                filaNueva.Cells[2].Value = p.cantidad;
            }
        }
        //VALIDACIÓN DEL CLIENTE
        public bool va()
        {
            int n;
            if (txtcantidad.Text == "")
            {
                error1.SetError(txtcantidad, "La cantidad que ingresaste no es válida");
                return false;
            }
            else
            {
                if (!(int.TryParse(txtcantidad.Text, out n)))
                {
                    error1.SetError(txtcantidad, "Ingrese un valor numérico");
                    return false;
                }
            }
            error1.SetError(txtcantidad, "");
            return true;
        }
        //DEL REGISTRO A LA LISTA(VENTANA TOTAL)
        public void Agregararreglo()
        {
            List<Compra> productos = lista2.getLista();

            lbxCanti.Items.Clear();
            lbxProducto.Items.Clear();
            lbxPrecioUnit.Items.Clear();
            lbxImporte.Items.Clear();
            foreach (Compra p in productos)
            {
                lbxCanti.Items.Add(p.cantidad);
                lbxProducto.Items.Add(p.nombre);
                lbxPrecioUnit.Items.Add(p.precio);
                lbxImporte.Items.Add(p.subtotal);                
            }            
        }
        public void escribir(string nombre,double precio, int cantidad, double subtotal)
        {
            try
            {
                StreamWriter sw = new StreamWriter("Lista.csv", true);
                sw.WriteLine(nombre + ";" + precio + ";" + cantidad + ";" + subtotal);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("error:" + e.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbfecha.Text = DateTime.Now.ToLongDateString();
        }
        private void btnventa_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            tb1.Show();
        }
            private void button3_Click_1(object sender, EventArgs e)
        {
            tb1.Visible = false;
            panel2.Visible = false;
        }
        public void cargarDesdeArchivo()
        {
            try
            {
                productos = new List<Menu_Productos>();
                StreamReader sr = new StreamReader("Menú.txt");
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    productos.Add(new Menu_Productos(linea));
                    //Leer linea
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            tb1.Visible = false;
            panel2.Visible = true;
        }
        //REGRESAR
        private void pbxRegresar_Click(object sender, EventArgs e)
        {
            //sw.Close();
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
        //SALIR
        private void pictureBox1_Click(object sender, EventArgs e)
        {           
            P.Show();
        }    
        //LOS DATOS DEL LA TABLA AL SELECCIONAR APAREZCA EN LAS CASILLAS DE LOS TEXTBOX 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtnombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtprecio.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
            }
        }
        private void btnRealizar_Click(object sender, EventArgs e)
        {
            List<Compra> productos = lista2.getLista();
            Agregararreglo();
            double total = 0;
            foreach (double aux in lbxImporte.Items)
            {
                total = total + aux;
            }
            lblTotal.Text = total.ToString();
            MessageBox.Show("Puede pasar a la ventana ''TOTAL'' a ver su boleta", "BOLETA REALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Guardar en el excel
            foreach (Compra p in productos)
            {
                escribir(p.nombre, p.precio, p.cantidad,p.subtotal);
            }
        }

        //ELIMINAR DESDE DATA GRID VIEW
        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                lista2.eliminarProducto(posicionSeleccionada);
                actualizarGrilla2();
            }
            catch
            {
                MessageBox.Show("Seleccione un producto", "SELECCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //MENU DE PRODUCTOS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int posicion = buscar(txtBuscar.Text);
                dataGridView1.Rows[posicion].Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Producto incorrecto, vuelva a intentarlo", "ERROR DE BÚSQUEDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBuscar.Clear();
            txtBuscar.Focus();
        }
        private int buscar(string buscar)
        {
            return busquedaBinaria(ref productos, buscar, 0, productos.Count - 1);
        }
        int busquedaBinaria(ref List<Menu_Productos> arreglo, string buscar, int inicio, int fin)
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
                        comparar = productos[j].precio.CompareTo(productos[j + 1].precio);
                    }

                    if (comparar > 0)
                    {
                        Menu_Productos aux = productos[j + 1];
                        productos[j + 1] = productos[j];
                        productos[j] = aux;
                    }
                }
            }
            actualizarGrilla();
        }
        public void actualizarGrilla()
        {
            List<Menu_Productos> productos1 = lista.getLista();
            productos = productos1;
            dataGridView1.Rows.Clear();
            foreach (Menu_Productos p in productos)
            {
                int indiceNuevaFila = dataGridView1.Rows.Add();
                DataGridViewRow filaNueva = dataGridView1.Rows[indiceNuevaFila];
                filaNueva.Cells[0].Value = p.nombre;
                filaNueva.Cells[1].Value = p.precio;
            }
        }
    }
}
