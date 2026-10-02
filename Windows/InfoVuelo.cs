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
        
            Position Origen = plan.GetInitialPosition();
            Position Destino = plan.GetFinalPosition();
            Position Actual = plan.GetCurrentPosition();

            label_id.Text = plan.GetId();
            label_compania.Text = plan.GetCompany();
            label_velocidad.Text = "Velocidad" + " : " + plan.GetVelocidad();
            label_origen.Text = Origen.GetX() + " , " + Origen.GetY();
            label_destino.Text = Destino.GetX() + " , " + Destino.GetY();
            label_actual.Text = Actual.GetX().ToString("F2")+ " , " + Actual.GetY().ToString("F2");

            if (plan.HasArrived())
                label_estado.Text = "Estado: Ha llegado a su destino";
            else
                label_estado.Text = "Estado: en vuelo ";

            //el titulo de la ventana muestra el id del vuelo
            this.Text = "Vuelo " + plan.GetId();
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
