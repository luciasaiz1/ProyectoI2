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
            this.button1 = new System.Windows.Forms.Button();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_espacioAereo
            // 
            this.pictureBox_espacioAereo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox_espacioAereo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_espacioAereo.Location = new System.Drawing.Point(32, 103);
            this.pictureBox_espacioAereo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_espacioAereo.Name = "pictureBox_espacioAereo";
            this.pictureBox_espacioAereo.Size = new System.Drawing.Size(400, 400);
            this.pictureBox_espacioAereo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_espacioAereo.TabIndex = 0;
            this.pictureBox_espacioAereo.TabStop = false;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_info.Location = new System.Drawing.Point(33, 69);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(46, 18);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label1";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Conflictolabel
            // 
            this.Conflictolabel.AutoSize = true;
            this.Conflictolabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.Location = new System.Drawing.Point(29, 27);
            this.Conflictolabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Conflictolabel.Name = "Conflictolabel";
            this.Conflictolabel.Size = new System.Drawing.Size(56, 16);
            this.Conflictolabel.TabIndex = 3;
            this.Conflictolabel.Text = "ERROR";
            // 
            // button_mover
            // 
            this.button_mover.Location = new System.Drawing.Point(91, 524);
            this.button_mover.Margin = new System.Windows.Forms.Padding(4);
            this.button_mover.Name = "button_mover";
            this.button_mover.Size = new System.Drawing.Size(257, 30);
            this.button_mover.TabIndex = 4;
            this.button_mover.Text = "Mover";
            this.button_mover.UseVisualStyleBackColor = true;
            this.button_mover.Click += new System.EventHandler(this.button_mover_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 561);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Automatico";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reloj
            // 
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 597);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "¿Habrá conflicto?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(451, 638);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_mover);
            this.Controls.Add(this.Conflictolabel);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.pictureBox_espacioAereo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Simulador";
            this.Text = "Simulador";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_espacioAereo;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label Conflictolabel;
        private System.Windows.Forms.Button button_mover;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button button2;
    }
}