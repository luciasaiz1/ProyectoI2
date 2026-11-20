using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    
    public partial class DatosVuelos : Form
    {
        // ATRIBUTOS
        private Estilo estilo = new Estilo();
        private FlightPlanList llistaVuelos;

        // CONSTRUCTOR
        public DatosVuelos(FlightPlanList vuelos)
        {

            InitializeComponent();

            this.llistaVuelos = vuelos;

            dataGridView_vuelos.ReadOnly = true; 
            dataGridView_vuelos.AllowUserToAddRows = false; 
            dataGridView_vuelos.ColumnCount = 6;
            dataGridView_vuelos.RowCount = llistaVuelos.GetCount();
            dataGridView_vuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Títulos de las columnas
            dataGridView_vuelos.Columns[0].HeaderText = "Identificador";
            dataGridView_vuelos.Columns[1].HeaderText = "Compañía";
            dataGridView_vuelos.Columns[2].HeaderText = "Velocidad";
            dataGridView_vuelos.Columns[3].HeaderText = "Origen";
            dataGridView_vuelos.Columns[4].HeaderText = "Destino";
            dataGridView_vuelos.Columns[5].HeaderText = "Posición actual";

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                EscribirFila(i, llistaVuelos.GetFlightPlan(i));
            }

            dataGridView_vuelos.CellClick += dataGridView_vuelos_CellClick;
        }

        // MÉTODOS
        // Comunicación entre forms
        // Ver la distancia entre un vuelo y el resto de vuelos en DistanciaVuelo
        private void dataGridView_vuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; 

            FlightPlan vueloActual = llistaVuelos.GetFlightPlan(e.RowIndex);

            if (llistaVuelos.GetCount() <= 1)
            {
                MessageBox.Show("Se necesitan al menos 2 vuelos en la lista para calcular distancias.");
                return;
            }

            DistanciaVuelo form = new DistanciaVuelo(vueloActual, llistaVuelos);
            form.ShowDialog();
        }

        // Estética
        private void DatosVuelos_Paint(object sender, PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }

        // Escribir los datos de un vuelo en una fila del DataGridView
        private void EscribirFila(int fila, FlightPlan plan)
        {
            Position origen = plan.GetInitialPosition();
            Position destino = plan.GetFinalPosition();
            Position actual = plan.GetCurrentPosition();

            dataGridView_vuelos.Rows[fila].Cells[0].Value = plan.GetId();
            dataGridView_vuelos.Rows[fila].Cells[1].Value = plan.GetCompany();
            dataGridView_vuelos.Rows[fila].Cells[2].Value = plan.GetVelocidad().ToString("F2");
            dataGridView_vuelos.Rows[fila].Cells[3].Value = origen.GetX().ToString("F2") + " , " + origen.GetY().ToString("F2");
            dataGridView_vuelos.Rows[fila].Cells[4].Value = destino.GetX().ToString("F2") + " , " + destino.GetY().ToString("F2");
            dataGridView_vuelos.Rows[fila].Cells[5].Value = actual.GetX().ToString("F2") + " , " + actual.GetY().ToString("F2");
        }
    }

 }

