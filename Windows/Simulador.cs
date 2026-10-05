using FlightLib;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Windows
{
    public partial class Simulador : Form
    {
        private FlightPlan plan1;
        private FlightPlan plan2;
        private double distanciaSeguridad;
        private double tiempoCiclo;

        //dibujo de los aviones como atributos de la clase Simulador
        private PictureBox pic1;
        private PictureBox pic2;
        private const int TAM_AVION = 25;

        //CONSTRUCTOR


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

            pic1 = new PictureBox();
            pic1.Size = new Size(25, 25);
            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic1.BackColor = Color.Transparent;


            try
            {
                pic1.Image = new Bitmap("avion2D.png");
            }
            catch (Exception)
            {
                pic1.BackColor = Color.Blue;
            }

            ColocarAvion(pic1, plan1);

            pictureBox_espacioAereo.Controls.Add(pic1);
            pic1.BringToFront();

            pic1.Cursor = Cursors.Hand; //la manita cuando se pasa el raton por encima
            pic1.Click += pic1_Click;

            Position pos2 = plan2.GetInitialPosition();

            pic2 = new PictureBox();
            pic2.Size = new Size(25, 25);
            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
            pic2.BackColor = Color.Transparent;


            try
            {
                pic2.Image = new Bitmap("avion2D.png");
            }
            catch (Exception)
            {
                pic2.BackColor = Color.Red;
            }

            ColocarAvion(pic2, plan2);

            pictureBox_espacioAereo.Controls.Add(pic2);
            pic2.BringToFront();

            pic2.Cursor = Cursors.Hand;//la manita cuando se pasa el raton por encima
            pic2.Click += pic2_Click; //cuando se hace click en pic2, ejecuta el pic2_Click

            pictureBox_espacioAereo.Paint += pictureBox_espacioAereo_Paint;
        }

        private void ColocarAvion(PictureBox pic, FlightPlan plan)
        {
            Position pos = plan.GetCurrentPosition();

            //Restamos la mitad del tamañno del avión para centrarlo en la posición
            int x = (int)pos.GetX() - TAM_AVION / 2;
            int y = (int)pos.GetY() - TAM_AVION / 2;
            pic.Location = new Point(x, y);
        }

        private void button_mover_Click(object sender, EventArgs e)
        {

            //1. Moveremos los aviones en el plan de vuelo con los calculos de FlightLib
            plan1.Move(tiempoCiclo);
            plan2.Move(tiempoCiclo);

            //2. Movemos los dibujos a sus nuevas posiciones
            ColocarAvion(pic1, plan1);
            ColocarAvion(pic2, plan2);

            //3. Comprobaremos si hay conflicto entre los aviones
            Conflictolabel.BackColor = Color.Beige;

            if (plan1.Conflicto(plan2, distanciaSeguridad))
            {
                Conflictolabel.Text = "¡CONFLICTO! Distancias:" + plan1.Distance(plan2).ToString("F2"); //where ToString("F2") muestra dos decimales

                Conflictolabel.ForeColor = Color.Red;

            }

            else
            {
                Conflictolabel.Text = "Sin conflicto. Distancia:" + plan1.Distance(plan2).ToString("F2");
                Conflictolabel.ForeColor = Color.Green;
            }


            //4. Si los aviones han llegado a su destino terminamos la simulacion

            if (plan1.HasArrived() && plan2.HasArrived())
            {
                button_mover.Enabled = false; //where  Enabled = false pone el boton en gris para que no se pueda clicar sobre él.
                MessageBox.Show("¡Los dos vuelos han llegado a su destino! ✈️ ");
            }

            pictureBox_espacioAereo.Invalidate();
        }

        private void pictureBox_espacioAereo_Paint(object sender, PaintEventArgs e)
        {
            Trajectories(plan1, e.Graphics);
            Trajectories(plan2, e.Graphics);

            Position p1 = plan1.GetCurrentPosition();
            Position p2 = plan2.GetCurrentPosition();

            SecurityDistance(e.Graphics, (float)p1.GetX(), (float)p1.GetY(), (float)distanciaSeguridad/2);
            SecurityDistance(e.Graphics, (float)p2.GetX(), (float)p2.GetY(), (float)distanciaSeguridad/2);
        }

        private void Trajectories(FlightPlan plan, Graphics g)
        {
            using (Pen lapiz = new Pen(Color.White, 1))
            {
                Point initial = new Point(Convert.ToInt32(plan.GetInitialPosition().GetX()), Convert.ToInt32(plan.GetInitialPosition().GetY()));
                Point final = new Point(Convert.ToInt32(plan.GetFinalPosition().GetX()), Convert.ToInt32(plan.GetFinalPosition().GetY()));
                g.DrawLine(lapiz, initial, final);
            }
        }
        private void SecurityDistance(Graphics g, float centroX, float centroY, float radio)
        {
            bool problems = plan1.Conflicto(plan2, this.distanciaSeguridad);
            
            if (problems)
            {
                using (Pen lapiz = new Pen(Color.Red, 2))
                {
                    g.DrawEllipse(lapiz, centroX - radio, centroY - radio, radio * 2, radio * 2);
                }
            }
            else
            {
                using (Pen lapiz = new Pen(Color.White, 1))
                {
                    g.DrawEllipse(lapiz, centroX - radio, centroY - radio, radio * 2, radio * 2);
                }
            }
        }


        private void pic1_Click(object sender, EventArgs e)
        {
            InfoVuelo info = new InfoVuelo(plan1);
            info.ShowDialog();
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            InfoVuelo info = new InfoVuelo(plan2);
            info.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Automatico")
            {
                button1.Text = "Parar";
                reloj.Interval = 100;
                reloj.Start();
            }
            else
            {
                button1.Text = "Automatico";
                reloj.Stop();
            }
        }

 
        private void reloj_Tick(object sender, EventArgs e)
        {
            plan1.Move(tiempoCiclo);
            plan2.Move(tiempoCiclo);
            ColocarAvion(pic1, plan1);
            ColocarAvion(pic2, plan2);


            Conflictolabel.BackColor = Color.Beige;

            if (plan1.Conflicto(plan2, distanciaSeguridad))
            {
                Conflictolabel.Text = "¡CONFLICTO! Distancias:" + plan1.Distance(plan2).ToString("F2"); //where ToString("F2") muestra dos decimales

                Conflictolabel.ForeColor = Color.Red;

            }

            else
            {
                Conflictolabel.Text = "Sin conflicto. Distancia:" + plan1.Distance(plan2).ToString("F2");
                Conflictolabel.ForeColor = Color.Green;
            }


            //4. Si los aviones han llegado a su destino terminamos la simulacion

            if (plan1.HasArrived() && plan2.HasArrived())
            {
                button_mover.Enabled = false; //where  Enabled = false pone el boton en gris para que no se pueda clicar sobre él.
                MessageBox.Show("¡Los dos vuelos han llegado a su destino! ✈️ ");
            }

            pictureBox_espacioAereo.Invalidate();
        }
    }

       
    }
