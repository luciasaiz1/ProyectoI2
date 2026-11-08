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
            this.dataGridView_vuelos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // label_distancia
            // 
            this.label_distancia.AutoSize = true;
            this.label_distancia.Location = new System.Drawing.Point(11, 9);
            this.label_distancia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_distancia.Name = "label_distancia";
            this.label_distancia.Size = new System.Drawing.Size(38, 15);
            this.label_distancia.TabIndex = 0;
            this.label_distancia.Text = "label1";
            // 
            // dataGridView_vuelos
            // 
            this.dataGridView_vuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vuelos.Location = new System.Drawing.Point(14, 38);
            this.dataGridView_vuelos.Name = "dataGridView_vuelos";
            this.dataGridView_vuelos.Size = new System.Drawing.Size(351, 167);
            this.dataGridView_vuelos.TabIndex = 1;
            // 
            // DistanciaVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(378, 217);
            this.Controls.Add(this.dataGridView_vuelos);
            this.Controls.Add(this.label_distancia);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "DistanciaVuelo";
            this.Text = "Distancia entre vuelos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vuelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_distancia;
        private System.Windows.Forms.DataGridView dataGridView_vuelos;
    }
}