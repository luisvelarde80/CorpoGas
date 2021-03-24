using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modelo.Crud
{
    public class Solicitudes
    {

        #region "Variables"

        Conexion conectar = new Conexion();
        SqlConnection cnObj = new SqlConnection();
        string strSql = "";

        #endregion

        #region "Selecciona"

        public List<Solicitud> solicitudes(string rfc, string fechaIni, string fechaFin)
        {
            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            
            cnObj = conectar.Empresa(rfc);
            if(cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "FechaInicial, ";
                    strSql += "FechaFinal, ";
                    strSql += "TipoSolicitud, ";
                    strSql += "FechaSolicitud, ";
                    strSql += "Procesada, ";
                    strSql += "Receptor, ";
                    strSql += "IdSolicitud, ";
                    strSql += "Mensaje ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "FechaInicial between '"+ fechaIni +"' and '"+ fechaFin +"'";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                        solicitud.Rfc = rfc;
                        solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                        solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                        solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                        solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                        solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                        solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                        solicitud.Receptor = Convert.ToInt32(rdrObj[7].ToString());
                        solicitud.IdSolicitud = Guid.Parse(rdrObj[8].ToString());
                        solicitud.Mensaje = rdrObj[9].ToString();

                        listaSolicitudes.Add(solicitud);

                    }
                    rdrObj.Close();
                }       
            }

            return listaSolicitudes;
        }

        #endregion

    }
}
