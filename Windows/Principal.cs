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
        FlightPlan plan1;
        FlightPlan plan2;

        private double distanciaSeguridad = 0;
        private double tiempoCiclo = 0;

        public Principal()
        {
            InitializeComponent();
        }


        private void introducirDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightPlanAdder form = new FlightPlanAdder();
            form.ShowDialog();
           
            plan1 = form.GetPlan1();
            plan2 = form.GetPlan2();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistanciaSeguridad form = new DistanciaSeguridad(distanciaSeguridad, tiempoCiclo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.distanciaSeguridad = form.GetDistanciaSeguridad();
                this.tiempoCiclo = form.GetTiempoCiclo();

                MessageBox.Show($"Datos guardados correctamente:\nDistancia: {this.distanciaSeguridad}\nTiempo de ciclo: {this.tiempoCiclo}",
                                "Configuración actualizada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void SimuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (this.plan1 != null && this.plan2 != null)
            {
              
                Simulador formSim = new Simulador(this.plan1, this.plan2, this.distanciaSeguridad, this.tiempoCiclo);
                formSim.ShowDialog();
            }
            else
            {
                MessageBox.Show("Introduce primero los datos de los vuelos");
            }
        }
    }
}
