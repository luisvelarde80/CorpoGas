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

namespace Vista
{
    public partial class frmMdi : Form
    {
        public frmMdi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        #region "Herramientas"

        private void TsmiHSmetadatos_Click(object sender, EventArgs e)
        {
            frmSolicitudesM frmsolicitudes = new frmSolicitudesM();
            frmsolicitudes.MdiParent = this;
            frmsolicitudes.Show();
        }

        #endregion

    }
}
