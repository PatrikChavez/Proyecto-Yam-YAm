using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _1
{
    class ListaUsuario
    {
        List<Usuarios> usuarios = new List<Usuarios>();
        public void agregar(Usuarios usuario)
        {
            usuarios.Add(usuario);
        }
        public void guardarEnArchivo()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Usuarios.txt", true);
                foreach (Usuarios aux in usuarios)
                {
                    sw.WriteLine(aux.DataParaArchivo);
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
