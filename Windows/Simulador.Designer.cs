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
            this.Label_Info = new System.Windows.Forms.Label();
            this.Label_Conflicto = new System.Windows.Forms.Label();
            this.button_mover = new System.Windows.Forms.Button();
            this.button_auto = new System.Windows.Forms.Button();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.button_conflicto = new System.Windows.Forms.Button();
            this.button_datos = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_estadoActual = new System.Windows.Forms.Button();
            this.Label_Clue = new System.Windows.Forms.Label();
            this.button_volver = new System.Windows.Forms.Button();
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
            // Label_Info
            // 
            this.Label_Info.AutoSize = true;
            this.Label_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Info.Location = new System.Drawing.Point(25, 56);
            this.Label_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Info.Name = "Label_Info";
            this.Label_Info.Size = new System.Drawing.Size(37, 15);
            this.Label_Info.TabIndex = 1;
            this.Label_Info.Text = "label1";
            this.Label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Conflicto
            // 
            this.Label_Conflicto.AutoSize = true;
            this.Label_Conflicto.BackColor = System.Drawing.Color.Transparent;
            this.Label_Conflicto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Conflicto.ForeColor = System.Drawing.Color.Purple;
            this.Label_Conflicto.Location = new System.Drawing.Point(22, 21);
            this.Label_Conflicto.Name = "Label_Conflicto";
            this.Label_Conflicto.Size = new System.Drawing.Size(282, 17);
            this.Label_Conflicto.TabIndex = 3;
            this.Label_Conflicto.Text = "Pulsa \"Mover\" o \"Automático\" para empezar";
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
            // button_auto
            // 
            this.button_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_auto.Location = new System.Drawing.Point(690, 110);
            this.button_auto.Margin = new System.Windows.Forms.Padding(2);
            this.button_auto.Name = "button_auto";
            this.button_auto.Size = new System.Drawing.Size(200, 40);
            this.button_auto.TabIndex = 5;
            this.button_auto.Text = "Automatico";
            this.button_auto.UseVisualStyleBackColor = true;
            this.button_auto.Click += new System.EventHandler(this.button_auto_Click);
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
            // Label_Clue
            // 
            this.Label_Clue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Clue.AutoSize = true;
            this.Label_Clue.BackColor = System.Drawing.Color.Transparent;
            this.Label_Clue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Clue.ForeColor = System.Drawing.Color.Indigo;
            this.Label_Clue.Location = new System.Drawing.Point(687, 507);
            this.Label_Clue.Name = "Label_Clue";
            this.Label_Clue.Size = new System.Drawing.Size(206, 60);
            this.Label_Clue.TabIndex = 10;
            this.Label_Clue.Text = "Para cambiar las velocidades \r\nde los aviones, clica sobre cada avión \r\npara abri" +
    "r los datos del vuelo \r\ny editar la velocidad.";
            // 
            // button_volver
            // 
            this.button_volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_volver.BackColor = System.Drawing.Color.IndianRed;
            this.button_volver.Location = new System.Drawing.Point(725, 583);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(112, 43);
            this.button_volver.TabIndex = 11;
            this.button_volver.Text = "Volver al incio";
            this.button_volver.UseVisualStyleBackColor = false;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(914, 671);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.Label_Clue);
            this.Controls.Add(this.button_estadoActual);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_datos);
            this.Controls.Add(this.button_conflicto);
            this.Controls.Add(this.button_auto);
            this.Controls.Add(this.button_mover);
            this.Controls.Add(this.Label_Conflicto);
            this.Controls.Add(this.Label_Info);
            this.Controls.Add(this.pictureBox_espacioAereo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Simulador_Paint);
            this.Resize += new System.EventHandler(this.Simulador_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_espacioAereo;
        private System.Windows.Forms.Label Label_Info;
        private System.Windows.Forms.Label Label_Conflicto;
        private System.Windows.Forms.Button button_mover;
        private System.Windows.Forms.Button button_auto;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button button_conflicto;
        private System.Windows.Forms.Button button_datos;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_estadoActual;
        private System.Windows.Forms.Label Label_Clue;
        private System.Windows.Forms.Button button_volver;
    }
}