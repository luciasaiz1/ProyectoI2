namespace Windows
{
    partial class DistanciaSeguridad
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_distancia = new System.Windows.Forms.TextBox();
            this.textBox_tiempoCiclo = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distancia de Seguridad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(229, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiempo de Ciclo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_distancia
            // 
            this.textBox_distancia.Location = new System.Drawing.Point(52, 81);
            this.textBox_distancia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_distancia.Name = "textBox_distancia";
            this.textBox_distancia.Size = new System.Drawing.Size(111, 22);
            this.textBox_distancia.TabIndex = 2;
            // 
            // textBox_tiempoCiclo
            // 
            this.textBox_tiempoCiclo.Location = new System.Drawing.Point(253, 81);
            this.textBox_tiempoCiclo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_tiempoCiclo.Name = "textBox_tiempoCiclo";
            this.textBox_tiempoCiclo.Size = new System.Drawing.Size(111, 22);
            this.textBox_tiempoCiclo.TabIndex = 3;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(132, 128);
            this.button_aceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(152, 31);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 169);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Predeterminado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DistanciaSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(428, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.textBox_tiempoCiclo);
            this.Controls.Add(this.textBox_distancia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DistanciaSeguridad";
            this.Text = "DistanciaSeguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_distancia;
        private System.Windows.Forms.TextBox textBox_tiempoCiclo;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button1;
    }
}