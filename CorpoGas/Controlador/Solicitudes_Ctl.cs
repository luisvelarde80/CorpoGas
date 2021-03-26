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

        #region "Metadatos"

        public List<Solicitud> solicitudesMetadatos(string fechaIni, string fechaFin)
        {
            return objSolicitudes.solicitudesMetadatos(fechaIni, fechaFin);
        }

        public List<Solicitud> solicitudesMetadatos(string fechaIni, string fechaFin, int tipo)
        {
            return objSolicitudes.solicitudesMetadatos(fechaIni, fechaFin, tipo);
        }

        public List<Solicitud> solicitudesMetadatos(string rfc, string fechaIni, string fechaFin)
        {
            return objSolicitudes.solicitudesMetadatos(rfc, fechaIni, fechaFin);
        }

        public List<Solicitud> solicitudesMetadatos(string rfc, string fechaIni, string fechaFin, int tipo)
        {
            return objSolicitudes.solicitudesMetadatos(rfc, fechaIni, fechaFin, tipo);
        }

        #endregion

    }

}
