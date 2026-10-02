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
        public InfoVuelo(FlightPlan plan) //para crearme, darme un flight plan que lo llamaré plan
        {
            InitializeComponent();

            //Plan de vuelo que ha de mostrar
        
            Position origen = plan.GetInitialPosition();
            Position destino = plan.GetFinalPosition();
            Position actual = plan.GetCurrentPosition();

            label_id.Text = plan.GetId();
            label_compania.Text = plan.GetCompany();
            label_velocidad.Text = Convert.ToString(plan.GetVelocidad());
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
    }
}
