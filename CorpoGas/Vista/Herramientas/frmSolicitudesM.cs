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

        #region "Constructor"

        public frmSolicitudesM()
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
                if(fgSolicitudes.Rows.Count > 1)
                {
                    btnFaltantes.Enabled = true;
                    btnCancelados.Enabled = true;
                }
            }
        }

        private void BtnFaltantes_Click(object sender, EventArgs e)
        {
            if (!bgwFaltantes.IsBusy)
            {
                lblProcesando.Visible = true;
                pbProcesando.Visible = true;
                Inhabilita();
                bgwFaltantes.RunWorkerAsync();
            }
        }

        private void BtnCancelados_Click(object sender, EventArgs e)
        {
            if (!bgwCancelados.IsBusy)
            {
                lblProcesando.Visible = true;
                pbProcesando.Visible = true;
                Inhabilita();
                bgwCancelados.RunWorkerAsync();
            }
        }

        private void BgwFaltantes_DoWork(object sender, DoWorkEventArgs e)
        {
            Faltantes();
        }

        private void BgwFaltantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProcesando.Visible = false;
            pbProcesando.Visible = false;
            MessageBox.Show("Proceso Completado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmFaltantes frmfaltantes = new frmFaltantes(dbFaltantes, 1);
            frmfaltantes.ShowDialog();
            Habilita();
        }

        private void BgwCancelados_DoWork(object sender, DoWorkEventArgs e)
        {
            Cancelados();
        }

        private void BgwCancelados_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProcesando.Visible = false;
            pbProcesando.Visible = false;
            MessageBox.Show("Proceso Completado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmFaltantes frmfaltantes = new frmFaltantes(dbFaltantes, 0);
            frmfaltantes.ShowDialog();
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

            if(chbEmpresa.CheckState == CheckState.Checked)
            {
                if (chbTipo.CheckState == CheckState.Checked)
                {
                    if (cmbTipo.Text == "Emitidos")
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 0);
                    }
                    else
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 1);
                    }
                }
                else
                {
                    dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"));
                }
            }
            else
            {
                if (chbTipo.CheckState == CheckState.Checked)
                {
                    if (cmbTipo.Text == "Emitidos")
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 0);
                    }
                    else
                    {
                        dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 1);
                    }
                }
                else
                {
                    dbSolicitudes.DataSource = objSolicitudes.solicitudesMetadatos(dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"));
                }
            }
            
            fgSolicitudes.DataSource = dbSolicitudes;
            fgSolicitudes.Cols[0].Visible = false;
            fgSolicitudes.AutoSizeCols();
        }

        private void Faltantes()
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
                
                dbFaltantes.DataSource = objArchivo.Metadato(dtSolicitudes,1);
            }
        }

        private void Cancelados()
        {
            if (fgSolicitudes.Rows.Count > 1)
            {
                for (int i = 1; i < fgSolicitudes.Rows.Count; i++)
                {
                    DataRow row = dtSolicitudes.NewRow();

                    row[0] = fgSolicitudes.GetData(i, 0).ToString();
                    row[1] = Guid.Parse(fgSolicitudes.GetData(i, 1).ToString());
                    row[2] = Convert.ToInt32(fgSolicitudes.GetData(i, 9));

                    dtSolicitudes.Rows.Add(row);
                }

                dbFaltantes.DataSource = objArchivo.Metadato(dtSolicitudes,2);
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
            btnFaltantes.Enabled = false;
            btnCancelados.Enabled = false;
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
            btnFaltantes.Enabled = true;
            btnCancelados.Enabled = true;
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
