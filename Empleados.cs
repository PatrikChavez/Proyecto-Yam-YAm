using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Empleados
    {
        public string codigo { get; set; }
        public string nombreE { get; set; }
        public string contraE { get; set; }

        public string DataParaArchivoE
        {
            get
            {
                return codigo + ' ' + nombreE
                    + ' ' + contraE;
            }
        }
    }
}
