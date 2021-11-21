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
    public partial class pnCrearCliente : Form
    {
        public pnCrearCliente()
        {
            InitializeComponent();
        }
        ListaUsuario listado = new ListaUsuario();
        Listaempleados listadoE = new Listaempleados();
        //REGISTRO DE CLIENTE
        private void btnRegistrarNuevo_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                Usuarios user = new Usuarios();
                user.nombre = txtNombre.Text;
                user.apellido = txtApellido.Text;
                user.contra = txtContraNueva.Text;
                user.usuario = txtUsuarioNuevo.Text;
                listado.agregar(user);
                listado.guardarEnArchivo();
                MessageBox.Show("El usuario ha sido registrado", "REGISTRO ACEPTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtApellido.Text = "Apellido";
            txtNombre.Text = "Nombre";
            txtContraNueva1.Text = "";
            txtContraNueva.Text = "";
            txtUsuarioNuevo.Text = "";
        }
        //VALIDACION DEL CLIENTE
        public bool Validar()
        {
            int x, a;
            double y, b;
            if (txtNombre.Text == "" || txtNombre.Text == "Nombre" || double.TryParse(txtNombre.Text, out y) || int.TryParse(txtNombre.Text, out x))
            {
                Error.SetError(txtNombre, " ");
                lblAlerta.Text = "El nombre que ingresaste no es válido";
                txtNombre.Clear();
                txtNombre.Focus();
                return false;
            }
            Error.SetError(txtNombre, "");
            if (txtApellido.Text == "Apellido" || txtApellido.Text == "" || double.TryParse(txtApellido.Text, out b) || int.TryParse(txtNombre.Text, out a))
            {
                Error.SetError(txtApellido, " ");
                lblAlerta.Text = "El apellido que ingresaste no es válido";
                txtApellido.Clear();
                txtApellido.Focus();
                return false;
            }
            Error.SetError(txtApellido, "");

            if (txtUsuarioNuevo.Text == "" || double.TryParse(txtApellido.Text, out y) || int.TryParse(txtNombre.Text, out x))
            {
                Error.SetError(txtUsuarioNuevo, " ");
                lblAlerta.Text = "El usuario que ingresaste no es válido";
                txtApellido.Clear();
                txtApellido.Focus();
                return false;
            }
            Error.SetError(txtApellido, "");

            if (txtContraNueva.Text == "")
            {
                Error.SetError(txtContraNueva, " ");
                lblAlerta.Text = "La contraseña que ingresaste no es válido";
                txtContraNueva.Clear();
                txtContraNueva.Focus();
                return false;
            }
            Error.SetError(txtContraNueva, "");

            if (txtContraNueva1.Text != txtContraNueva.Text)
            {
                Error.SetError(txtContraNueva1, " ");
                lblAlerta.Text = "Las contraseñas no coinciden";
                txtContraNueva1.Clear();
                txtContraNueva1.Focus();
                return false;
            }
            Error.SetError(txtContraNueva1, "");
            return true;
        }

        //REGISTRO DEL EMPLEADO
           private void btnRegistrarE_Click(object sender, EventArgs e)
        {
             if (ValidarE() == true)
            {
                Empleados emple = new Empleados();
                emple.codigo = txtCodigo.Text;
                emple.nombreE = txtUsuarioE.Text;
                emple.contraE = txtContraE.Text;
                listadoE.agregarE(emple);
                listadoE.guardarEnArchivoE();
                MessageBox.Show("El usuario ha sido registrado", "REGISTRO ACEPTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtCodigo.Text="Código";
            txtUsuarioE.Text = "";
            txtContraE.Text = "";
            txtContraNewE.Text = "";
        }
        
        //VALIDACION DEL EMPLEADO
        public bool ValidarE()
        {
            double b;
            if (txtCodigo.Text != "200PANDXP")
            {
                Error.SetError(txtCodigo, " ");
                lblAlerta.Text = "El Código que ingresaste no es válido";
                txtCodigo.Clear();
                txtCodigo.Focus();
                return false;
            }
            Error.SetError(txtCodigo, "");
            if (txtUsuarioE.Text == ""|| double.TryParse(txtUsuarioE.Text, out b))
            {
                Error.SetError(txtUsuarioE, " ");
                lblAlerta.Text = "El Usuario que ingresaste no es válido";
                txtUsuarioE.Clear();
                txtUsuarioE.Focus();
                return false;
            }
            Error.SetError(txtUsuarioE, "");

            if (txtContraE.Text == "")
            {
                Error.SetError(txtContraE, " ");
                lblAlerta.Text = "La contraseña que ingresaste no es válido";
                txtContraE.Clear();
                txtContraE.Focus();
                return false;
            }
            Error.SetError(txtContraE, "");

            if (txtContraNewE.Text != txtContraE.Text)
            {
                Error.SetError(txtContraNewE, " ");
                lblAlerta.Text = "Las contraseñas no coinciden";
                txtContraNewE.Clear();
                txtContraNewE.Focus();
                return false;
            }
            Error.SetError(txtContraNewE, "");
            return true;
        }
        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text = "";
        }

        private void txtApellido_MouseClick(object sender, MouseEventArgs e)
        {
            txtApellido.Text = "";
        }

        private void txtCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            txtCodigo.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //boton volver crear cuenta cliente
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void btnVolverE_Click(object sender, EventArgs e)
        {
            //boton volver crear cuenta empleado
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
        //PANEL DEL EMPLEADO
        public void aparecer()
        {
            pnNewE.Hide();
            this.Show();
        }

    }
}
