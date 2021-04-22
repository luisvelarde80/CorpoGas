using Controlador;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Facturacion
{
    public partial class frmDescargaXml : Form
    {

        #region "Constructor"

        public frmDescargaXml()
        {
            InitializeComponent();
            Empresas();
            CheckForIllegalCrossThreadCalls = false;
            dtUuid.Columns.Add("Uuid");
        }

        #endregion

        #region "Formulario"

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscaCfdi();
        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {
            if (!bgwDescargar.IsBusy)
            {
                bgwDescargar.RunWorkerAsync();
                Inhabilita();
                lblProcesando.Visible = true;
                pbProcesando.Visible = true;
            }
        }

        private void RdbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFecha.Checked == true)
            {
                lblFechaIni.Visible = true;
                dtpFechaIni.Visible = true;
                lblFechaFin.Visible = true;
                dtpFechaFin.Visible = true;

                lblUuid.Visible = false;
                txtUuid.Visible = false;
            }
            else
            {
                lblFechaIni.Visible = false;
                dtpFechaIni.Visible = false;
                lblFechaFin.Visible = false;
                dtpFechaFin.Visible = false;

                lblUuid.Visible = true;
                txtUuid.Visible = true;
            }
        }

        private void RdbUuid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUuid.Checked == true)
            {
                lblFechaIni.Visible = false;
                dtpFechaIni.Visible = false;
                lblFechaFin.Visible = false;
                dtpFechaFin.Visible = false;

                lblUuid.Visible = true;
                txtUuid.Visible = true;
                btnCargar.Visible = true;
            }
            else
            {
                lblFechaIni.Visible = true;
                dtpFechaIni.Visible = true;
                lblFechaFin.Visible = true;
                dtpFechaFin.Visible = true;

                lblUuid.Visible = false;
                txtUuid.Visible = false;
                btnCargar.Visible = false;
            }
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            ofdCargar.InitialDirectory = @"C:\";
            ofdCargar.Filter = "xml files (*.xml)|*.xml|xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            ofdCargar.CheckFileExists = true;
            ofdCargar.CheckPathExists = true;
            if (ofdCargar.ShowDialog() == DialogResult.OK)
            {
                pathRuta = ofdCargar.FileName;
                using (var stream = File.Open(pathRuta, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                DataRow row = dtUuid.NewRow();
                                dtUuid.Rows.Add(reader.GetString(0));
                            }
                        } while (reader.NextResult());
                        MessageBox.Show("Datos Cargados con Éxito", "EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUuid.ReadOnly = true;
                    }
                }
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
            Habilita();
            dtUuid.Rows.Clear();
            txtUuid.ReadOnly = false;
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

        private void BuscaCfdi()
        {
            BindingSource dbSolicitudes = new BindingSource();

            if(rdbFecha.Checked == true)
            {
                if (cmbTipo.Text != "")
                {
                    if (cmbTipo.Text == "Emitidos")
                    {
                        dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 0);
                    }
                    else
                    {
                        dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), dtpFechaIni.Value.ToString("yyyyMMdd"), dtpFechaFin.Value.ToString("yyyyMMdd"), 1);
                    }
                }
            }
            else
            {
                if(dtUuid.Rows.Count > 0)
                {
                    if (cmbTipo.Text != "")
                    {
                        if (cmbTipo.Text == "Emitidos")
                        {
                            dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), dtUuid, 0);
                        }
                        else
                        {
                            dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), dtUuid, 1);
                        }
                    } 
                }
                else
                {
                    if (cmbTipo.Text != "")
                    {
                        if (cmbTipo.Text == "Emitidos")
                        {
                            dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), txtUuid.Text, 0);
                        }
                        else
                        {
                            dbSolicitudes.DataSource = objSolicitudes.Solicitudesxml(cmbEmpresa.SelectedValue.ToString(), txtUuid.Text, 1);
                        }
                    }
                }  
            }

            fgSolicitudes.DataSource = dbSolicitudes;
            fgSolicitudes.AutoSizeCols();

            lblTotal.Visible = true;
            lblTotales.Visible = true;
            lblTotales.Text = Convert.ToString(dbSolicitudes.Count);
            btnDescargar.Enabled = true;
        }

        private void Descargar()
        {
            if (fgSolicitudes.Rows.Count > 1)
            {
                for (int i = 1; i < fgSolicitudes.Rows.Count; i++)
                {
                    if (objArchivo.Xml(cmbEmpresa.SelectedValue.ToString(), fgSolicitudes.GetData(i, 0).ToString()) == true)
                    {
                        fgSolicitudes.SetData(i, 5, "Descargado");
                    }
                    else
                    {
                        fgSolicitudes.SetData(i, 5, "No Descargado");
                    }
                }
            }
        }

        private void Inhabilita()
        {
            dtpFechaIni.Enabled = false;
            dtpFechaFin.Enabled = false;
            cmbEmpresa.Enabled = false;
            cmbTipo.Enabled = false;
            btnBuscar.Enabled = false;
            btnDescargar.Enabled = false;
        }

        private void Habilita()
        {
            dtpFechaIni.Enabled = true;
            dtpFechaFin.Enabled = true;
            cmbEmpresa.Enabled = true;
            cmbTipo.Enabled = true;
            btnBuscar.Enabled = true;
            btnDescargar.Enabled = true;
        }

        #endregion

        #region "Variables"

        Empresas_Ctl objEmpresa = new Empresas_Ctl();
        Solicitudes_Ctl objSolicitudes = new Solicitudes_Ctl();
        Archivos_Ctl objArchivo = new Archivos_Ctl();
        DataTable dtUuid = new DataTable();
        string pathRuta;

        #endregion

    }
}
