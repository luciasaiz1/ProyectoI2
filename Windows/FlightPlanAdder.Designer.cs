namespace Windows
{
    partial class FlightPlanAdder
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
            this.button_aceptar = new System.Windows.Forms.Button();
            this.label_Id = new System.Windows.Forms.Label();
            this.label_currentPositionX = new System.Windows.Forms.Label();
            this.label_finalPositionX = new System.Windows.Forms.Label();
            this.label_velocidad = new System.Windows.Forms.Label();
            this.textBox_Id = new System.Windows.Forms.TextBox();
            this.textBox_currentPositionX = new System.Windows.Forms.TextBox();
            this.textBox_finalPositionX = new System.Windows.Forms.TextBox();
            this.textBox_velocidad = new System.Windows.Forms.TextBox();
            this.label_currentPositionY = new System.Windows.Forms.Label();
            this.textBox_currentPositionY = new System.Windows.Forms.TextBox();
            this.textBox_finalPositionY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name_company = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(46, 300);
            this.button_aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(205, 25);
            this.button_aceptar.TabIndex = 0;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // label_Id
            // 
            this.label_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Id.Location = new System.Drawing.Point(21, 22);
            this.label_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Id.Name = "label_Id";
            this.label_Id.Size = new System.Drawing.Size(25, 20);
            this.label_Id.TabIndex = 1;
            this.label_Id.Text = "ID";
            this.label_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_currentPositionX
            // 
            this.label_currentPositionX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_currentPositionX.Location = new System.Drawing.Point(21, 58);
            this.label_currentPositionX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_currentPositionX.Name = "label_currentPositionX";
            this.label_currentPositionX.Size = new System.Drawing.Size(100, 20);
            this.label_currentPositionX.TabIndex = 2;
            this.label_currentPositionX.Text = "Posición actual (x)";
            this.label_currentPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_finalPositionX
            // 
            this.label_finalPositionX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_finalPositionX.Location = new System.Drawing.Point(21, 137);
            this.label_finalPositionX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_finalPositionX.Name = "label_finalPositionX";
            this.label_finalPositionX.Size = new System.Drawing.Size(100, 20);
            this.label_finalPositionX.TabIndex = 3;
            this.label_finalPositionX.Text = "Posición final (x)";
            this.label_finalPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_velocidad
            // 
            this.label_velocidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_velocidad.Location = new System.Drawing.Point(21, 220);
            this.label_velocidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_velocidad.Name = "label_velocidad";
            this.label_velocidad.Size = new System.Drawing.Size(75, 20);
            this.label_velocidad.TabIndex = 4;
            this.label_velocidad.Text = "Velocidad";
            this.label_velocidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Id
            // 
            this.textBox_Id.Location = new System.Drawing.Point(150, 23);
            this.textBox_Id.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Id.Name = "textBox_Id";
            this.textBox_Id.Size = new System.Drawing.Size(116, 20);
            this.textBox_Id.TabIndex = 5;
            // 
            // textBox_currentPositionX
            // 
            this.textBox_currentPositionX.Location = new System.Drawing.Point(150, 59);
            this.textBox_currentPositionX.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_currentPositionX.Name = "textBox_currentPositionX";
            this.textBox_currentPositionX.Size = new System.Drawing.Size(116, 20);
            this.textBox_currentPositionX.TabIndex = 6;
            // 
            // textBox_finalPositionX
            // 
            this.textBox_finalPositionX.Location = new System.Drawing.Point(150, 138);
            this.textBox_finalPositionX.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_finalPositionX.Name = "textBox_finalPositionX";
            this.textBox_finalPositionX.Size = new System.Drawing.Size(116, 20);
            this.textBox_finalPositionX.TabIndex = 7;
            // 
            // textBox_velocidad
            // 
            this.textBox_velocidad.Location = new System.Drawing.Point(150, 221);
            this.textBox_velocidad.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_velocidad.Name = "textBox_velocidad";
            this.textBox_velocidad.Size = new System.Drawing.Size(116, 20);
            this.textBox_velocidad.TabIndex = 8;
            // 
            // label_currentPositionY
            // 
            this.label_currentPositionY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_currentPositionY.Location = new System.Drawing.Point(21, 97);
            this.label_currentPositionY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_currentPositionY.Name = "label_currentPositionY";
            this.label_currentPositionY.Size = new System.Drawing.Size(100, 20);
            this.label_currentPositionY.TabIndex = 9;
            this.label_currentPositionY.Text = "Posición actual (y)";
            this.label_currentPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_currentPositionY
            // 
            this.textBox_currentPositionY.Location = new System.Drawing.Point(150, 97);
            this.textBox_currentPositionY.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_currentPositionY.Name = "textBox_currentPositionY";
            this.textBox_currentPositionY.Size = new System.Drawing.Size(116, 20);
            this.textBox_currentPositionY.TabIndex = 10;
            // 
            // textBox_finalPositionY
            // 
            this.textBox_finalPositionY.Location = new System.Drawing.Point(150, 182);
            this.textBox_finalPositionY.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_finalPositionY.Name = "textBox_finalPositionY";
            this.textBox_finalPositionY.Size = new System.Drawing.Size(116, 20);
            this.textBox_finalPositionY.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(21, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Posición final (y)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name_company
            // 
            this.name_company.Location = new System.Drawing.Point(150, 257);
            this.name_company.Name = "name_company";
            this.name_company.Size = new System.Drawing.Size(116, 20);
            this.name_company.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(21, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Compañía";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlightPlanAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(292, 350);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name_company);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_finalPositionY);
            this.Controls.Add(this.textBox_currentPositionY);
            this.Controls.Add(this.label_currentPositionY);
            this.Controls.Add(this.textBox_velocidad);
            this.Controls.Add(this.textBox_finalPositionX);
            this.Controls.Add(this.textBox_currentPositionX);
            this.Controls.Add(this.textBox_Id);
            this.Controls.Add(this.label_velocidad);
            this.Controls.Add(this.label_finalPositionX);
            this.Controls.Add(this.label_currentPositionX);
            this.Controls.Add(this.label_Id);
            this.Controls.Add(this.button_aceptar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FlightPlanAdder";
            this.Text = "FlightPlanAdder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Label label_Id;
        private System.Windows.Forms.Label label_currentPositionX;
        private System.Windows.Forms.Label label_finalPositionX;
        private System.Windows.Forms.Label label_velocidad;
        private System.Windows.Forms.TextBox textBox_Id;
        private System.Windows.Forms.TextBox textBox_currentPositionX;
        private System.Windows.Forms.TextBox textBox_finalPositionX;
        private System.Windows.Forms.TextBox textBox_velocidad;
        private System.Windows.Forms.Label label_currentPositionY;
        private System.Windows.Forms.TextBox textBox_currentPositionY;
        private System.Windows.Forms.TextBox textBox_finalPositionY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_company;
        private System.Windows.Forms.Label label3;
    }
}