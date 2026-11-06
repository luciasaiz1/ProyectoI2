using FlightLib;
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
    public partial class Principal : Form
    {
        private FlightPlanList llistaVuelos = new FlightPlanList();

        private double distanciaSeguridad = 0;
        private double tiempoCiclo = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void introducirDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Obrim el navegador de fitxers de Windows per triar D'ENTRE ELS FITXERS QUE ACABEN EN .TXT 
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string rutaTriada = openFile.FileName;

                bool cargadoCorrectamente = llistaVuelos.LeerDelFichero(rutaTriada);

                if (cargadoCorrectamente && llistaVuelos.GetCount() > 0)
                {
                    // Si tot és correcte i s'han carregat vols
                    MessageBox.Show("Se han cargado " + llistaVuelos.GetCount() + " vuelos correctamente desde el fichero!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Si ha fallat el format o el fitxer no era vàlid
                    MessageBox.Show("Atención: El fichero seleccionado no tiene el formato correcto o contine líneas erróneas. No se han podido cargar los vuelos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistanciaSeguridad form = new DistanciaSeguridad(distanciaSeguridad, tiempoCiclo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.distanciaSeguridad = form.GetDistanciaSeguridad();
                this.tiempoCiclo = form.GetTiempoCiclo();

            }
        }

        private void SimuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //proteccion: si faltan parametros, avisamos y no abrimos el simulador
            if (this.tiempoCiclo <= 0 || this.distanciaSeguridad <= 0)
            {
                MessageBox.Show("Introduce primero la distancia de seguridad y el tiempo de ciclo (menu: Parametros)");
                return;
            }

            if (llistaVuelos.GetCount() > 0)
            {
                // Passem la llista sencera al simulador en lloc de dos plans sueltos
                Simulador formSim = new Simulador(llistaVuelos, this.distanciaSeguridad, this.tiempoCiclo);
                formSim.ShowDialog();
            }
            else
            {
                MessageBox.Show("Introduce o carga primero los datos de los vuelos desde un fichero.");
            }

        }
    }
}
