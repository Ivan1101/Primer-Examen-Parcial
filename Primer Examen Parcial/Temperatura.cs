using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_Examen_Parcial
{
    class Temperatura
    {
        string numero_Identificación;
        string medición;
        DateTime Fecha;

        public string Numero_Identificación { get => numero_Identificación; set => numero_Identificación = value; }
        public string Medición { get => medición; set => medición = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
    }
}
