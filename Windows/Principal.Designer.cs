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
            this.tableLayoutTutorial = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTutorialLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxTutorialRight = new System.Windows.Forms.PictureBox();
            this.Label_Tutorial = new System.Windows.Forms.Label();
            this.Label_Subtitulo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutTutorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTutorialLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTutorialRight)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1060, 24);
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
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // introducirDatosManualmenteToolStripMenuItem
            // 
            this.introducirDatosManualmenteToolStripMenuItem.Name = "introducirDatosManualmenteToolStripMenuItem";
            this.introducirDatosManualmenteToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.introducirDatosManualmenteToolStripMenuItem.Text = "Introducir vuelos manualmente";
            this.introducirDatosManualmenteToolStripMenuItem.Click += new System.EventHandler(this.introducirDatosManualmenteToolStripMenuItem_Click);
            // 
            // introducirDatosToolStripMenuItem
            // 
            this.introducirDatosToolStripMenuItem.Name = "introducirDatosToolStripMenuItem";
            this.introducirDatosToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.introducirDatosToolStripMenuItem.Text = "Cargar vuelos desde fichero";
            this.introducirDatosToolStripMenuItem.Click += new System.EventHandler(this.introducirDatosToolStripMenuItem_Click);
            // 
            // distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Parámetros";
            this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += new System.EventHandler(this.distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click);
            // 
            // SimuladorToolStripMenuItem
            // 
            this.SimuladorToolStripMenuItem.Name = "SimuladorToolStripMenuItem";
            this.SimuladorToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.SimuladorToolStripMenuItem.Text = "Simulador";
            this.SimuladorToolStripMenuItem.Click += new System.EventHandler(this.SimuladorToolStripMenuItem_Click);
            // 
            // tableLayoutTutorial
            // 
            this.tableLayoutTutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutTutorial.ColumnCount = 2;
            this.tableLayoutTutorial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.83019F));
            this.tableLayoutTutorial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.16982F));
            this.tableLayoutTutorial.Controls.Add(this.pictureBoxTutorialLeft, 0, 0);
            this.tableLayoutTutorial.Controls.Add(this.pictureBoxTutorialRight, 1, 0);
            this.tableLayoutTutorial.Location = new System.Drawing.Point(0, 89);
            this.tableLayoutTutorial.Name = "tableLayoutTutorial";
            this.tableLayoutTutorial.RowCount = 1;
            this.tableLayoutTutorial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTutorial.Size = new System.Drawing.Size(1060, 425);
            this.tableLayoutTutorial.TabIndex = 2;
            // 
            // pictureBoxTutorialLeft
            // 
            this.pictureBoxTutorialLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTutorialLeft.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxTutorialLeft.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxTutorialLeft.Name = "pictureBoxTutorialLeft";
            this.pictureBoxTutorialLeft.Size = new System.Drawing.Size(338, 415);
            this.pictureBoxTutorialLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTutorialLeft.TabIndex = 0;
            this.pictureBoxTutorialLeft.TabStop = false;
            // 
            // pictureBoxTutorialRight
            // 
            this.pictureBoxTutorialRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTutorialRight.Location = new System.Drawing.Point(353, 5);
            this.pictureBoxTutorialRight.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxTutorialRight.Name = "pictureBoxTutorialRight";
            this.pictureBoxTutorialRight.Size = new System.Drawing.Size(702, 415);
            this.pictureBoxTutorialRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTutorialRight.TabIndex = 1;
            this.pictureBoxTutorialRight.TabStop = false;
            // 
            // Label_Tutorial
            // 
            this.Label_Tutorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Tutorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(89)))));
            this.Label_Tutorial.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.Label_Tutorial.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Tutorial.Location = new System.Drawing.Point(0, 24);
            this.Label_Tutorial.Name = "Label_Tutorial";
            this.Label_Tutorial.Size = new System.Drawing.Size(1060, 37);
            this.Label_Tutorial.TabIndex = 4;
            this.Label_Tutorial.Text = "Deconflicting Tool";
            this.Label_Tutorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Subtitulo
            // 
            this.Label_Subtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Subtitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(44)))), ((int)(((byte)(89)))));
            this.Label_Subtitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.Label_Subtitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Subtitulo.Location = new System.Drawing.Point(0, 61);
            this.Label_Subtitulo.Name = "Label_Subtitulo";
            this.Label_Subtitulo.Size = new System.Drawing.Size(1060, 28);
            this.Label_Subtitulo.TabIndex = 5;
            this.Label_Subtitulo.Text = "Tutorial";
            this.Label_Subtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1060, 514);
            this.Controls.Add(this.Label_Subtitulo);
            this.Controls.Add(this.Label_Tutorial);
            this.Controls.Add(this.tableLayoutTutorial);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deconflicting Tool - Menú Principal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Principal_Paint);
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutTutorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTutorialLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTutorialRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SimuladorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirDatosManualmenteToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTutorial;
        private System.Windows.Forms.PictureBox pictureBoxTutorialLeft;
        private System.Windows.Forms.PictureBox pictureBoxTutorialRight;
        private System.Windows.Forms.Label Label_Tutorial;
        private System.Windows.Forms.Label Label_Subtitulo;
    }
}

