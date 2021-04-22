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
using Vista.Herramientas;

namespace Vista.Facturacion
{
    public partial class frmComparativoM : Form
    {
        public frmComparativoM()
        {
            InitializeComponent();
        }

        #region "Formulario"

        private void BtnArchivo_Click(object sender, EventArgs e)
        {
            ofdArchivo.FileName = string.Empty;
            ofdArchivo.Filter = "txt files (*.txt)|*.txt";
            ofdArchivo.InitialDirectory = @"C:\";

            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                txtArchivo.Text = ofdArchivo.FileName;
                btnComparar.Enabled = true;
            }
        }

        private void BtnComparar_Click(object sender, EventArgs e)
        {
            //direccion- 0 = Emitidos, 1 = Recibidos
            //tipo 1 = Metadatos, 2 = Cancelados
            if (txtArchivo.TextLength > 0)
            {
                if (cmbTipo.Text != "")
                {
                    if (!bgwCompara.IsBusy)
                    {
                        bgwCompara.RunWorkerAsync();
                    }
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar el tipo", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar el archivo", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnArchivo.Focus();
            }
        }

        private void BgwCompara_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Compara();
        }

        #endregion

        #region "Funciones"

        private void Compara()
        {
            Archivos_Ctl objArchivo = new Archivos_Ctl();
            switch (cmbTipo.Text)
            {
                case "Emitido":
                    dbFaltantes.DataSource = objArchivo.ProcesaArchivo(txtArchivo.Text, 0);
                    break;

                case "Recibido":
                    dbFaltantes.DataSource = objArchivo.ProcesaArchivo(txtArchivo.Text, 1);
                    break;
            }
            frmFaltantes frmfaltantes = new frmFaltantes(dbFaltantes, 1);
            frmfaltantes.ShowDialog();
        }

        private void Inhabilita()
        {
            cmbTipo.Enabled = false;
            btnArchivo.Enabled = false;
            btnComparar.Enabled = false;
        }

        private void Habilita()
        {
            cmbTipo.Enabled = true;
            btnArchivo.Enabled = true;
            btnComparar.Enabled = true;
        }

        #endregion

        #region "Variables"

        Empresas_Ctl objEmpresa = new Empresas_Ctl();
        Archivos_Ctl objArchivo = new Archivos_Ctl();
        BindingSource dbFaltantes = new BindingSource();

        #endregion

    }

}
