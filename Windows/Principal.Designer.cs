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
            this.introducirDatosManualmenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SimuladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(819, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(89)))));
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducirDatosManualmenteToolStripMenuItem,
            this.introducirDatosToolStripMenuItem,
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem,
            this.SimuladorToolStripMenuItem});
            this.opcionesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // introducirDatosManualmenteToolStripMenuItem
            // 
            this.introducirDatosManualmenteToolStripMenuItem.Name = "introducirDatosManualmenteToolStripMenuItem";
            this.introducirDatosManualmenteToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.introducirDatosManualmenteToolStripMenuItem.Text = "Introducir vuelos manualmente";
            this.introducirDatosManualmenteToolStripMenuItem.Click += new System.EventHandler(this.introducirDatosManualmenteToolStripMenuItem_Click);
            // 
            // introducirDatosToolStripMenuItem
            // 
            this.introducirDatosToolStripMenuItem.Name = "introducirDatosToolStripMenuItem";
            this.introducirDatosToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.introducirDatosToolStripMenuItem.Text = "Cargar vuelos desde fichero";
            this.introducirDatosToolStripMenuItem.Click += new System.EventHandler(this.introducirDatosToolStripMenuItem_Click);
            // 
            // distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Parámetros";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += new System.EventHandler(this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click);
            // 
            // SimuladorToolStripMenuItem
            // 
            this.SimuladorToolStripMenuItem.Name = "SimuladorToolStripMenuItem";
            this.SimuladorToolStripMenuItem.Size = new System.Drawing.Size(297, 26);
            this.SimuladorToolStripMenuItem.Text = "Simulador";
            this.SimuladorToolStripMenuItem.Click += new System.EventHandler(this.SimuladorToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(89)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(255, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "DECONFLICTING TOOL";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(819, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deconflicting Tool - Menú Principal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Principal_Paint);
            this.Resize += new System.EventHandler(this.Principal_Resize);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosManualmenteToolStripMenuItem;
    }
}

