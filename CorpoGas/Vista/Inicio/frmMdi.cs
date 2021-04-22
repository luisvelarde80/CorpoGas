using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Herramientas;
using Vista.Facturacion;

namespace Vista
{
    public partial class frmMdi : Form
    {

        #region "Constructor"

        public frmMdi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region "Herramientas"

        private void TsmiHSmetadatos_Click(object sender, EventArgs e)
        {
            frmSolicitudesM frmsolicitudes = new frmSolicitudesM
            {
                MdiParent = this
            };
            frmsolicitudes.Show();
        }

        private void TsmiHScfdi_Click(object sender, EventArgs e)
        {

            frmSolicitudesC frmsolicitudesC = new frmSolicitudesC
            {
                MdiParent = this
            };
            frmsolicitudesC.Show();

        }

        #endregion

        #region "Facturacion"

        private void TsmiHFcomparativoMeta_Click(object sender, EventArgs e)
        {
            frmComparativoM frmcomparativoM = new frmComparativoM
            {
                MdiParent = this
            };
            frmcomparativoM.Show();
        }

        private void TsmiFacDescargaXml_Click(object sender, EventArgs e)
        {
            frmDescargaXml frmdescargaxml = new frmDescargaXml
            {
                MdiParent = this
            };
            frmdescargaxml.Show();
        }

        #endregion

    }

}
