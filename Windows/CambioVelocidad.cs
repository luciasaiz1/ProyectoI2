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
    public partial class CambioVelocidad : Form
    {
        private FlightPlan plan;
        public CambioVelocidad(FlightPlan plan)
        {
            InitializeComponent();
            this.plan = plan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string velocidad = nueva_vel_textBox.Text;
            plan.SetVelocidad(Convert.ToDouble(velocidad));
            Close();
        }
    }
}
