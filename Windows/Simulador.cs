using FlightLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Windows
{
    public partial class Simulador : Form
    {
        private FlightPlan plan1;
        private FlightPlan plan2;
        private double distanciaSeguridad;
        private double tiempoCiclo;

        
        public Simulador(FlightPlan plan1, FlightPlan plan2, double distancia, double ciclo)
        {
            InitializeComponent();

            this.plan1 = plan1;
            this.plan2 = plan2;
            this.distanciaSeguridad = distancia;
            this.tiempoCiclo = ciclo;

            
            this.plan1.Restart();
            this.plan2.Restart();

          
            label_info.Text = "Distancia de Seguridad: " + this.distanciaSeguridad + " | Tiempo ciclo: " + this.tiempoCiclo;

            MostrarAvionesIniciales();
        }

        private void MostrarAvionesIniciales()
        {
            Position pos1 = plan1.GetInitialPosition(); 

            PictureBox pic1 = new PictureBox();
            pic1.Size = new Size(25, 25); 
            pic1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pic1.Image = new Bitmap("avion2D.png");
            }
            catch (Exception)
            {
                pic1.BackColor = Color.Blue;
            }

            int x1 = (int)pos1.GetX();
            int y1 = (int)pos1.GetY();
            pic1.Location = new Point(x1, y1);

            pictureBox_espacioAereo.Controls.Add(pic1);
            pic1.BringToFront();

            Position pos2 = plan2.GetInitialPosition(); 

            PictureBox pic2 = new PictureBox();
            pic2.Size = new Size(25, 25);
            pic2.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pic2.Image = new Bitmap("avion2D.png");
            }
            catch (Exception)
            {
                pic2.BackColor = Color.Red;
            }

            int x2 = (int)pos2.GetX();
            int y2 = (int)pos2.GetY();
            pic2.Location = new Point(x2, y2);

            pictureBox_espacioAereo.Controls.Add(pic2);
            pic2.BringToFront();
        }
    }
}