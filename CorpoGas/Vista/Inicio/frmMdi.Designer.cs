namespace Vista
{
    partial class frmMdi
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHsolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHSmetadatos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHScfdi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHfacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHFcomparativoMeta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHerramientas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiHerramientas
            // 
            this.tsmiHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHsolicitudes,
            this.tsmiHfacturacion});
            this.tsmiHerramientas.Name = "tsmiHerramientas";
            this.tsmiHerramientas.Size = new System.Drawing.Size(90, 20);
            this.tsmiHerramientas.Text = "Herramientas";
            // 
            // tsmiHsolicitudes
            // 
            this.tsmiHsolicitudes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHSmetadatos,
            this.tsmiHScfdi});
            this.tsmiHsolicitudes.Name = "tsmiHsolicitudes";
            this.tsmiHsolicitudes.Size = new System.Drawing.Size(180, 22);
            this.tsmiHsolicitudes.Text = "Solicitudes";
            // 
            // tsmiHSmetadatos
            // 
            this.tsmiHSmetadatos.Name = "tsmiHSmetadatos";
            this.tsmiHSmetadatos.Size = new System.Drawing.Size(180, 22);
            this.tsmiHSmetadatos.Text = "Metadatos";
            this.tsmiHSmetadatos.Click += new System.EventHandler(this.TsmiHSmetadatos_Click);
            // 
            // tsmiHScfdi
            // 
            this.tsmiHScfdi.Name = "tsmiHScfdi";
            this.tsmiHScfdi.Size = new System.Drawing.Size(180, 22);
            this.tsmiHScfdi.Text = "Cfdi";
            // 
            // tsmiHfacturacion
            // 
            this.tsmiHfacturacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHFcomparativoMeta});
            this.tsmiHfacturacion.Name = "tsmiHfacturacion";
            this.tsmiHfacturacion.Size = new System.Drawing.Size(180, 22);
            this.tsmiHfacturacion.Text = "Facturación";
            // 
            // tsmiHFcomparativoMeta
            // 
            this.tsmiHFcomparativoMeta.Name = "tsmiHFcomparativoMeta";
            this.tsmiHFcomparativoMeta.Size = new System.Drawing.Size(211, 22);
            this.tsmiHFcomparativoMeta.Text = "Comparativo vs Metadato";
            // 
            // frmMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corpoga";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiHerramientas;
        private System.Windows.Forms.ToolStripMenuItem tsmiHsolicitudes;
        private System.Windows.Forms.ToolStripMenuItem tsmiHSmetadatos;
        private System.Windows.Forms.ToolStripMenuItem tsmiHScfdi;
        private System.Windows.Forms.ToolStripMenuItem tsmiHfacturacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiHFcomparativoMeta;
    }
}

