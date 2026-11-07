namespace Windows
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_espacioAereo = new System.Windows.Forms.PictureBox();
            this.label_info = new System.Windows.Forms.Label();
            this.Conflictolabel = new System.Windows.Forms.Label();
            this.button_mover = new System.Windows.Forms.Button();
            this.button_automático = new System.Windows.Forms.Button();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.button_conflicto = new System.Windows.Forms.Button();
            this.button_datos = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_estadoActual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_espacioAereo
            // 
            this.pictureBox_espacioAereo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_espacioAereo.BackColor = System.Drawing.Color.MidnightBlue;
            this.pictureBox_espacioAereo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_espacioAereo.Location = new System.Drawing.Point(20, 60);
            this.pictureBox_espacioAereo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_espacioAereo.Name = "pictureBox_espacioAereo";
            this.pictureBox_espacioAereo.Size = new System.Drawing.Size(650, 566);
            this.pictureBox_espacioAereo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_espacioAereo.TabIndex = 0;
            this.pictureBox_espacioAereo.TabStop = false;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_info.Location = new System.Drawing.Point(25, 56);
            this.label_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(37, 15);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label1";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Conflictolabel
            // 
            this.Conflictolabel.AutoSize = true;
            this.Conflictolabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.Location = new System.Drawing.Point(22, 21);
            this.Conflictolabel.Name = "Conflictolabel";
            this.Conflictolabel.Size = new System.Drawing.Size(46, 13);
            this.Conflictolabel.TabIndex = 3;
            this.Conflictolabel.Text = "ERROR";
            // 
            // button_mover
            // 
            this.button_mover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_mover.Location = new System.Drawing.Point(690, 60);
            this.button_mover.Name = "button_mover";
            this.button_mover.Size = new System.Drawing.Size(200, 40);
            this.button_mover.TabIndex = 4;
            this.button_mover.Text = "Mover";
            this.button_mover.UseVisualStyleBackColor = true;
            this.button_mover.Click += new System.EventHandler(this.button_mover_Click);
            // 
            // button_automático
            // 
            this.button_automático.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_automático.Location = new System.Drawing.Point(690, 110);
            this.button_automático.Margin = new System.Windows.Forms.Padding(2);
            this.button_automático.Name = "button_automático";
            this.button_automático.Size = new System.Drawing.Size(200, 40);
            this.button_automático.TabIndex = 5;
            this.button_automático.Text = "Automatico";
            this.button_automático.UseVisualStyleBackColor = true;
            this.button_automático.Click += new System.EventHandler(this.button_automático_Click);
            // 
            // reloj
            // 
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // button_conflicto
            // 
            this.button_conflicto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_conflicto.Location = new System.Drawing.Point(690, 230);
            this.button_conflicto.Name = "button_conflicto";
            this.button_conflicto.Size = new System.Drawing.Size(200, 40);
            this.button_conflicto.TabIndex = 6;
            this.button_conflicto.Text = "¿Habrá conflicto?";
            this.button_conflicto.UseVisualStyleBackColor = true;
            this.button_conflicto.Click += new System.EventHandler(this.button_conflicto_Click);
            // 
            // button_datos
            // 
            this.button_datos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_datos.Location = new System.Drawing.Point(690, 280);
            this.button_datos.Margin = new System.Windows.Forms.Padding(2);
            this.button_datos.Name = "button_datos";
            this.button_datos.Size = new System.Drawing.Size(200, 40);
            this.button_datos.TabIndex = 7;
            this.button_datos.Text = "Datos de los vuelos";
            this.button_datos.UseVisualStyleBackColor = true;
            this.button_datos.Click += new System.EventHandler(this.button_datos_Click);
            // 
            // button_reset
            // 
            this.button_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_reset.BackColor = System.Drawing.Color.RosyBrown;
            this.button_reset.Location = new System.Drawing.Point(690, 160);
            this.button_reset.Margin = new System.Windows.Forms.Padding(2);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(200, 40);
            this.button_reset.TabIndex = 8;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = false;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_estadoActual
            // 
            this.button_estadoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_estadoActual.Location = new System.Drawing.Point(690, 330);
            this.button_estadoActual.Margin = new System.Windows.Forms.Padding(2);
            this.button_estadoActual.Name = "button_estadoActual";
            this.button_estadoActual.Size = new System.Drawing.Size(200, 40);
            this.button_estadoActual.TabIndex = 9;
            this.button_estadoActual.Text = "Guardar estado actual";
            this.button_estadoActual.UseVisualStyleBackColor = true;
            this.button_estadoActual.Click += new System.EventHandler(this.button_estadoActual_Click);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(914, 671);
            this.Controls.Add(this.button_estadoActual);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_datos);
            this.Controls.Add(this.button_conflicto);
            this.Controls.Add(this.button_automático);
            this.Controls.Add(this.button_mover);
            this.Controls.Add(this.Conflictolabel);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.pictureBox_espacioAereo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Resize += new System.EventHandler(this.Simulador_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_espacioAereo;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label Conflictolabel;
        private System.Windows.Forms.Button button_mover;
        private System.Windows.Forms.Button button_automático;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button button_conflicto;
        private System.Windows.Forms.Button button_datos;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_estadoActual;
    }
}