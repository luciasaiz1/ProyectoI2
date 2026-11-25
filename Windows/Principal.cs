using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Principal : Form
    {
        // ATRIBUTOS
        private Estilo estilo = new Estilo();
        private FlightPlanList listaVuelos = new FlightPlanList();
        private Stack<FlightPlanList> stackVuelos = new Stack<FlightPlanList>();
        private double distanciaSeguridad = 0;
        private double tiempoCiclo = 0;

        // CONSTRUCTOR
        public Principal(string usuario)
        {
            InitializeComponent();
            this.Text = "Deconflicting Tool - Menú principal ⋅ Usuario: " + usuario;

            pictureBoxTutorialLeft.Image = Properties.Resources.tutorial1;
            pictureBoxTutorialRight.Image = Properties.Resources.tutorial2;

            pictureBoxTutorialLeft.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTutorialRight.SizeMode = PictureBoxSizeMode.Zoom;

            // Abre la ventana maximizada
            this.WindowState = FormWindowState.Maximized;
        }

        // MÉTODOS
        // Comunicación entre forms
        // Introducir datos de vuelos manualmente en FlightPlanAdder
        private void introducirDatosManualmenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightPlanAdder form = new FlightPlanAdder();
            form.ShowDialog();

            FlightPlanList lista = form.GetPlanLista();
            listaVuelos = lista;

            if (listaVuelos.GetCount() > 0)
            {
                MessageBox.Show("Se han añadido " + listaVuelos.GetCount() + " vuelos correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool RegistrarCompañiaSiNoExiste(string nombre)
        {
            nombre = (nombre ?? "").Trim();

            if (nombre.Length == 0)
                return true;

            GestionCompañias gestion = new GestionCompañias();

            if (!gestion.Iniciar())
            {
                MessageBox.Show(
                    "No se ha podido abrir la base de datos de compañías.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            try
            {
                int resultado = gestion.RegistrarCompañia(nombre,"","","");

                if (resultado == 0 || resultado == -1)
                    return true;

                MessageBox.Show(
                    "No se ha podido guardar la compañía en la base de datos.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la compañía: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                gestion.Cerrar();
            }
        }

        // Introducir datos de vuelos desde un fichero
        private void introducirDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); // Abrir el navegador de archivos para seleccionar el fichero de vuelos
            openFile.InitialDirectory = Application.StartupPath; //Abre en la carpeta del programa donde estan los ficheros de ejemplo

            openFile.Filter = "Text Files (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string rutaEncontrada = openFile.FileName;

                bool cargadoCorrectamente = listaVuelos.LeerDelFichero(rutaEncontrada);

                if (cargadoCorrectamente && listaVuelos.GetCount() > 0)
                {
                    for (int i = 0; i < listaVuelos.GetCount(); i++)
                    {
                        FlightPlan vuelo = listaVuelos.GetFlightPlan(i);

                        if (!RegistrarCompañiaSiNoExiste(vuelo.GetCompany()))
                            return;
                    }
                    MessageBox.Show("Se han cargado " + listaVuelos.GetCount() +" vuelos correctamente desde el fichero!","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        // Poner la distancia de seguridad y el tiempo de ciclo en DistanciaSeguridad
        private void distanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistanciaSeguridad form = new DistanciaSeguridad(distanciaSeguridad, tiempoCiclo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Se ha aplicado la distancia de seguridad y el tiempo de ciclo con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.distanciaSeguridad = form.GetDistanciaSeguridad();
                this.tiempoCiclo = form.GetTiempoCiclo();

            }
        }
        // Comenzar la simulación en Simulador
        private void SimuladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si faltan parametros se avisa al usuario y no se abre el simulador
            if (this.tiempoCiclo <= 0 || this.distanciaSeguridad <= 0)
            {
                MessageBox.Show("Introduce primero la distancia de seguridad y el tiempo de ciclo (Opciones > Parámetros)", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listaVuelos.GetCount() > 0)
            {
                Simulador formSim = new Simulador(listaVuelos, stackVuelos, this.distanciaSeguridad, this.tiempoCiclo);
                formSim.ShowDialog();
            }
            else
            {
                MessageBox.Show("Introduce o carga primero los datos de los vuelos.","Falta de datos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        // Estética
        private void Principal_Paint(object sender, PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }
        // No se puede redimensionar el formulario
        private void Principal_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
