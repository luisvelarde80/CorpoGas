using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Modelo.Crud
{
    public class Empresas
    {
        #region "Variables"

        Conexion conectar = new Conexion();
        SqlConnection cnObj = new SqlConnection();
        string strSql = "";

        #endregion

        #region "Selecciona"

        public List<Empresa> empresas() {

            List<Empresa> listaEmpresas = new List<Empresa>();

            cnObj = conectar.Corpogas();
            if(cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "Nombre, ";
                    strSql += "Status, ";
                    strSql += "RazonSocial, ";
                    strSql += "Rfc, ";
                    strSql += "ArchivoCer, ";
                    strSql += "ArchivoKey, ";
                    strSql += "ArchivoPfx, ";
                    strSql += "Fiel, ";
                    strSql += "Ciec, ";
                    strSql += "FechaConstitucion ";
                    strSql += "FROM ";
                    strSql += "CAT_EMPRESAS ";
                    strSql += "WHERE ";
                    strSql += "Status = 1 ";
                    strSql += "ORDER BY RazonSocial";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {

                        Empresa empresa = new Empresa();
                        empresa.Id = Guid.Parse(rdrObj[0].ToString());
                        empresa.Nombre = rdrObj[1].ToString();
                        empresa.Status = Convert.ToInt32(rdrObj[2].ToString());
                        empresa.RazonSocial = rdrObj[3].ToString();
                        empresa.Rfc = rdrObj[4].ToString();
                        if(rdrObj[5] is DBNull)
                        {

                        }
                        else
                        {
                            empresa.ArchivoCer = (Byte[])rdrObj[5];
                        }
                        if(rdrObj[6] is DBNull)
                        {

                        }
                        else
                        {
                            empresa.ArchivoKey = (Byte[])rdrObj[6];
                        }
                        empresa.Fiel = rdrObj[8].ToString();
                        empresa.Ciec = rdrObj[9].ToString();
                        empresa.FechaConstitucion = DateTime.Parse(rdrObj[10].ToString());

                        listaEmpresas.Add(empresa);
                    }
                    rdrObj.Close();
                }
            }

            return listaEmpresas;

        }


        #endregion

    }
}
