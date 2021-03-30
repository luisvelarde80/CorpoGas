﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Crud;
using System.Data;
using System.IO;

namespace Controlador
{
    public class Archivos_Ctl
    {

        #region "Variables"

        Archivos objArchivos = new Archivos();

        #endregion

        public List<Faltantes> Metadato(DataTable dtSolicitudes,int tipo)
        {
            List<Faltantes> Faltantes = new List<Faltantes>();

            foreach (DataRow row in dtSolicitudes.Rows)
            {
                objArchivos.Metadato(row[0].ToString(), Guid.Parse(row[1].ToString()), Convert.ToInt32(row[2].ToString()));
            }

            Faltantes = objArchivos.ProcesaArchivo(tipo);
            objArchivos.EliminaDirectorios();

            return Faltantes;
        }

        public List<Faltantes> Cancelados(DataTable dtSolicitudes, int tipo)
        {
            List<Faltantes> cancelados = new List<Faltantes>();

            foreach (DataRow row in dtSolicitudes.Rows)
            {
                objArchivos.Metadato(row[0].ToString(), Guid.Parse(row[1].ToString()), Convert.ToInt32(row[2].ToString()));
            }

            cancelados = objArchivos.ProcesaArchivo(tipo);
            objArchivos.EliminaDirectorios();
            return cancelados;
        }

    }
}
