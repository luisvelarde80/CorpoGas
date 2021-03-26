using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Empresa
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public int Status { get; set; }

        public string RazonSocial { get; set; }

        public string Rfc { get; set; }

        public Byte[] ArchivoCer { get; set; }

        public Byte[] ArchivoKey { get; set; }

        public string Fiel { get; set; }

        public string Ciec { get; set; }

        public DateTime FechaConstitucion { get; set; }
        
    }
}
