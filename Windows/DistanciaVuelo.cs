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
        public DistanciaVuelo(FlightPlan vuelo, FlightPlanList lista)
        {
            InitializeComponent();
            this.Text = "Distancia del vuelo " + vuelo.GetId(); // titulo de la ventana
            label_distancia.Text = "Distancias al vuelo " + vuelo.GetId();

            dataGridView_vuelos.ReadOnly = true; 
            dataGridView_vuelos.AllowUserToAddRows = false; 
            dataGridView_vuelos.ColumnCount = 3;
            dataGridView_vuelos.RowCount = lista.GetCount(); 
            dataGridView_vuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView_vuelos.Columns[0].HeaderText = "Identificador";
            dataGridView_vuelos.Columns[1].HeaderText = "Compañía";
            dataGridView_vuelos.Columns[2].HeaderText = "Distancia";

            for (int i = 0; i < lista.GetCount(); i++)
            {
                dataGridView_vuelos.Rows[i].Cells[0].Value = lista.GetFlightPlan(i).GetId();
                dataGridView_vuelos.Rows[i].Cells[1].Value = lista.GetFlightPlan(i).GetCompany();
                dataGridView_vuelos.Rows[i].Cells[2].Value = vuelo.Distance(lista.GetFlightPlan(i));
            }

        }
    }
}
