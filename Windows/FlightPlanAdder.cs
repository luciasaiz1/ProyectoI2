using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlightLib;

namespace Windows
{
    public partial class FlightPlanAdder : Form
    {
        FlightPlan plan1;
        FlightPlan plan2;

        public FlightPlanAdder()
        {
            InitializeComponent();
        }

        public FlightPlan GetPlan1()
        {
            return this.plan1;
        }

        public FlightPlan GetPlan2()
        {
            return this.plan2;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (plan1 == null)
                {
                    //Recogemos los datos que se han introducido
                    plan1 = new FlightPlan(textBox_Id.Text, Convert.ToDouble(textBox_currentPositionX.Text), Convert.ToDouble(textBox_currentPositionY.Text), Convert.ToDouble(textBox_finalPositionX.Text), Convert.ToDouble(textBox_finalPositionY.Text), Convert.ToDouble(textBox_velocidad.Text));
                    MessageBox.Show("Primer plan de vuelo introducido! Introduce ahora el segundo plan de vuelo.");
                    
                    //Vaciamos el TextBox para poder escribir los datos del segundo avión
                    textBox_Id.Text = "";
                    textBox_currentPositionX.Text = "";
                    textBox_currentPositionY.Text = "";
                    textBox_finalPositionX.Text = "";
                    textBox_finalPositionY.Text = "";
                    textBox_velocidad.Text = "";

                }

                else if (plan2==null)
                {
                    //Hacemos lo mismo para el segundo plan de vuelo
                    plan2 = new FlightPlan(textBox_Id.Text, Convert.ToDouble(textBox_currentPositionX.Text), Convert.ToDouble(textBox_currentPositionY.Text), Convert.ToDouble(textBox_finalPositionX.Text), Convert.ToDouble(textBox_finalPositionY.Text), Convert.ToDouble(textBox_velocidad.Text));
                    MessageBox.Show("Se han introducido los dos planes de vuelo!");
                    Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos introducidos");
            }
        }
    }
}
