using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_repaso
{
    class Control
    {
        string nombre;
        string apellido;
        string numcasa;
        int cuota;
        int contador;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Numcasa { get => numcasa; set => numcasa = value; }
        public int Cuota { get => cuota; set => cuota = value; }
        public int Contador { get => contador; set => contador = value; }
    }
}
