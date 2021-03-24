using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Vista.Herramientas
{
    public partial class frmSolicitudesM : Form
    {

        #region "Variables"

        Empresas_Ctl objEmpresa = new Empresas_Ctl();

        #endregion

        public frmSolicitudesM()
        {
            InitializeComponent();
        }

        private void Empresas()
        {
            BindingSource dbEmpresa = new BindingSource();
            dbEmpresa.DataSource = objEmpresa.empresas();
            cmbEmpresa.DataSource = dbEmpresa;

            cmbEmpresa.DisplayMember = "RazonSocial";
            cmbEmpresa.ValueMember = "Rfc";
        }

    }
}
