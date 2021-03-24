using Modelo;
using Modelo.Crud;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class Solicitudes_Ctl
    {

        #region "Variables"

        Solicitudes objSolicitudes = new Solicitudes();

        #endregion

        public List<Solicitud> solicitudes(string rfc, string fechaIni, string fechaFin)
        {
            return objSolicitudes.solicitudes(rfc, fechaIni, fechaFin);
        }

    }

}
