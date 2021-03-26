using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Modelo.Crud
{
    public class Archivos
    {

        #region "Variables"
        
        SqlConnection cnObj = new SqlConnection();
        Funciones objFunciones = new Funciones();
        string strSql = "";

        #endregion

        public void Metadato(string rfc, Guid Id,int direccion)
        {

            //direccion- 0 = Emitidos, 1 = Recibidos, Ambos = 2

            //Se crea la carpeta temporal para descargar los archivos
            string pathTemp = @"C:\CorpoGas";
            if (!Directory.Exists(pathTemp))
            {
                Directory.CreateDirectory(pathTemp);
                pathTemp += "\\Temp";
                if (!Directory.Exists(pathTemp))
                {
                    Directory.CreateDirectory(pathTemp);
                    switch (direccion)
                    {
                        case 0:
                            pathTemp += "\\Emitidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;

                        case 1:
                            pathTemp += "\\Recibidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;

                        case 2:
                            string pathAmbos = pathTemp + "\\Emitidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            pathAmbos = pathTemp + "\\Recibidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            break;
                    }
                }
            }
            else
            {
                pathTemp += "\\Temp";
                if (!Directory.Exists(pathTemp))
                {
                    Directory.CreateDirectory(pathTemp);
                    switch (direccion)
                    {
                        case 0:
                            pathTemp += "\\Emitidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;

                        case 1:
                            pathTemp += "\\Recibidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;
                        case 2:
                            string pathAmbos = pathTemp + "\\Emitidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            pathAmbos = pathTemp + "\\Recibidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            break;
                    }
                }
                else
                {
                    switch (direccion)
                    {
                        case 0:
                            pathTemp += "\\Emitidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;

                        case 1:
                            pathTemp += "\\Recibidos";
                            if (!Directory.Exists(pathTemp))
                            {
                                Directory.CreateDirectory(pathTemp);
                            }
                            break;
                        case 2:
                            string pathAmbos = pathTemp + "\\Emitidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            pathAmbos = pathTemp + "\\Recibidos";
                            if (!Directory.Exists(pathAmbos))
                            {
                                Directory.CreateDirectory(pathAmbos);
                            }
                            break;
                    }
                }
            }

            Conexion conectar = new Conexion();
            cnObj = conectar.Empresa(rfc);
            if(cnObj != null)
            {
                using (cnObj)
                {
                    SqlCommand cmdObj = new SqlCommand();
                    cmdObj.Connection = cnObj;
                    cmdObj.CommandTimeout = 0;

                    strSql = "SELECT ";
                    strSql += "Archivos ";
                    strSql += "FROM ";
                    strSql += "ORI_SOLICITUDES ";
                    strSql += "WHERE ";
                    strSql += "Id = '" + Id + "'";

                    cmdObj.CommandText = strSql;
                    SqlDataReader rdrObj = cmdObj.ExecuteReader();
                    if(rdrObj.HasRows == true)
                    {
                        while (rdrObj.Read())
                        {
                            var Resul = new byte[(rdrObj.GetBytes(0, 0, null, 0, int.MaxValue))];
                            rdrObj.GetBytes(0, 0, Resul, 0, Resul.Length);

                            using (var fs = new FileStream(pathTemp + "\\" + Id + ".zip", FileMode.Create, FileAccess.Write))
                                fs.Write(Resul, 0, Resul.Length);
                        }
                        rdrObj.Close();
                    }
                }
            }
            objFunciones.Descomprime(pathTemp + "\\" + Id, pathTemp + "\\" + Id + ".zip");
            File.Delete(pathTemp + "\\" + Id + ".zip");
            //ProcesaArchivo(pathTemp + "\\" + Id, direccion);
        }

        public List<Faltantes> ProcesaArchivo(int tipo)
        {
            //direccion- 0 = Emitidos, 1 = Recibidos
            //tipo 1 = Metadatos, 2 = Cancelados
            string pathEmitidos = "";
            string pathRecibidos = "";
            List<Faltantes> listaFaltante = new List<Faltantes>(); 

            if (Directory.Exists("C:\\CorpoGas\\Temp\\Emitidos"))
            {
                pathEmitidos = "C:\\CorpoGas\\Temp\\Emitidos";
            }
            if (Directory.Exists("C:\\CorpoGas\\Temp\\Recibidos"))
            {
                pathRecibidos = "C:\\CorpoGas\\Temp\\Recibidos";
            }

            if(tipo == 1)
            {
                if (pathEmitidos.Length > 0)
                {
                    string[] archivosEmitidos = Directory.GetFiles(pathEmitidos, "*.txt", SearchOption.AllDirectories);
                    
                    foreach (var archivoEmitido in archivosEmitidos)
                    {
                        
                        string[] Lineas = System.IO.File.ReadAllLines(archivoEmitido);
                        string lineaIncompleta = null;
                        string lineaAux = null;

                        int cuenta = 0;
                        Boolean lineaCompleta = true;

                        Conexion conectar = new Conexion();

                        foreach (var linea in Lineas)
                        {
                            if (cuenta > 0)
                            {
                                if (lineaCompleta != true)
                                {
                                    lineaAux = lineaIncompleta + linea;
                                }
                                else
                                {
                                    lineaAux = linea;
                                }

                                string[] Elementos = lineaAux.Trim().Split('~');
                                int separadores = lineaAux.Split('~').Count();

                                if (separadores == 12)
                                {
                                    cnObj = conectar.Empresa(Elementos[1].ToString());
                                    if (Elementos[11].ToString() == "")
                                    {
                                        if (cnObj != null)
                                        {
                                            using (cnObj)
                                            {
                                                SqlCommand cmdObj = new SqlCommand();
                                                cmdObj.Connection = cnObj;
                                                cmdObj.CommandTimeout = 0;

                                                strSql = "SELECT ";
                                                strSql += "* ";
                                                strSql += "FROM ";
                                                strSql += "ORI_DOCUMENTOSEMITIDOS ";
                                                strSql += "WHERE ";
                                                strSql += "Uuid = '" + Elementos[0].ToString() + "'";

                                                cmdObj.CommandText = strSql;
                                                SqlDataReader rdrObj = cmdObj.ExecuteReader();
                                                if (rdrObj.HasRows != true)
                                                {
                                                    Faltantes faltantes = new Faltantes();
                                                    faltantes = new Faltantes();
                                                    faltantes.Tipo = "EMITIDO";
                                                    faltantes.Uudi = Elementos[0].ToString();
                                                    faltantes.RFCEmisor = Elementos[1].ToString();
                                                    faltantes.NombreEmisor = Elementos[2].ToString();
                                                    faltantes.RFCReceptor = Elementos[3].ToString();
                                                    faltantes.NombreReceptor = Elementos[4].ToString();
                                                    faltantes.RFCPac = Elementos[5].ToString();
                                                    faltantes.FechaEmision = Convert.ToDateTime(Elementos[6].ToString());
                                                    faltantes.FechaCer = Convert.ToDateTime(Elementos[7].ToString());
                                                    faltantes.Monto = Convert.ToDouble(Elementos[8].ToString());
                                                    faltantes.Efecto = Elementos[9].ToString();
                                                    faltantes.Estatus = Elementos[10].ToString();
                                                    if (Elementos[11].ToString() != "")
                                                    {
                                                        faltantes.FechaCancelacion = Convert.ToDateTime(Elementos[11].ToString());

                                                    }
                                                    listaFaltante.Add(faltantes);
                                                }
                                            }
                                            cnObj.Close();
                                        }
                                    }
                                    else
                                    {
                                        cnObj.Close();
                                    }

                                    lineaCompleta = true;
                                }
                                else
                                {
                                    lineaCompleta = false;
                                    lineaIncompleta = linea;
                                }

                                cuenta += 1;
                            }
                            else
                            {
                                cuenta += 1;
                            }
                        }
                        File.Delete(archivoEmitido);
                    }
                    //Directory.Delete(pathEmitidos,true);
                }

                if (pathRecibidos.Length > 0)
                {
                    string[] archivosRecibidos = Directory.GetFiles(pathRecibidos, "*.txt", SearchOption.AllDirectories);
                    foreach (var archivoRecibido in archivosRecibidos)
                    {

                        string[] Lineas = System.IO.File.ReadAllLines(archivoRecibido);
                        string lineaIncompleta = null;
                        string lineaAux = null;

                        int cuenta = 0;
                        Boolean lineaCompleta = true;

                        Conexion conectar = new Conexion();

                        foreach (var linea in Lineas)
                        {
                            if (cuenta > 0)
                            {


                                if (lineaCompleta != true)
                                {
                                    lineaAux = lineaIncompleta + linea;
                                }
                                else
                                {
                                    lineaAux = linea;
                                }

                                string[] Elementos = lineaAux.Trim().Split('~');
                                int separadores = lineaAux.Split('~').Count();

                                if (separadores == 12)
                                {
                                    cnObj = conectar.Empresa(Elementos[3].ToString());
                                    if (Elementos[11].ToString() == "")
                                    {
                                        if (cnObj != null)
                                        {
                                            using (cnObj)
                                            {
                                                SqlCommand cmdObj = new SqlCommand();
                                                cmdObj.Connection = cnObj;
                                                cmdObj.CommandTimeout = 0;

                                                strSql = "SELECT ";
                                                strSql += "* ";
                                                strSql += "FROM ";
                                                strSql += "ORI_DOCUMENTOSRECIBIDOS ";
                                                strSql += "WHERE ";
                                                strSql += "Uuid = '" + Elementos[0].ToString() + "'";

                                                cmdObj.CommandText = strSql;
                                                SqlDataReader rdrObj = cmdObj.ExecuteReader();
                                                if (rdrObj.HasRows != true)
                                                {
                                                    Faltantes faltantes = new Faltantes();
                                                    faltantes = new Faltantes();
                                                    faltantes.Tipo = "RECIBIDO";
                                                    faltantes.Uudi = Elementos[0].ToString();
                                                    faltantes.RFCEmisor = Elementos[1].ToString();
                                                    faltantes.NombreEmisor = Elementos[2].ToString();
                                                    faltantes.RFCReceptor = Elementos[3].ToString();
                                                    faltantes.NombreReceptor = Elementos[4].ToString();
                                                    faltantes.RFCPac = Elementos[5].ToString();
                                                    faltantes.FechaEmision = Convert.ToDateTime(Elementos[6].ToString());
                                                    faltantes.FechaCer = Convert.ToDateTime(Elementos[7].ToString());
                                                    faltantes.Monto = Convert.ToDouble(Elementos[8].ToString());
                                                    faltantes.Efecto = Elementos[9].ToString();
                                                    faltantes.Estatus = Elementos[10].ToString();
                                                    if (Elementos[11].ToString() != "")
                                                    {
                                                        faltantes.FechaCancelacion = Convert.ToDateTime(Elementos[11].ToString());

                                                    }
                                                    listaFaltante.Add(faltantes);
                                                }
                                            }
                                            cnObj.Close();
                                        }
                                    }
                                    else
                                    {
                                        cnObj.Close();
                                    }
                                    lineaCompleta = true;
                                }
                                else
                                {
                                    lineaCompleta = false;
                                    lineaIncompleta = linea;
                                }

                                cuenta += 1;
                            }
                            else
                            {
                                cuenta += 1;
                            }
                        }
                        File.Delete(archivoRecibido);
                    }
                    //Directory.Delete(pathRecibidos,true);
                }
            }
            else if(tipo == 2){

                if (pathEmitidos.Length > 0)
                {
                    string[] archivosEmitidos = Directory.GetFiles(pathEmitidos, "*.txt", SearchOption.AllDirectories);
                    foreach (var archivoEmitido in archivosEmitidos)
                    {

                        string[] Lineas = System.IO.File.ReadAllLines(archivoEmitido);
                        string lineaIncompleta = null;
                        string lineaAux = null;

                        int cuenta = 0;
                        Boolean lineaCompleta = true;

                        Conexion conectar = new Conexion();

                        foreach (var linea in Lineas)
                        {
                            if (cuenta > 0)
                            {
                                if (lineaCompleta != true)
                                {
                                    lineaAux = lineaIncompleta + linea;
                                }
                                else
                                {
                                    lineaAux = linea;
                                }

                                string[] Elementos = lineaAux.Trim().Split('~');
                                int separadores = lineaAux.Split('~').Count();

                                if (separadores == 12)
                                {
                                    cnObj = conectar.Empresa(Elementos[1].ToString());
                                    if (Elementos[11].ToString() != "")
                                    {
                                        if (cnObj != null)
                                        {
                                            using (cnObj)
                                            {
                                                SqlCommand cmdObj = new SqlCommand();
                                                cmdObj.Connection = cnObj;
                                                cmdObj.CommandTimeout = 0;

                                                strSql = "SELECT ";
                                                strSql += "* ";
                                                strSql += "FROM ";
                                                strSql += "ORI_DOCUMENTOSEMITIDOS ";
                                                strSql += "WHERE ";
                                                strSql += "Uuid = '" + Elementos[0].ToString() + "'";

                                                cmdObj.CommandText = strSql;
                                                SqlDataReader rdrObj = cmdObj.ExecuteReader();
                                                if (rdrObj.HasRows == true)
                                                {
                                                    Faltantes faltantes = new Faltantes();
                                                    faltantes = new Faltantes();
                                                    faltantes.Tipo = "EMITIDO";
                                                    faltantes.Uudi = Elementos[0].ToString();
                                                    faltantes.RFCEmisor = Elementos[1].ToString();
                                                    faltantes.NombreEmisor = Elementos[2].ToString();
                                                    faltantes.RFCReceptor = Elementos[3].ToString();
                                                    faltantes.NombreReceptor = Elementos[4].ToString();
                                                    faltantes.RFCPac = Elementos[5].ToString();
                                                    faltantes.FechaEmision = Convert.ToDateTime(Elementos[6].ToString());
                                                    faltantes.FechaCer = Convert.ToDateTime(Elementos[7].ToString());
                                                    faltantes.Monto = Convert.ToDouble(Elementos[8].ToString());
                                                    faltantes.Efecto = Elementos[9].ToString();
                                                    faltantes.Estatus = Elementos[10].ToString();
                                                    if (Elementos[11].ToString() != "")
                                                    {
                                                        faltantes.FechaCancelacion = Convert.ToDateTime(Elementos[11].ToString());
                                                    }
                                                    listaFaltante.Add(faltantes);
                                                }
                                            }
                                            cnObj.Close();
                                        }
                                    }
                                    else
                                    {
                                        cnObj.Close();
                                    }

                                    lineaCompleta = true;
                                }
                                else
                                {
                                    lineaCompleta = false;
                                    lineaIncompleta = linea;
                                }
                                cuenta += 1;
                            }
                            else
                            {
                                cuenta += 1;
                            }
                        }
                        File.Delete(archivoEmitido);
                    }
                    //Directory.Delete(pathEmitidos,true);
                    CancelaDocumentos(listaFaltante, 0);
                }

                if (pathRecibidos.Length > 0)
                {
                    string[] archivosRecibidos = Directory.GetFiles(pathRecibidos, "*.txt", SearchOption.AllDirectories);
                    foreach (var archivoRecibido in archivosRecibidos)
                    {

                        string[] Lineas = System.IO.File.ReadAllLines(archivoRecibido);
                        string lineaIncompleta = null;
                        string lineaAux = null;

                        int cuenta = 0;
                        Boolean lineaCompleta = true;

                        Conexion conectar = new Conexion();

                        foreach (var linea in Lineas)
                        {
                            if (cuenta > 0)
                            {
                                if (lineaCompleta != true)
                                {
                                    lineaAux = lineaIncompleta + linea;
                                }
                                else
                                {
                                    lineaAux = linea;
                                }

                                string[] Elementos = lineaAux.Trim().Split('~');
                                int separadores = lineaAux.Split('~').Count();

                                if (separadores == 12)
                                {
                                    cnObj = conectar.Empresa(Elementos[3].ToString());
                                    if (Elementos[11].ToString() != "")
                                    {
                                        if (cnObj != null)
                                        {
                                            using (cnObj)
                                            {
                                                SqlCommand cmdObj = new SqlCommand();
                                                cmdObj.Connection = cnObj;
                                                cmdObj.CommandTimeout = 0;

                                                strSql = "SELECT ";
                                                strSql += "* ";
                                                strSql += "FROM ";
                                                strSql += "ORI_DOCUMENTOSRECIBIDOS ";
                                                strSql += "WHERE ";
                                                strSql += "Uuid = '" + Elementos[0].ToString() + "'";

                                                cmdObj.CommandText = strSql;
                                                SqlDataReader rdrObj = cmdObj.ExecuteReader();
                                                if (rdrObj.HasRows == true)
                                                {
                                                    Faltantes faltantes = new Faltantes();
                                                    faltantes = new Faltantes();
                                                    faltantes.Tipo = "EMITIDO";
                                                    faltantes.Uudi = Elementos[0].ToString();
                                                    faltantes.RFCEmisor = Elementos[1].ToString();
                                                    faltantes.NombreEmisor = Elementos[2].ToString();
                                                    faltantes.RFCReceptor = Elementos[3].ToString();
                                                    faltantes.NombreReceptor = Elementos[4].ToString();
                                                    faltantes.RFCPac = Elementos[5].ToString();
                                                    faltantes.FechaEmision = Convert.ToDateTime(Elementos[6].ToString());
                                                    faltantes.FechaCer = Convert.ToDateTime(Elementos[7].ToString());
                                                    faltantes.Monto = Convert.ToDouble(Elementos[8].ToString());
                                                    faltantes.Efecto = Elementos[9].ToString();
                                                    faltantes.Estatus = Elementos[10].ToString();
                                                    if (Elementos[11].ToString() != "")
                                                    {
                                                        faltantes.FechaCancelacion = Convert.ToDateTime(Elementos[11].ToString());
                                                    }
                                                    listaFaltante.Add(faltantes);
                                                }
                                            }
                                            cnObj.Close();
                                        }
                                    }
                                    else
                                    {
                                        cnObj.Close();
                                    }
                                    lineaCompleta = true;
                                }
                                else
                                {
                                    lineaCompleta = false;
                                    lineaIncompleta = linea;
                                }
                                cuenta += 1;
                            }
                            else
                            {
                                cuenta += 1;
                            }
                        }
                        File.Delete(archivoRecibido);
                    }
                    //Directory.Delete(pathRecibidos,true);
                    CancelaDocumentos(listaFaltante, 1);
                }
            }

            return listaFaltante;
        }

        private void CancelaDocumentos(List<Faltantes> Documentos, int tipo)
        {
            Conexion conectar = new Conexion();
            foreach (var documento in Documentos)
            {
                switch (tipo)
                {
                    case 0:

                        cnObj = conectar.Empresa(documento.RFCEmisor);
                        if(cnObj != null)
                        {
                            using (cnObj)
                            {
                                SqlCommand cmdObj = new SqlCommand();
                                cmdObj.Connection = cnObj;
                                cmdObj.CommandTimeout = 0;

                                strSql = "UPDATE ";
                                strSql += "ORI_DOCUMENTOSEMITIDOS ";
                                strSql += "SET ";
                                strSql += "VigenciaSat = 0, ";
                                strSql += "FechaCancelacion = '"+ documento.FechaCancelacion.ToString("yyyyMMdd") +"' ";
                                strSql += "WHERE ";
                                strSql += "Uuid = '" + documento.Uudi + "'";

                                cmdObj.CommandText = strSql;
                                try
                                {
                                    cmdObj.ExecuteNonQuery();
                                }catch(SqlException ex)
                                {

                                }

                                strSql = "DELETE ";
                                strSql += "FROM ";
                                strSql += "ORI_DOCUMENTOSFALTANTES ";
                                strSql += "WHERE ";
                                strSql += "Uuid = '" + documento.Uudi + "'";

                                cmdObj.CommandText = strSql;
                                try
                                {
                                    cmdObj.ExecuteNonQuery();
                                }catch(SqlException ex)
                                {

                                }

                                SqlConnection cnOtr = new SqlConnection();
                                cnOtr = conectar.Factreview();
                                if(cnOtr != null)
                                {
                                    using (cnOtr)
                                    {
                                        SqlCommand cmdOtr = new SqlCommand();
                                        cmdOtr.Connection = cnOtr;
                                        cmdOtr.CommandTimeout = 0;

                                        string strOtr;

                                        strOtr = "UPDATE ";
                                        strOtr += "EncabezadoVTA ";
                                        strOtr += "SET ";
                                        strOtr += "status = 1, ";
                                        strOtr += "fechaCancelacion = '" + documento.FechaCancelacion.ToString("yyyyMMdd") + "' ";
                                        strOtr += "WHERE ";
                                        strOtr += "uuid = '" + documento.Uudi + "'";

                                        cmdOtr.CommandText = strOtr;
                                        try
                                        {
                                            cmdOtr.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {

                                        }
                                    }
                                }
                            }
                        }

                        break;

                    case 1:

                        cnObj = conectar.Empresa(documento.RFCReceptor);
                        if(cnObj != null)
                        {
                            using (cnObj)
                            {
                                SqlCommand cmdObj = new SqlCommand();
                                cmdObj.Connection = cnObj;
                                cmdObj.CommandTimeout = 0;

                                strSql = "UPDATE ";
                                strSql += "ORI_DOCUMENTOSRECIBIDOS ";
                                strSql += "SET ";
                                strSql += "VigenciaSat = 0, ";
                                strSql += "FechaCancelacion = '" + documento.FechaCancelacion.ToString("yyyyMMdd") + "' ";
                                strSql += "WHERE ";
                                strSql += "Uuid = '" + documento.Uudi + "'";

                                cmdObj.CommandText = strSql;
                                try
                                {
                                    cmdObj.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {

                                }

                                strSql = "DELETE ";
                                strSql += "FROM ";
                                strSql += "ORI_DOCUMENTOSFALTANTES ";
                                strSql += "WHERE ";
                                strSql += "Uuid = '" + documento.Uudi + "'";

                                cmdObj.CommandText = strSql;
                                try
                                {
                                    cmdObj.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {

                                }

                                SqlConnection cnOtr = new SqlConnection();
                                cnOtr = conectar.Factreview();
                                if(cnOtr != null)
                                {
                                    using (cnOtr)
                                    {
                                        SqlCommand cmdOtr = new SqlCommand();
                                        cmdOtr.Connection = cnOtr;
                                        cmdOtr.CommandTimeout = 0;

                                        string strOtr;

                                        strOtr = "UPDATE ";
                                        strOtr += "Encabezado ";
                                        strOtr += "SET ";
                                        strOtr += "status = 1, ";
                                        strOtr += "fechaCancelacion = '" + documento.FechaCancelacion.ToString("yyyyMMdd") + "' ";
                                        strOtr += "WHERE ";
                                        strOtr += "uuid = '" + documento.Uudi + "'";

                                        cmdOtr.CommandText = strOtr;
                                        try
                                        {
                                            cmdOtr.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
