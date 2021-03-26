using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Faltantes
    {

        public string Tipo { get; set; }

        public string Uudi { get; set; }

        public string RFCEmisor { get; set; }

        public string NombreEmisor { get; set; }

        public string RFCReceptor { get; set; }

        public string NombreReceptor { get; set; }

        public string RFCPac { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaCer { get; set; }

        public double Monto { get; set; }

        public string Efecto { get; set; }

        public string Estatus { get; set; }

        public DateTime FechaCancelacion { get; set; }

    }

}
