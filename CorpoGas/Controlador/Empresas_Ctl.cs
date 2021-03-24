using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Crud;
using Modelo;

namespace Controlador
{
    public class Empresas_Ctl
    {

        #region "Variables"

        Empresas objEmpresas = new Empresas();

        #endregion

        public List<Empresa> empresas()
        {
            return objEmpresas.empresas();
        }

    }
}
