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
            this.Conflictolabel = new System.Windows.Forms.Label();
            this.button_mover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_espacioAereo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_espacioAereo
            // 
            this.pictureBox_espacioAereo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox_espacioAereo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_espacioAereo.Location = new System.Drawing.Point(25, 93);
            this.pictureBox_espacioAereo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_espacioAereo.Name = "pictureBox_espacioAereo";
            this.pictureBox_espacioAereo.Size = new System.Drawing.Size(287, 290);
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
            this.Conflictolabel.Location = new System.Drawing.Point(22, 22);
            this.Conflictolabel.Name = "Conflictolabel";
            this.Conflictolabel.Size = new System.Drawing.Size(46, 13);
            this.Conflictolabel.TabIndex = 3;
            this.Conflictolabel.Text = "ERROR";
            // 
            // button_mover
            // 
            this.button_mover.Location = new System.Drawing.Point(68, 406);
            this.button_mover.Name = "button_mover";
            this.button_mover.Size = new System.Drawing.Size(193, 25);
            this.button_mover.TabIndex = 4;
            this.button_mover.Text = "Mover";
            this.button_mover.UseVisualStyleBackColor = true;
            this.button_mover.Click += new System.EventHandler(this.button_mover_Click);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(338, 443);
            this.Controls.Add(this.button_mover);
            this.Controls.Add(this.Conflictolabel);
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
        private System.Windows.Forms.Label Conflictolabel;
        private System.Windows.Forms.Button button_mover;
    }
}