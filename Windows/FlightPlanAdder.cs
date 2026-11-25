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
        // ATRIBUTOS
        FlightPlanList listaPlanes = new FlightPlanList();
        FlightPlan plan1;
        FlightPlan plan2;

        // CONSTRUCTOR
        public FlightPlanAdder()
        {
            InitializeComponent();
        }
        // MÉTODOS
        // Comunicación entre forms
        public FlightPlanList GetPlanLista()
        {
            return this.listaPlanes;
        }

        // Añade vuelos predeterminados 
        private void button_predeterminados_Click(object sender, EventArgs e)
        {
            if (!RegistrarCompañiaSiNoExiste("Vueling") || !RegistrarCompañiaSiNoExiste("Iberia"))
                return;

            plan1 = new FlightPlan("VY2986", 0, 0, 2600, 1400, 60, "Vueling");
            plan2 = new FlightPlan("IB412", 0, 1400, 2600, 0, 60, "Iberia");
            listaPlanes.AddFlightPlan(plan1);
            listaPlanes.AddFlightPlan(plan2);
            Close();
        }

        private bool RegistrarCompañiaSiNoExiste(string nombre)
        {
            nombre = (nombre ?? "").Trim();
            if (nombre.Length == 0)
                return true;

            GestionCompañias gestion = new GestionCompañias();
            if (!gestion.Iniciar())
            {
                MessageBox.Show("No se ha podido abrir la base de datos de compañías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int resultado = gestion.RegistrarCompañia(nombre, "", "","");
                if (resultado == 0 || resultado == -1)
                    return true;

                MessageBox.Show("No se ha podido guardar la compañía en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compañía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                gestion.Cerrar();
            }
        }

        // Añadir un nuevo plan de vuelo
        private void button_añadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(textBox_velocidad.Text) < 0)
                {
                    MessageBox.Show("La velocidad debe ser un valor positivo", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt64(textBox_velocidad.Text) > 1000)
                {
                    MessageBox.Show("La velocidad debe ser un valor menor", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(textBox_currentPositionX.Text) < 0 || Convert.ToInt32(textBox_currentPositionY.Text) < 0 || Convert.ToInt32(textBox_finalPositionX.Text) < 0 || Convert.ToInt32(textBox_finalPositionY.Text) < 0)
                {
                    MessageBox.Show("Las posiciones deben ser valores positivos", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreCompañia = name_company.Text.Trim();
                if (!RegistrarCompañiaSiNoExiste(nombreCompañia))
                    return;

                plan1 = new FlightPlan(textBox_Id.Text, Convert.ToDouble(textBox_currentPositionX.Text), Convert.ToDouble(textBox_currentPositionY.Text), Convert.ToDouble(textBox_finalPositionX.Text), Convert.ToDouble(textBox_finalPositionY.Text), Convert.ToDouble(textBox_velocidad.Text), nombreCompañia);
                listaPlanes.AddFlightPlan(plan1);

                textBox_Id.Text = "";
                textBox_currentPositionX.Text = "";
                textBox_currentPositionY.Text = "";
                textBox_finalPositionX.Text = "";
                textBox_finalPositionY.Text = "";
                textBox_velocidad.Text = "";
                name_company.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos introducidos", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Cerrar ventana
        private void button_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
