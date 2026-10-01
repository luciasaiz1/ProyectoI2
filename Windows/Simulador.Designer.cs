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
            this.pictureBox_espacioAereo = new System.Windows.Forms.PictureBox();
            this.label_info = new System.Windows.Forms.Label();
            this.button_mover = new System.Windows.Forms.Label();
            this.Conflictolabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_espacioAereo
            // 
            this.pictureBox_espacioAereo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_espacioAereo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_espacioAereo.Location = new System.Drawing.Point(186, 62);
            this.pictureBox_espacioAereo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_espacioAereo.Name = "pictureBox_espacioAereo";
            this.pictureBox_espacioAereo.Size = new System.Drawing.Size(226, 244);
            this.pictureBox_espacioAereo.TabIndex = 0;
            this.pictureBox_espacioAereo.TabStop = false;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(278, 36);
            this.label_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(35, 13);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label1";
            // 
            // button_mover
            // 
            this.button_mover.AutoSize = true;
            this.button_mover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_mover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_mover.Location = new System.Drawing.Point(267, 320);
            this.button_mover.Name = "button_mover";
            this.button_mover.Size = new System.Drawing.Size(77, 13);
            this.button_mover.TabIndex = 2;
            this.button_mover.Text = "Mover un ciclo";
            this.button_mover.Click += new System.EventHandler(this.button_mover_Click);
            // 
            // Conflictolabel
            // 
            this.Conflictolabel.AutoSize = true;
            this.Conflictolabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Conflictolabel.Location = new System.Drawing.Point(456, 95);
            this.Conflictolabel.Name = "Conflictolabel";
            this.Conflictolabel.Size = new System.Drawing.Size(0, 13);
            this.Conflictolabel.TabIndex = 3;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Conflictolabel);
            this.Controls.Add(this.button_mover);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.pictureBox_espacioAereo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Simulador";
            this.Text = "Simulador";
          
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_espacioAereo;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label button_mover;
        private System.Windows.Forms.Label Conflictolabel;
    }
}