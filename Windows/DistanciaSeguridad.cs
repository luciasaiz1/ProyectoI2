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
        private double distanciaSeguridad;
        private double tiempoCiclo;

        public DistanciaSeguridad()
        {
            InitializeComponent();
        }

        public DistanciaSeguridad(double distancia, double ciclo)
        {
            InitializeComponent();
            this.textBox_distancia.Text = distancia.ToString(CultureInfo.InvariantCulture);
            this.textBox_tiempoCiclo.Text = ciclo.ToString(CultureInfo.InvariantCulture);
        }

        public double GetDistanciaSeguridad()
        {
            return this.distanciaSeguridad;
        }

        public double GetTiempoCiclo()
        {
            return this.tiempoCiclo;
        }

        private double LeerNumero(string texto)
        {
            return Convert.ToDouble(texto.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        private bool EsValido(double numero)
        {
            return numero > 0 && !double.IsInfinity(numero);
        }

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

                    // Indicamos que los datos se han aceptado con éxito y cerramos la ventana
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ambos valores deben ser números mayores que cero.",
                                    "Error de validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos: escribe únicamente números enteros o decimales (ej. 5 o 2.5).",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }
        }
    }
}
