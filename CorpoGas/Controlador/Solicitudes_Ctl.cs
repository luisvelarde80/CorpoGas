using Modelo;
using Modelo.Crud;
using System.Collections.Generic;
using System.Data;
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

        #region "Cfdi"

        public List<Solicitud> solicitudesCfdi(string fechaIni, string fechaFin)
        {
            return objSolicitudes.solicitudesCfdi(fechaIni, fechaFin);
        }

        public List<Solicitud> solicitudesCfdi(string fechaIni, string fechaFin, int tipo)
        {
            return objSolicitudes.solicitudesCfdi(fechaIni, fechaFin, tipo);
        }

        public List<Solicitud> solicitudesCfdi(string rfc, string fechaIni, string fechaFin)
        {
            return objSolicitudes.solicitudesCfdi(rfc, fechaIni, fechaFin);
        }

        public List<Solicitud> solicitudesCfdi(string rfc, string fechaIni, string fechaFin, int tipo)
        {
            return objSolicitudes.solicitudesCfdi(rfc, fechaIni, fechaFin, tipo);
        }

        #endregion

        #region "Xml"

        public List<Xml> Solicitudesxml(string rfc, string fechaIni, string fechaFin)
        {
            return objSolicitudes.Solicitudesxml(rfc, fechaIni, fechaFin);
        }

        public List<Xml> Solicitudesxml(string rfc, string fechaIni, string fechaFin, int tipo)
        {
            return objSolicitudes.Solicitudesxml(rfc, fechaIni, fechaFin, tipo);
        }

        public List<Xml> Solicitudesxml(string rfc, string Uuid, int tipo)
        {
            return objSolicitudes.Solicitudesxml(rfc, Uuid, tipo);
        }

        public List<Xml> Solicitudesxml(string rfc, DataTable dtUuid, int tipo)
        {
            return objSolicitudes.Solicitudesxml(rfc, dtUuid, tipo);
        }

        #endregion

    }

}
