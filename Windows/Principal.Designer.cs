namespace Windows
{
    partial class Principal
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
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimuladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducirDatosToolStripMenuItem,
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem,
            this.SimuladorToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            this.opcionesToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // introducirDatosToolStripMenuItem
            // 
            this.introducirDatosToolStripMenuItem.Name = "introducirDatosToolStripMenuItem";
            this.introducirDatosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.introducirDatosToolStripMenuItem.Text = "Introducir datos";
            this.introducirDatosToolStripMenuItem.Click += new System.EventHandler(this.introducirDatosToolStripMenuItem_Click);
            // 
            // distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Parámetros";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += new System.EventHandler(this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click);
            // 
            // SimuladorToolStripMenuItem
            // 
            this.SimuladorToolStripMenuItem.Name = "SimuladorToolStripMenuItem";
            this.SimuladorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.SimuladorToolStripMenuItem.Text = "Simulador";
            this.SimuladorToolStripMenuItem.Click += new System.EventHandler(this.SimuladorToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(818, 427);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimuladorToolStripMenuItem;
    }
}

