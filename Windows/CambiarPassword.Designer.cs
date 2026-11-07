namespace Windows
{
    partial class CambiarPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox_usuario2 = new System.Windows.Forms.TextBox();
            this.textBox_palabra = new System.Windows.Forms.TextBox();
            this.textBox_nuevapassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_cambiarpassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palabra de recuperación:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // textBox_usuario2
            // 
            this.textBox_usuario2.Location = new System.Drawing.Point(318, 69);
            this.textBox_usuario2.Name = "textBox_usuario2";
            this.textBox_usuario2.Size = new System.Drawing.Size(100, 20);
            this.textBox_usuario2.TabIndex = 2;
            // 
            // textBox_palabra
            // 
            this.textBox_palabra.Location = new System.Drawing.Point(318, 134);
            this.textBox_palabra.Name = "textBox_palabra";
            this.textBox_palabra.Size = new System.Drawing.Size(100, 20);
            this.textBox_palabra.TabIndex = 3;
            // 
            // textBox_nuevapassword
            // 
            this.textBox_nuevapassword.Location = new System.Drawing.Point(318, 199);
            this.textBox_nuevapassword.Name = "textBox_nuevapassword";
            this.textBox_nuevapassword.Size = new System.Drawing.Size(100, 20);
            this.textBox_nuevapassword.TabIndex = 4;
            this.textBox_nuevapassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nueva Contraseña:";
            // 
            // button_cambiarpassword
            // 
            this.button_cambiarpassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cambiarpassword.Location = new System.Drawing.Point(203, 287);
            this.button_cambiarpassword.Name = "button_cambiarpassword";
            this.button_cambiarpassword.Size = new System.Drawing.Size(166, 31);
            this.button_cambiarpassword.TabIndex = 6;
            this.button_cambiarpassword.Text = "Cambiar Contraseña";
            this.button_cambiarpassword.UseVisualStyleBackColor = true;
            this.button_cambiarpassword.Click += new System.EventHandler(this.button_cambiarpassword_Click);
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.button_cambiarpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_nuevapassword);
            this.Controls.Add(this.textBox_palabra);
            this.Controls.Add(this.textBox_usuario2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CambiarPassword";
            this.Text = "CambiarContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox_usuario2;
        private System.Windows.Forms.TextBox textBox_palabra;
        private System.Windows.Forms.TextBox textBox_nuevapassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_cambiarpassword;
    }
}