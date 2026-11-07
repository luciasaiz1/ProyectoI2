namespace Windows
{
    partial class Login
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
            this.button_registrar = new System.Windows.Forms.Button();
            this.button_entrar = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.label_usuario = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_recuperacion = new System.Windows.Forms.TextBox();
            this.palabrarecuperacion = new System.Windows.Forms.Label();
            this.linkCambiarContrasena = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_registrar
            // 
            this.button_registrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrar.Location = new System.Drawing.Point(416, 237);
            this.button_registrar.Name = "button_registrar";
            this.button_registrar.Size = new System.Drawing.Size(120, 42);
            this.button_registrar.TabIndex = 0;
            this.button_registrar.Text = "Registrar nuevo usuario";
            this.button_registrar.UseVisualStyleBackColor = true;
            this.button_registrar.Click += new System.EventHandler(this.button_registrar_Click);
            // 
            // button_entrar
            // 
            this.button_entrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_entrar.Location = new System.Drawing.Point(40, 280);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(75, 23);
            this.button_entrar.TabIndex = 1;
            this.button_entrar.Text = "Entrar";
            this.button_entrar.UseVisualStyleBackColor = true;
            this.button_entrar.Click += new System.EventHandler(this.button_entrar_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(36, 148);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(85, 20);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Contraseña:";
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.Location = new System.Drawing.Point(36, 93);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(61, 20);
            this.label_usuario.TabIndex = 3;
            this.label_usuario.Text = "Usuario:";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(176, 93);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(100, 20);
            this.textBox_usuario.TabIndex = 4;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(176, 148);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(162, 20);
            this.textBox_password.TabIndex = 5;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "¿No tienes usuario? \r\npulsa \"Registrar nuevo usuario\".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // textBox_recuperacion
            // 
            this.textBox_recuperacion.Location = new System.Drawing.Point(176, 201);
            this.textBox_recuperacion.Name = "textBox_recuperacion";
            this.textBox_recuperacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_recuperacion.TabIndex = 8;
            // 
            // palabrarecuperacion
            // 
            this.palabrarecuperacion.AutoSize = true;
            this.palabrarecuperacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palabrarecuperacion.Location = new System.Drawing.Point(38, 201);
            this.palabrarecuperacion.Name = "palabrarecuperacion";
            this.palabrarecuperacion.Size = new System.Drawing.Size(83, 34);
            this.palabrarecuperacion.TabIndex = 9;
            this.palabrarecuperacion.Text = "Palabra de \r\nrecuperación:";
            // 
            // linkCambiarContrasena
            // 
            this.linkCambiarContrasena.AutoSize = true;
            this.linkCambiarContrasena.Location = new System.Drawing.Point(404, 312);
            this.linkCambiarContrasena.Name = "linkCambiarContrasena";
            this.linkCambiarContrasena.Size = new System.Drawing.Size(149, 13);
            this.linkCambiarContrasena.TabIndex = 10;
            this.linkCambiarContrasena.TabStop = true;
            this.linkCambiarContrasena.Text = "¿Has olvidado tu contraseña?";
            this.linkCambiarContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCambiarContrasena_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 42);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bienvenid@   \r\nInicia Sesión";
            // 
            // Login
            // 
            this.AcceptButton = this.button_entrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkCambiarContrasena);
            this.Controls.Add(this.palabrarecuperacion);
            this.Controls.Add(this.textBox_recuperacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label_usuario);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.button_registrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deconflicting Tool- Iniciar Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_registrar;
        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_recuperacion;
        private System.Windows.Forms.Label palabrarecuperacion;
        private System.Windows.Forms.LinkLabel linkCambiarContrasena;
        private System.Windows.Forms.Label label3;
    }
}