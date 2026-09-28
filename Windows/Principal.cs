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
    public partial class Principal : Form
    {
        FlightPlan plan1;
        FlightPlan plan2;

        public Principal()
        {
            InitializeComponent();
        }


        private void introducirDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightPlanAdder form = new FlightPlanAdder();
            form.ShowDialog();
            //Guardamos los dos planos de vuelo en el formulario principal
            plan1 = form.GetPlan1();
            plan2 = form.GetPlan2();
        }
    }
}
