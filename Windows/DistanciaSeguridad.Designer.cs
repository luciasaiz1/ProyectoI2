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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distancia de Seguridad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(172, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tiempo de Ciclo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_distancia
            // 
            this.textBox_distancia.Location = new System.Drawing.Point(39, 66);
            this.textBox_distancia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_distancia.Name = "textBox_distancia";
            this.textBox_distancia.Size = new System.Drawing.Size(84, 20);
            this.textBox_distancia.TabIndex = 2;
            // 
            // textBox_tiempoCiclo
            // 
            this.textBox_tiempoCiclo.Location = new System.Drawing.Point(190, 66);
            this.textBox_tiempoCiclo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_tiempoCiclo.Name = "textBox_tiempoCiclo";
            this.textBox_tiempoCiclo.Size = new System.Drawing.Size(84, 20);
            this.textBox_tiempoCiclo.TabIndex = 3;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(99, 104);
            this.button_aceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(114, 25);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // DistanciaSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(321, 152);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.textBox_tiempoCiclo);
            this.Controls.Add(this.textBox_distancia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}