using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class DistanciaSeguridad : Form
    {
        // ATRIBUTOS
        private double distanciaSeguridad;
        private double tiempoCiclo;

        // CONSTRUCTOR
        public DistanciaSeguridad(double distancia, double ciclo)
        {
            InitializeComponent();
            this.textBox_distancia.Text = distancia.ToString(CultureInfo.InvariantCulture);
            this.textBox_tiempoCiclo.Text = ciclo.ToString(CultureInfo.InvariantCulture);
        }

        // MÉTODOS
        // Comunicación entre forms
        public double GetDistanciaSeguridad()
        {
            return this.distanciaSeguridad;
        }
        public double GetTiempoCiclo()
        {
            return this.tiempoCiclo;
        }

        // Cambia el formato del número para que sea válido en la conversión a double
        private double LeerNumero(string texto)
        {
            return Convert.ToDouble(texto.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
        }
      
        // Introduce los valores de distancia y ciclo
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                double distancia = LeerNumero(textBox_distancia.Text);
                double ciclo = LeerNumero(textBox_tiempoCiclo.Text);

                if ((distancia>=25 && distancia<=100) && (ciclo>=1 && ciclo<=50))
                {
                    this.distanciaSeguridad = distancia;
                    this.tiempoCiclo = ciclo;
                    this.DialogResult = DialogResult.OK;
                    this.Close();   // Cerrar el formulario y volver al menú principal
                }
                else
                {
                    MessageBox.Show("La distancia de seguridad ha de ser un número entre 25 y 100, y el tiempo de ciclo ha de ser un número entre 1 y 50.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos: escribe únicamente números enteros o decimales (ej. 5 o 2.5).");

            }
        }
        // Añade valores predeterminados a distancia y ciclo
        private void button_predeterminado_Click(object sender, EventArgs e)
        {
            distanciaSeguridad = 40;
            tiempoCiclo = 10;
            this.DialogResult = DialogResult.OK;
            this.Close();   // Cerrar el formulario y volver al menú principal
        }
    }
}
