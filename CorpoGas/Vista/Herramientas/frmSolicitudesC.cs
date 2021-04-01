using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Herramientas
{
    public partial class frmSolicitudesC : Form
    {
        
        #region "Constructor"

        public frmSolicitudesC()
        {
            InitializeComponent();
            Empresas();
            chbEmpresa.Checked = true;

            dtSolicitudes.Columns.Add("rfc");
            dtSolicitudes.Columns.Add("id");
            dtSolicitudes.Columns.Add("direccion");
        }

        #endregion

        #region "Formulario"

        private void ChbEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEmpresa.CheckState == CheckState.Checked)
            {
                lblEmpresa.Visible = true;
                cmbEmpresa.Visible = true;
            }
            else
            {
                lblEmpresa.Visible = false;
                cmbEmpresa.Visible = false;
            }
        }

        private void ChbTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTipo.CheckState == CheckState.Checked)
            {
                lblTipo.Visible = true;
                cmbTipo.Visible = true;
            }
            else
            {
                lblTipo.Visible = false;
                cmbTipo.Visible = false;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value >= dtpFechaIni.Value)
            {
                BuscaSolicitudes();
                if (fgSolicitudes.Rows.Count > 1)
                {
                    btnDescargar.Enabled = true;
                }
            }
        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {
            if (!bgwDescargar.IsBusy)
            {
                lblProcesando.Visible = true;
                pbProcesando.Visible = true;
                Inhabilita();
                bgwDescargar.RunWorkerAsync();
            }
        }

        private void BgwDescargar_DoWork(object sender, DoWorkEventArgs e)
        {
            Descargar();
        }

        private void BgwDescargar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProcesando.Visible = false;
            pbProcesando.Visible = false;
            MessageBox.Show("Proceso Completado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtSolicitudes.Rows.Clear();
            Habilita();
        }

        #endregion

        #region "Funciones"

        private void Empresas()
        {
            BindingSource dbEmpresa = new BindingSource();
            dbEmpresa.DataSource = objEmpresa.empresas();
            cmbEmpresa.DataSource = dbEmpresa;

            cmbEmpresa.DisplayMember = "RazonSocial";
            cmbEmpresa.ValueMember = "Rfc";
        }

        private void BuscaSolicitudes()
        {
            BindingSource dbSolicitudes = new BindingSource();

            if (chbEmpresa.CheckState == CheckState.Checked)
            {
                if (chbTipo.CheckState == CheckState.Checked)
                {
                    if (cmbTipo.Text == "Emitidos")
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 0);
                    }
                    else
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 1);
                    }
                }
                else
                {
                    dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"));
                }
            }
            else
            {
                if (chbTipo.CheckState == CheckState.Checked)
                {
                    if (cmbTipo.Text == "Emitidos")
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 0);
                    }
                    else
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 1);
                    }
                }
                else
                {
                    dbSolicitudes.DataSource = objSolicitudes.solicitudesCfdi(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"));
                }
            }

            fgSolicitudes.DataSource = dbSolicitudes;
            fgSolicitudes.Cols[0].Visible = false;
            fgSolicitudes.AutoSizeCols();
        }

        private void Descargar()
        {
            if(fgSolicitudes.Rows.Count > 1)
            {
                for (int i = 1; i < fgSolicitudes.Rows.Count; i++)
                {
                    DataRow row = dtSolicitudes.NewRow();

                    row[0] = fgSolicitudes.GetData(i, 0).ToString();
                    row[1] = Guid.Parse(fgSolicitudes.GetData(i, 1).ToString());
                    row[2] = Convert.ToInt32(fgSolicitudes.GetData(i, 9));

                    dtSolicitudes.Rows.Add(row);
                }

                objArchivo.Cfdi(dtSolicitudes, 1);
            }
        }

        private void Inhabilita()
        {
            dtpFechaIni.Enabled = false;
            dtpFechaFin.Enabled = false;
            chbEmpresa.Enabled = false;
            cmbEmpresa.Enabled = false;
            chbTipo.Enabled = false;
            cmbTipo.Enabled = false;
            btnBuscar.Enabled = false;
            btnDescargar.Enabled = false;
        }

        private void Habilita()
        {
            dtpFechaIni.Enabled = true;
            dtpFechaFin.Enabled = true;
            chbEmpresa.Enabled = true;
            cmbEmpresa.Enabled = true;
            chbTipo.Enabled = true;
            cmbTipo.Enabled = true;
            btnBuscar.Enabled = true;
            btnDescargar.Enabled = true;
        }

        #endregion

        #region "Variables"

        Empresas_Ctl objEmpresa = new Empresas_Ctl();
        Solicitudes_Ctl objSolicitudes = new Solicitudes_Ctl();
        Archivos_Ctl objArchivo = new Archivos_Ctl();
        DataTable dtSolicitudes = new DataTable();
        BindingSource dbFaltantes = new BindingSource();



        #endregion


    }
}
