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
    public partial class DistanciaVuelo : Form
    {
        public DistanciaVuelo(FlightPlan vuelo, FlightPlan otro)
        {
            InitializeComponent();
            this.Text = "Distancia del vuelo " + vuelo.GetId(); // titulo de la ventana
            
            double distancia = vuelo.Distance(otro); // metodo que ya habíamos hecho en FlightPlan
            label_distancia.Text = "Distancia entre el vuelo " + vuelo.GetId() + " y el vuelo " + otro.GetId() + ": " + distancia.ToString("F2");
        }
    }
}
