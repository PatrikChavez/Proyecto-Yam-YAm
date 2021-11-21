using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Usuarios
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contra { get; set; }
        public string usuario { get; set; }
        public string DataParaArchivo
        {
            get
            {
                return nombre + ' ' + apellido
                    + ' ' + contra + ' ' + usuario;
            }
        }
        //Leer usuarios ya creados
        public Usuarios()
        {

        }
        public Usuarios(string linea)
        {
            string[] datos = linea.Split(' ');
            usuario = datos[0];
            contra = datos[1];
        }
    }
}
