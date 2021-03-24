using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Solicitud
    {

        public string Rfc { get; set; }

        public Guid Id { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public int  TipoSolicitud { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public int Procesada { get; set; }

        public int Receptor { get; set; }

        public Guid IdSolicitud { get; set; }

        public string Mensaje { get; set; }

    }
}
