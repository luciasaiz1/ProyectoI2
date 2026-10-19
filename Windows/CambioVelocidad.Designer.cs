namespace Windows
{
    partial class CambioVelocidad
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
            this.button1 = new System.Windows.Forms.Button();
            this.nueva_vel_textBox = new System.Windows.Forms.TextBox();
            this.nueva_vel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nueva_vel_textBox
            // 
            this.nueva_vel_textBox.Location = new System.Drawing.Point(63, 55);
            this.nueva_vel_textBox.Name = "nueva_vel_textBox";
            this.nueva_vel_textBox.Size = new System.Drawing.Size(100, 22);
            this.nueva_vel_textBox.TabIndex = 1;
            // 
            // nueva_vel
            // 
            this.nueva_vel.AutoSize = true;
            this.nueva_vel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nueva_vel.Location = new System.Drawing.Point(28, 25);
            this.nueva_vel.Name = "nueva_vel";
            this.nueva_vel.Size = new System.Drawing.Size(167, 18);
            this.nueva_vel.TabIndex = 2;
            this.nueva_vel.Text = "Introduce nueva velocidad";
            // 
            // CambioVelocidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 137);
            this.Controls.Add(this.nueva_vel);
            this.Controls.Add(this.nueva_vel_textBox);
            this.Controls.Add(this.button1);
            this.Name = "CambioVelocidad";
            this.Text = "CambioVelocidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nueva_vel_textBox;
        private System.Windows.Forms.Label nueva_vel;
    }
}