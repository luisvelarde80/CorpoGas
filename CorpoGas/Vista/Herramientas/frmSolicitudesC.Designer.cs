namespace Vista.Herramientas
{
    partial class frmSolicitudesC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbProcesando = new System.Windows.Forms.PictureBox();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.chbTipo = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.chbEmpresa = new System.Windows.Forms.CheckBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaIni = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fgSolicitudes = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.bgwDescargar = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcesando)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbProcesando);
            this.groupBox1.Controls.Add(this.lblProcesando);
            this.groupBox1.Controls.Add(this.btnDescargar);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.lblTipo);
            this.groupBox1.Controls.Add(this.chbTipo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.chbEmpresa);
            this.groupBox1.Controls.Add(this.cmbEmpresa);
            this.groupBox1.Controls.Add(this.lblEmpresa);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaIni);
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Controls.Add(this.lblFechaIni);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametros";
            // 
            // pbProcesando
            // 
            this.pbProcesando.Image = global::Vista.Properties.Resources.loaderUpdate_2;
            this.pbProcesando.Location = new System.Drawing.Point(462, 16);
            this.pbProcesando.Name = "pbProcesando";
            this.pbProcesando.Size = new System.Drawing.Size(42, 29);
            this.pbProcesando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProcesando.TabIndex = 13;
            this.pbProcesando.TabStop = false;
            this.pbProcesando.Visible = false;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.Location = new System.Drawing.Point(395, 23);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(64, 13);
            this.lblProcesando.TabIndex = 12;
            this.lblProcesando.Text = "Procesando";
            this.lblProcesando.Visible = false;
            // 
            // btnDescargar
            // 
            this.btnDescargar.Enabled = false;
            this.btnDescargar.Location = new System.Drawing.Point(435, 103);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(72, 23);
            this.btnDescargar.TabIndex = 11;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.BtnDescargar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Emitidos",
            "Recibidos"});
            this.cmbTipo.Location = new System.Drawing.Point(118, 105);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(125, 21);
            this.cmbTipo.TabIndex = 10;
            this.cmbTipo.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(81, 108);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 9;
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Visible = false;
            // 
            // chbTipo
            // 
            this.chbTipo.AutoSize = true;
            this.chbTipo.Location = new System.Drawing.Point(12, 109);
            this.chbTipo.Name = "chbTipo";
            this.chbTipo.Size = new System.Drawing.Size(47, 17);
            this.chbTipo.TabIndex = 8;
            this.chbTipo.Text = "Tipo";
            this.chbTipo.UseVisualStyleBackColor = true;
            this.chbTipo.CheckedChanged += new System.EventHandler(this.ChbTipo_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(354, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // chbEmpresa
            // 
            this.chbEmpresa.AutoSize = true;
            this.chbEmpresa.Location = new System.Drawing.Point(12, 78);
            this.chbEmpresa.Name = "chbEmpresa";
            this.chbEmpresa.Size = new System.Drawing.Size(67, 17);
            this.chbEmpresa.TabIndex = 6;
            this.chbEmpresa.Text = "Empresa";
            this.chbEmpresa.UseVisualStyleBackColor = true;
            this.chbEmpresa.CheckedChanged += new System.EventHandler(this.ChbEmpresa_CheckedChanged);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(142, 76);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(365, 21);
            this.cmbEmpresa.TabIndex = 5;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(85, 79);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(84, 49);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(110, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(84, 23);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(110, 20);
            this.dtpFechaIni.TabIndex = 2;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(9, 52);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(65, 13);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Fecha Final:";
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Location = new System.Drawing.Point(9, 26);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(70, 13);
            this.lblFechaIni.TabIndex = 0;
            this.lblFechaIni.Text = "Fecha Inicial:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fgSolicitudes);
            this.panel1.Location = new System.Drawing.Point(2, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 179);
            this.panel1.TabIndex = 2;
            // 
            // fgSolicitudes
            // 
            this.fgSolicitudes.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgSolicitudes.AllowEditing = false;
            this.fgSolicitudes.ColumnInfo = "10,0,0,0,0,95,Columns:";
            this.fgSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgSolicitudes.Location = new System.Drawing.Point(0, 0);
            this.fgSolicitudes.Name = "fgSolicitudes";
            this.fgSolicitudes.Rows.DefaultSize = 19;
            this.fgSolicitudes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgSolicitudes.Size = new System.Drawing.Size(516, 179);
            this.fgSolicitudes.TabIndex = 0;
            // 
            // bgwDescargar
            // 
            this.bgwDescargar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwDescargar_DoWork);
            this.bgwDescargar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwDescargar_RunWorkerCompleted);
            // 
            // frmSolicitudesC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmSolicitudesC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitudes Cfdi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcesando)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbProcesando;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.CheckBox chbTipo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chbEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaIni;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgSolicitudes;
        private System.ComponentModel.BackgroundWorker bgwDescargar;
    }
}