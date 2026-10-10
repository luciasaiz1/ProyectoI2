namespace Windows
{
    partial class DatosVuelos
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
            this.dataGridView_vuelos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_vuelos
            // 
            this.dataGridView_vuelos.BackgroundColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView_vuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vuelos.Location = new System.Drawing.Point(10, 12);
            this.dataGridView_vuelos.Name = "dataGridView_vuelos";
            this.dataGridView_vuelos.RowHeadersWidth = 51;
            this.dataGridView_vuelos.RowTemplate.Height = 24;
            this.dataGridView_vuelos.Size = new System.Drawing.Size(660, 160);
            this.dataGridView_vuelos.TabIndex = 0;
            // 
            // DatosVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(682, 183);
            this.Controls.Add(this.dataGridView_vuelos);
            this.Name = "DatosVuelos";
            this.Text = "DatosVuelos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vuelos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_vuelos;
    }
}