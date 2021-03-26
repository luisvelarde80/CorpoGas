namespace Vista.Herramientas
{
    partial class frmFaltantes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.fgFaltantes = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgFaltantes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fgFaltantes);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 211);
            this.panel1.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::Vista.Properties.Resources.silverexcel;
            this.btnExportar.Location = new System.Drawing.Point(556, 216);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(42, 35);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // fgFaltantes
            // 
            this.fgFaltantes.ColumnInfo = "10,0,0,0,0,95,Columns:0{Width:25;}\t";
            this.fgFaltantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgFaltantes.Location = new System.Drawing.Point(0, 0);
            this.fgFaltantes.Name = "fgFaltantes";
            this.fgFaltantes.Rows.DefaultSize = 19;
            this.fgFaltantes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.fgFaltantes.Size = new System.Drawing.Size(610, 211);
            this.fgFaltantes.TabIndex = 0;
            // 
            // frmFaltantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 256);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmFaltantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faltantes";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgFaltantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportar;
        private C1.Win.C1FlexGrid.C1FlexGrid fgFaltantes;
    }
}