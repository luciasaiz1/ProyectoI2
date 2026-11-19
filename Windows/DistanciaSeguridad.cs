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
        // Comprueba que el número es válido
        private bool EsValido(double numero)
        {
            return numero > 0 && numero <= 100;
        }
        // Introduce los valores de distancia y ciclo
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                double distancia = LeerNumero(textBox_distancia.Text);
                double ciclo = LeerNumero(textBox_tiempoCiclo.Text);

                if (EsValido(distancia) && EsValido(ciclo))
                {
                    this.distanciaSeguridad = distancia;
                    this.tiempoCiclo = ciclo;
                    this.DialogResult = DialogResult.OK;
                    this.Close();   // Cerrar el formulario y volver al menú principal
                }
                else
                {
                    MessageBox.Show("Ambos valores deben ser números mayores que cero y menores o iguales a 100.");
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
