﻿using System;
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

        #region "Selecciona Metadatos"

        public List<Solicitud> solicitudesMetadatos(string fechaIni, string fechaFin)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            List<Empresa> empresas = new List<Empresa>();
            Empresas objEmpresas = new Empresas();
            empresas = objEmpresas.empresas();

            foreach(var empresa in empresas)
            {
                cnObj = conectar.Empresa(empresa.Rfc);
                if (cnObj != null)
                {
                    using (cnObj)
                    {
                        SqlCommand cmdObj = new SqlCommand();
                        cmdObj.Connection = cnObj;
                        cmdObj.CommandTimeout = 0;

                        //Recibidos-Direccion=1,Emitidos-Direccion=0

                        strSql = "SELECT ";
                        strSql += "Id, ";
                        strSql += "FechaInicial, ";
                        strSql += "FechaFinal, ";
                        strSql += "TipoSolicitud, ";
                        strSql += "FechaSolicitud, ";
                        strSql += "Convert(int,Procesada), ";
                        strSql += "IdSolicitud, ";
                        strSql += "Mensaje, ";
                        strSql += "Direccion ";
                        strSql += "FROM ";
                        strSql += "ORI_SOLICITUDES ";
                        strSql += "WHERE ";
                        strSql += "FechaInicial = '" + fechaIni + "' and ";
                        strSql += "FechaFinal = '" + fechaFin + "' and ";
                        strSql += "TipoSolicitud = 1";

                        cmdObj.CommandText = strSql;
                        SqlDataReader rdrObj = cmdObj.ExecuteReader();
                        while (rdrObj.Read())
                        {
                            Solicitud solicitud = new Solicitud();
                            if (rdrObj[6].ToString() != "")
                            {
                                solicitud.Rfc = empresa.Rfc;
                                solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                                solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                                solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                                solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                                solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                                solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                                solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                                solicitud.Mensaje = rdrObj[7].ToString();
                                solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                                listaSolicitudes.Add(solicitud);
                            }
                        }
                        rdrObj.Close();
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesMetadatos(string fechaIni, string fechaFin, int tipo)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            List<Empresa> empresas = new List<Empresa>();
            Empresas objEmpresas = new Empresas();
            empresas = objEmpresas.empresas();

            foreach(var empresa in empresas)
            {
                cnObj = conectar.Empresa(empresa.Rfc);
                if (cnObj != null)
                {
                    using (cnObj)
                    {
                        SqlCommand cmdObj = new SqlCommand();
                        cmdObj.Connection = cnObj;
                        cmdObj.CommandTimeout = 0;

                        //Recibidos-Direccion=1,Emitidos-Direccion=0

                        strSql = "SELECT ";
                        strSql += "Id, ";
                        strSql += "FechaInicial, ";
                        strSql += "FechaFinal, ";
                        strSql += "TipoSolicitud, ";
                        strSql += "FechaSolicitud, ";
                        strSql += "Convert(int,Procesada), ";
                        strSql += "IdSolicitud, ";
                        strSql += "Mensaje, ";
                        strSql += "Direccion ";
                        strSql += "FROM ";
                        strSql += "ORI_SOLICITUDES ";
                        strSql += "WHERE ";
                        strSql += "FechaInicial = '" + fechaIni + "' and ";
                        strSql += "FechaFinal = '" + fechaFin + "' and ";
                        strSql += "Direccion = " + tipo + " and ";
                        strSql += "TipoSolicitud = 1";

                        cmdObj.CommandText = strSql;
                        SqlDataReader rdrObj = cmdObj.ExecuteReader();
                        while (rdrObj.Read())
                        {
                            Solicitud solicitud = new Solicitud();
                            if (rdrObj[6].ToString() != "")
                            {
                                solicitud.Rfc = empresa.Rfc;
                                solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                                solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                                solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                                solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                                solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                                solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                                solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                                solicitud.Mensaje = rdrObj[7].ToString();
                                solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                                listaSolicitudes.Add(solicitud);
                            }
                        }
                        rdrObj.Close();
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesMetadatos(string rfc, string fechaIni, string fechaFin)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            
            cnObj = conectar.Empresa(rfc);
            if(cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    //Recibidos-Direccion=1,Emitidos-Direccion=0

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "FechaInicial, ";
                    strSql += "FechaFinal, ";
                    strSql += "TipoSolicitud, ";
                    strSql += "FechaSolicitud, ";
                    strSql += "Convert(int,Procesada), ";
                    strSql += "IdSolicitud, ";
                    strSql += "Mensaje, ";
                    strSql += "Direccion ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "FechaInicial = '" + fechaIni + "' and ";
                    strSql += "FechaFinal = '" + fechaFin +"' and ";
                    strSql += "TipoSolicitud = 1";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                        if (rdrObj[6].ToString() != "")
                        {
                            solicitud.Rfc = rfc;
                            solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                            solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                            solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                            solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                            solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                            solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                            solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                            solicitud.Mensaje = rdrObj[7].ToString();
                            solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                            listaSolicitudes.Add(solicitud);
                        }
                    }
                    rdrObj.Close();
                }       
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesMetadatos(string rfc, string fechaIni, string fechaFin, int tipo)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();

            cnObj = conectar.Empresa(rfc);
            if (cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    //Recibidos-Direccion=1,Emitidos-Direccion=0

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "FechaInicial, ";
                    strSql += "FechaFinal, ";
                    strSql += "TipoSolicitud, ";
                    strSql += "FechaSolicitud, ";
                    strSql += "Convert(int,Procesada), ";
                    strSql += "IdSolicitud, ";
                    strSql += "Mensaje, ";
                    strSql += "Direccion ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "FechaInicial = '" + fechaIni + "' and ";
                    strSql += "FechaFinal = '" + fechaFin + "' and ";
                    strSql += "Direccion = "+ tipo +" and ";
                    strSql += "TipoSolicitud = 1";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                        if (rdrObj[6].ToString() != "")
                        {
                            solicitud.Rfc = rfc;
                            solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                            solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                            solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                            solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                            solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                            solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                            solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                            solicitud.Mensaje = rdrObj[7].ToString();
                            solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                            listaSolicitudes.Add(solicitud);
                        }
                    }
                    rdrObj.Close();
                }
            }

            return listaSolicitudes;
        }

        #endregion

        #region "Selecciona Cfdi"

        public List<Solicitud> solicitudesCfdi(string fechaIni, string fechaFin)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            List<Empresa> empresas = new List<Empresa>();
            Empresas objEmpresas = new Empresas();
            empresas = objEmpresas.empresas();

            foreach (var empresa in empresas)
            {
                cnObj = conectar.Empresa(empresa.Rfc);
                if (cnObj != null)
                {
                    using (cnObj)
                    {
                        SqlCommand cmdObj = new SqlCommand();
                        cmdObj.Connection = cnObj;
                        cmdObj.CommandTimeout = 0;

                        //Recibidos-Direccion=1,Emitidos-Direccion=0

                        strSql = "SELECT ";
                        strSql += "Id, ";
                        strSql += "FechaInicial, ";
                        strSql += "FechaFinal, ";
                        strSql += "TipoSolicitud, ";
                        strSql += "FechaSolicitud, ";
                        strSql += "Convert(int,Procesada), ";
                        strSql += "IdSolicitud, ";
                        strSql += "Mensaje, ";
                        strSql += "Direccion ";
                        strSql += "FROM ";
                        strSql += "ORI_SOLICITUDES ";
                        strSql += "WHERE ";
                        strSql += "FechaInicial BETWEEN '" + fechaIni + "' and '" + fechaFin + "' and ";
                        strSql += "TipoSolicitud = 0";

                        cmdObj.CommandText = strSql;
                        SqlDataReader rdrObj = cmdObj.ExecuteReader();
                        while (rdrObj.Read())
                        {
                            Solicitud solicitud = new Solicitud();
                            if (rdrObj[6].ToString() != "")
                            {
                                solicitud.Rfc = empresa.Rfc;
                                solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                                solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                                solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                                solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                                solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                                solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                                solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                                solicitud.Mensaje = rdrObj[7].ToString();
                                solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                                listaSolicitudes.Add(solicitud);
                            }
                        }
                        rdrObj.Close();
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesCfdi(string fechaIni, string fechaFin, int tipo)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();
            List<Empresa> empresas = new List<Empresa>();
            Empresas objEmpresas = new Empresas();
            empresas = objEmpresas.empresas();

            foreach (var empresa in empresas)
            {
                cnObj = conectar.Empresa(empresa.Rfc);
                if (cnObj != null)
                {
                    using (cnObj)
                    {
                        SqlCommand cmdObj = new SqlCommand();
                        cmdObj.Connection = cnObj;
                        cmdObj.CommandTimeout = 0;

                        //Recibidos-Direccion=1,Emitidos-Direccion=0

                        strSql = "SELECT ";
                        strSql += "Id, ";
                        strSql += "FechaInicial, ";
                        strSql += "FechaFinal, ";
                        strSql += "TipoSolicitud, ";
                        strSql += "FechaSolicitud, ";
                        strSql += "Convert(int,Procesada), ";
                        strSql += "IdSolicitud, ";
                        strSql += "Mensaje, ";
                        strSql += "Direccion ";
                        strSql += "FROM ";
                        strSql += "ORI_SOLICITUDES ";
                        strSql += "WHERE ";
                        strSql += "FechaInicial BETWEEN '" + fechaIni + "' and '" + fechaFin + "' and ";
                        strSql += "Direccion = " + tipo + " and ";
                        strSql += "TipoSolicitud = 0";

                        cmdObj.CommandText = strSql;
                        SqlDataReader rdrObj = cmdObj.ExecuteReader();
                        while (rdrObj.Read())
                        {
                            Solicitud solicitud = new Solicitud();
                            if (rdrObj[6].ToString() != "")
                            {
                                solicitud.Rfc = empresa.Rfc;
                                solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                                solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                                solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                                solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                                solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                                solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                                solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                                solicitud.Mensaje = rdrObj[7].ToString();
                                solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                                listaSolicitudes.Add(solicitud);
                            }
                        }
                        rdrObj.Close();
                    }
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesCfdi(string rfc, string fechaIni, string fechaFin)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();

            cnObj = conectar.Empresa(rfc);
            if (cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    //Recibidos-Direccion=1,Emitidos-Direccion=0

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "FechaInicial, ";
                    strSql += "FechaFinal, ";
                    strSql += "TipoSolicitud, ";
                    strSql += "FechaSolicitud, ";
                    strSql += "Convert(int,Procesada), ";
                    strSql += "IdSolicitud, ";
                    strSql += "Mensaje, ";
                    strSql += "Direccion ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "FechaInicial BETWEEN '" + fechaIni + "' and '" + fechaFin + "' and ";
                    strSql += "TipoSolicitud = 0";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                        if (rdrObj[6].ToString() != "")
                        {
                            solicitud.Rfc = rfc;
                            solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                            solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                            solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                            solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                            solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                            solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                            solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                            solicitud.Mensaje = rdrObj[7].ToString();
                            solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                            listaSolicitudes.Add(solicitud);
                        }
                    }
                    rdrObj.Close();
                }
            }

            return listaSolicitudes;
        }

        public List<Solicitud> solicitudesCfdi(string rfc, string fechaIni, string fechaFin, int tipo)
        {
            fechaFin += " 23:59:59";

            List<Solicitud> listaSolicitudes = new List<Solicitud>();

            cnObj = conectar.Empresa(rfc);
            if (cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    //Recibidos-Direccion=1,Emitidos-Direccion=0

                    strSql = "SELECT ";
                    strSql += "Id, ";
                    strSql += "FechaInicial, ";
                    strSql += "FechaFinal, ";
                    strSql += "TipoSolicitud, ";
                    strSql += "FechaSolicitud, ";
                    strSql += "Convert(int,Procesada), ";
                    strSql += "IdSolicitud, ";
                    strSql += "Mensaje, ";
                    strSql += "Direccion ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "FechaInicial BETWEEN '" + fechaIni + "' and '" + fechaFin + "' and ";
                    strSql += "Direccion = " + tipo + " and ";
                    strSql += "TipoSolicitud = 0";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    while (rdrObj.Read())
                    {
                        Solicitud solicitud = new Solicitud();
                        if (rdrObj[6].ToString() != "")
                        {
                            solicitud.Rfc = rfc;
                            solicitud.Id = Guid.Parse(rdrObj[0].ToString());
                            solicitud.FechaInicial = DateTime.Parse(rdrObj[1].ToString());
                            solicitud.FechaFinal = DateTime.Parse(rdrObj[2].ToString());
                            solicitud.TipoSolicitud = Convert.ToInt32(rdrObj[3].ToString());
                            solicitud.FechaSolicitud = DateTime.Parse(rdrObj[4].ToString());
                            solicitud.Procesada = Convert.ToInt32(rdrObj[5].ToString());
                            solicitud.IdSolicitud = Guid.Parse(rdrObj[6].ToString());
                            solicitud.Mensaje = rdrObj[7].ToString();
                            solicitud.Direccion = Convert.ToInt32(rdrObj[8].ToString());

                            listaSolicitudes.Add(solicitud);
                        }
                    }
                    rdrObj.Close();
                }
            }

            return listaSolicitudes;
        }

        #endregion

    }
}
