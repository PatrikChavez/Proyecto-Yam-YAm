using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Windows.Forms;

namespace _1
{
    class Listaempleados
    {
        List<Empleados> empleados = new List<Empleados>();
        public void agregarE(Empleados usuarioE)
        {
            empleados.Add(usuarioE);
        }
        public void guardarEnArchivoE()
        {
            try
            {
                StreamWriter sw = new StreamWriter("UsuarioEmpleado.txt", true);
                foreach (Empleados aux in empleados)
                {
                    sw.WriteLine(aux.DataParaArchivoE);
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
