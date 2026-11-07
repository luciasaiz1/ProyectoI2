namespace Windows
{
    partial class DistanciaVuelo
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
            this.label_distancia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_distancia
            // 
            this.label_distancia.AutoSize = true;
            this.label_distancia.Location = new System.Drawing.Point(52, 32);
            this.label_distancia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_distancia.Name = "label_distancia";
            this.label_distancia.Size = new System.Drawing.Size(38, 15);
            this.label_distancia.TabIndex = 0;
            this.label_distancia.Text = "label1";
            // 
            // DistanciaVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(422, 97);
            this.Controls.Add(this.label_distancia);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "DistanciaVuelo";
            this.Text = "Distancia entre vuelos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_distancia;
    }
}