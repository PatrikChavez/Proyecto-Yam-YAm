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
using System.Diagnostics;

namespace _1
{
    public partial class Form1 : Form
    {
        List<string> usuario = new List<string>();
        List<string> contraseña = new List<string>();
        List<string> empleado = new List<string>();
        List<string> contraseña_empleado = new List<string>();
        Form3 formularioingreso;
        Form4 formularioempleado;
        pnCrearCliente crear;
        aviso P;
        pnCrearCliente objCrear = new pnCrearCliente();
        public Form1()
        {
            InitializeComponent();
            formularioingreso = new Form3();
            crear = new pnCrearCliente();
            formularioempleado = new Form4();
            P = new aviso();
        }        
        //Button salir inicio
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            P.Show();
        }  
        private void btnCliente_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            pnCliente.Show();
        }
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            pnCliente.Hide();
        }    
        private void pnCliente_Paint(object sender, PaintEventArgs e)
        {
            //Cliente
            StreamReader usuarios = new StreamReader("Usuarios.txt");
            string lines = "";
            while ((lines = usuarios.ReadLine()) != null)
            {
                string[] componentes2 = lines.Split(' ');
                usuario.Add(componentes2[3]);
                contraseña.Add(componentes2[2]);
            }
            usuarios.Close();
        }
        //VALIDACIÓN DEL CLIENTE
        public bool validar()
        {
            if (!(usuario.Contains(txtUsuario.Text)))
            {
                error.SetError(txtUsuario, " ");
                lblCorrecionCliente.Text = "El usuario que ingresaste es incorrecto";
                return false;
            }
            error.SetError(txtUsuario, "");
            if (!(contraseña.Contains(txtContra.Text)))
            {
                error.SetError(txtContra, " ");
                lblCorrecionCliente.Text = "La contraseña que ingresaste es incorrecta";
                return false;
            }
            error.SetError(txtContra, "");
            if (Array.IndexOf(usuario.ToArray(), txtUsuario.Text) != Array.IndexOf(contraseña.ToArray(), txtContra.Text))
            {
                error.SetError(txtContra, " ");
                error.SetError(txtUsuario, " ");
                lblCorrecionCliente.Text = "Los datos no coinciden";
                return false;
            }
            error.SetError(txtContra, "");
            error.SetError(txtUsuario, " ");
            return true;
        }
       
        //iniciar sesión del cliente
        private void button1_Click(object sender, EventArgs e)
        {
            if (usuario.Contains(txtUsuario.Text) && contraseña.Contains(txtContra.Text)
                && Array.IndexOf(usuario.ToArray(), txtUsuario.Text) == Array.IndexOf(contraseña.ToArray(), txtContra.Text))
            {
                formularioingreso.Show();
                this.Hide();
            }
            else if(validar() == true)
            {
                formularioingreso.Show();
                this.Hide();
            }
        }
        //Boton Iniciar de Cliente
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
        }
        //Button CREAR CUENTA DEL CLIENTE
        private void button3_Click(object sender, EventArgs e)
        {
            objCrear.aparecer();
            this.Hide();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.DarkBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkBlue;
            button3.ForeColor = Color.White;
        }        

        //Cerrar Cliente
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            P.Show();
        }

        //Button regresar cliente
        private void pbxRegresar_Click(object sender, EventArgs e)
        {
            pnCliente.Hide();
            panel1.Show();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            //Empleado
            StreamReader empleados = new StreamReader("UsuarioEmpleado.txt");
            string lines = "";
            while ((lines = empleados.ReadLine()) != null)
            {
                string[] componente = lines.Split(' ');
                empleado.Add(componente[1]);
                contraseña_empleado.Add(componente[2]);
            }
            empleados.Close();            
        }
        //VALIDACION DEL EMPLEADO
        public bool validarE()
        {
            if (!(empleado.Contains(txtUsuarioE.Text)))
            {
                error.SetError(txtUsuarioE, " ");
                lblErrorE.Text = "El usuario que ingresaste es incorrecto";
                return false;
            }
            error.SetError(txtUsuarioE, "");
            if (!(contraseña_empleado.Contains(txtContraE.Text)))
            {
                error.SetError(txtContraE, " ");
                lblErrorE.Text = "La contraseña que ingresaste es incorrecta";
                return false;
            }
            error.SetError(txtContraE, "");
            if (Array.IndexOf(empleado.ToArray(), txtUsuarioE.Text) != Array.IndexOf(contraseña_empleado.ToArray(), txtContraE.Text))
            {
                error.SetError(txtContraE, " ");
                error.SetError(txtUsuarioE, " ");
                lblErrorE.Text = "Los datos no coinciden";
                return false;
            }
            error.SetError(txtContraE, "");
            error.SetError(txtUsuarioE, " ");
            return true;
        }

        private void btnIniciarE_Click(object sender, EventArgs e)
        {
            if (empleado.Contains(txtUsuarioE.Text) && contraseña_empleado.Contains(txtContraE.Text) 
                && Array.IndexOf(empleado.ToArray(), txtUsuarioE.Text) == Array.IndexOf(contraseña_empleado.ToArray(), txtContraE.Text))
            {
                formularioempleado.Show();
                this.Hide();
            }
            else if (validarE() == true)
            {
                formularioempleado.Show();
                this.Hide();
            }
        }        
        //CREARCUENTA DEL EMPLEADO
        private void btnCrearCE_Click(object sender, EventArgs e)
        {
            this.Hide();
            crear.Show();
        }
        //Button regresar empleado
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pnCliente.Hide();
            panel1.Show();
        }
      
        //Cerrar Empleado
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            P.Show();
        }
    }
}
