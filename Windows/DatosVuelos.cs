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
        private Estilo estilo = new Estilo();
        private FlightPlanList llistaVuelos;

        public DatosVuelos(FlightPlanList vuelos)
        {

            InitializeComponent();

            this.llistaVuelos = vuelos;

            dataGridView_vuelos.ReadOnly = true; // no se puede escribir dentro de la tabla
            dataGridView_vuelos.AllowUserToAddRows = false; // sin fila vacia al final (SIEMPRE antes de RowCount)
            dataGridView_vuelos.ColumnCount = 6;
            dataGridView_vuelos.RowCount = llistaVuelos.GetCount(); //tantas filas como vuelos hay en la lista
            dataGridView_vuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Titulos de las columnas
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
      
            // Cuando se hace clic en una celda se ejecuta dataGridView_vuelos_CellClick
            dataGridView_vuelos.CellClick += dataGridView_vuelos_CellClick;
        }

        // Escribe los datos de un vuelo en la fila que le decimos
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

        private void dataGridView_vuelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // si se hace clic en los titulos: no hacemos nada

            //obtenemos el vuelo de la fila donde se hizo clic
            FlightPlan vueloActual = llistaVuelos.GetFlightPlan(e.RowIndex);

            //calculamos el índice del otro vuelo: cogemos el siguiente vuelo en la lista, y si nos pasamos, volvemos al primero
            int indiceOtro = e.RowIndex + 1;

            if (indiceOtro >= llistaVuelos.GetCount())
            {
                indiceOtro = 0;
            }

            FlightPlan otroVuelo = llistaVuelos.GetFlightPlan(indiceOtro);

            //si solo hay un vuelo en la lista, no podemos calcular distancia con otro
            if (llistaVuelos.GetCount() <= 1)
            {
                MessageBox.Show("Se necesitan al menos 2 vuelos en la lista para calcular distancias.");
                return;
            }

            DistanciaVuelo form = new DistanciaVuelo(vueloActual, otroVuelo);
            form.ShowDialog();
        }

        private void DatosVuelos_Paint(object sender, PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }
    }

 }

