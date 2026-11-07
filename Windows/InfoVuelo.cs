using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class InfoVuelo : Form
    {
        private Estilo estilo = new Estilo();
        private FlightPlan plan;
        public InfoVuelo(FlightPlan plan) //para crearme, darme un flight plan que lo llamaré plan
        {
            InitializeComponent();
            this.plan = plan;

            //Plan de vuelo que ha de mostrar

            Position origen = plan.GetInitialPosition();
            Position destino = plan.GetFinalPosition();
            Position actual = plan.GetCurrentPosition();

            label_id.Text = plan.GetId();
            label_compania.Text = plan.GetCompany();
            numericUpDown_velocidad.DecimalPlaces = 2;
            numericUpDown_velocidad.Minimum = 0.01m;
            numericUpDown_velocidad.Maximum = 1000;
            numericUpDown_velocidad.Value = (decimal)plan.GetVelocidad();
            this.AcceptButton = button1_aplicar;
            label_origen.Text = origen.GetX() + " , " + origen.GetY();
            label_destino.Text = destino.GetX() + " , " + destino.GetY();
            label_actual.Text = actual.GetX()+ " , " + actual.GetY();

            if (plan.HasArrived())
                label_estado.Text = "Ha llegado a su destino";
            else
                label_estado.Text = "En vuelo ";

            //el titulo de la ventana muestra el id del vuelo
            this.Text = "Vuelo " + plan.GetId();
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_aplicar_Click(object sender, EventArgs e)
        {
            double nueva = (double)numericUpDown_velocidad.Value;

            //si no hemos cambiado la velocidad, solo cerramos (no reiniciamos la simulacion)
            if (Math.Abs(nueva - plan.GetVelocidad()) < 0.005)
            {
                Close();
                return;
            }

            plan.SetVelocidad(nueva);
            this.DialogResult = DialogResult.OK; 

            //Avisa al simulador que reinicie y compruebe y también cierra la ventana
        }
    }
}
