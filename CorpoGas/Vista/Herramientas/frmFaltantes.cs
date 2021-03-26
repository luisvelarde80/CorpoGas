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
    }
}
