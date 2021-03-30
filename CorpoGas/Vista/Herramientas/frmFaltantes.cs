using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Herramientas
{
    public partial class frmFaltantes : Form
    {

        BindingSource dbFaltantes = new BindingSource();
        int origen = 0;

        public frmFaltantes(BindingSource _dbFaltantes, int _origen)
        {
            InitializeComponent();
            origen = _origen;
            dbFaltantes.DataSource = _dbFaltantes;
            fgFaltantes.DataSource = dbFaltantes;
            if(origen == 1)
            {
                fgFaltantes.Cols[10].Visible = false;
                fgFaltantes.Cols[11].Visible = false;
                fgFaltantes.Cols[12].Visible = false;
            }
            fgFaltantes.AutoSizeCols();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = @"C:\CorpoGas";
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                    ruta += "\\Reportes";
                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                }
                else
                {
                    ruta += "\\Reportes";
                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                }
                string archivo = "ReporteFaltantes_" + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + ".xls";
                fgFaltantes.SaveExcel(ruta + "\\" + archivo);
                MessageBox.Show("Reporte Generado", "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "EXCEL.EXE";
                startInfo.Arguments = ruta + "\\" + archivo;
                Process.Start(startInfo);
            }
            catch
            {
                MessageBox.Show("Error al Generar el Reporte", "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
