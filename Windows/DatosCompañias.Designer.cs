namespace Windows
{
    partial class DatosCompañias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_compañias = new System.Windows.Forms.DataGridView();
            this.button_añadir = new System.Windows.Forms.Button();
            this.button_borrar_datos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_compañias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_compañias
            // 
            this.dataGridView_compañias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_compañias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_compañias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_compañias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_compañias.Location = new System.Drawing.Point(11, 11);
            this.dataGridView_compañias.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_compañias.Name = "dataGridView_compañias";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_compañias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_compañias.RowHeadersWidth = 51;
            this.dataGridView_compañias.RowTemplate.Height = 24;
            this.dataGridView_compañias.Size = new System.Drawing.Size(431, 199);
            this.dataGridView_compañias.TabIndex = 1;
            this.dataGridView_compañias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_compañias_CellClick);
            // 
            // button_añadir
            // 
            this.button_añadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.button_añadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_añadir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_añadir.ForeColor = System.Drawing.Color.White;
            this.button_añadir.Location = new System.Drawing.Point(11, 232);
            this.button_añadir.Name = "button_añadir";
            this.button_añadir.Size = new System.Drawing.Size(116, 23);
            this.button_añadir.TabIndex = 24;
            this.button_añadir.Text = "Añadir compañía";
            this.button_añadir.UseVisualStyleBackColor = false;
            // 
            // button_borrar_datos
            // 
            this.button_borrar_datos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.button_borrar_datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_borrar_datos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_borrar_datos.ForeColor = System.Drawing.Color.White;
            this.button_borrar_datos.Location = new System.Drawing.Point(304, 232);
            this.button_borrar_datos.Name = "button_borrar_datos";
            this.button_borrar_datos.Size = new System.Drawing.Size(137, 23);
            this.button_borrar_datos.TabIndex = 25;
            this.button_borrar_datos.Text = "Borrar base de datos";
            this.button_borrar_datos.UseVisualStyleBackColor = false;
            // 
            // DatosCompañias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 267);
            this.Controls.Add(this.button_borrar_datos);
            this.Controls.Add(this.button_añadir);
            this.Controls.Add(this.dataGridView_compañias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DatosCompañias";
            this.Text = "DatosCompañias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_compañias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_compañias;
        private System.Windows.Forms.Button button_añadir;
        private System.Windows.Forms.Button button_borrar_datos;
    }
}