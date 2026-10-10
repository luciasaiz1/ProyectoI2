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
        private FlightPlan plan1;
        private FlightPlan plan2;
        public DatosVuelos(FlightPlan plan1, FlightPlan plan2)
        {

            InitializeComponent();

            this.plan1 = plan1;// guardamos los vuelos para usarlos al hacer clic
            this.plan2 = plan2;

            dataGridView_vuelos.ReadOnly = true; // no se puede escribir dentro de la tabla
            dataGridView_vuelos.AllowUserToAddRows = false; // sin fila vacia al final (SIEMPRE antes de RowCount)
            dataGridView_vuelos.ColumnCount = 6; // 6 columnas
            dataGridView_vuelos.RowCount = 2; // 2 filas: una por vuelo
            dataGridView_vuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Titulos de las columnas
            dataGridView_vuelos.Columns[0].HeaderText = "Identificador";
            dataGridView_vuelos.Columns[1].HeaderText = "Compañía";
            dataGridView_vuelos.Columns[2].HeaderText = "Velocidad";
            dataGridView_vuelos.Columns[3].HeaderText = "Origen";
            dataGridView_vuelos.Columns[4].HeaderText = "Destino";
            dataGridView_vuelos.Columns[5].HeaderText = "Posición actual";

            EscribirFila(0, plan1); // la fila 0 es el vuelo 1
            EscribirFila(1, plan2); // la fila 1 es el vuelo 2

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

            DistanciaVuelo form;
            if (e.RowIndex == 0)
                form = new DistanciaVuelo(plan1, plan2); // fila 0: distancia del vuelo 1 al vuelo 2
            else
                form = new DistanciaVuelo(plan2, plan1); // fila 1: distancia del vuelo 2 al vuelo 1
            form.ShowDialog();
        }
    }

 }

