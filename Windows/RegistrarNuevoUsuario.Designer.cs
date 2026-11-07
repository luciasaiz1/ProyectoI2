namespace Windows
{
    partial class RegistrarNuevoUsuario
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
            this.palabrarecuperacion = new System.Windows.Forms.Label();
            this.textBox_recuperacion = new System.Windows.Forms.TextBox();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label_usuario = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NuevaPassword = new System.Windows.Forms.TextBox();
            this.button_registrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // palabrarecuperacion
            // 
            this.palabrarecuperacion.AutoSize = true;
            this.palabrarecuperacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palabrarecuperacion.Location = new System.Drawing.Point(169, 132);
            this.palabrarecuperacion.Name = "palabrarecuperacion";
            this.palabrarecuperacion.Size = new System.Drawing.Size(83, 34);
            this.palabrarecuperacion.TabIndex = 15;
            this.palabrarecuperacion.Text = "Palabra de \r\nrecuperación:";
            // 
            // textBox_recuperacion
            // 
            this.textBox_recuperacion.Location = new System.Drawing.Point(308, 134);
            this.textBox_recuperacion.Name = "textBox_recuperacion";
            this.textBox_recuperacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_recuperacion.TabIndex = 14;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(308, 77);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(100, 20);
            this.textBox_usuario.TabIndex = 12;
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.Location = new System.Drawing.Point(168, 77);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(61, 20);
            this.label_usuario.TabIndex = 11;
            this.label_usuario.Text = "Usuario:";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(168, 132);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(0, 20);
            this.label_password.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nueva Contraseña:";
            // 
            // textBox_NuevaPassword
            // 
            this.textBox_NuevaPassword.Location = new System.Drawing.Point(308, 199);
            this.textBox_NuevaPassword.Name = "textBox_NuevaPassword";
            this.textBox_NuevaPassword.Size = new System.Drawing.Size(100, 20);
            this.textBox_NuevaPassword.TabIndex = 17;
            this.textBox_NuevaPassword.UseSystemPasswordChar = true;
            // 
            // button_registrar
            // 
            this.button_registrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrar.Location = new System.Drawing.Point(244, 269);
            this.button_registrar.Name = "button_registrar";
            this.button_registrar.Size = new System.Drawing.Size(101, 29);
            this.button_registrar.TabIndex = 18;
            this.button_registrar.Text = "Registrarme";
            this.button_registrar.UseVisualStyleBackColor = true;
            this.button_registrar.Click += new System.EventHandler(this.button_registrar_Click);
            // 
            // RegistrarNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.button_registrar);
            this.Controls.Add(this.textBox_NuevaPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.palabrarecuperacion);
            this.Controls.Add(this.textBox_recuperacion);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label_usuario);
            this.Controls.Add(this.label_password);
            this.Name = "RegistrarNuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Nuevo Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label palabrarecuperacion;
        private System.Windows.Forms.TextBox textBox_recuperacion;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NuevaPassword;
        private System.Windows.Forms.Button button_registrar;
    }
}