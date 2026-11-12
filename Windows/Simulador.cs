using FlightLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Windows
{
    public partial class Simulador : Form
    {
        private Estilo estilo = new Estilo();
        private FlightPlanList llistaVuelos;
        private double distanciaSeguridad;
        private double tiempoCiclo;
        private bool conflictoRevisado = false; // variable para controlar si ya hemos REVISADO el conflicto inicial
        private bool avisoMostrado = false; // variable para controlar si ya hemos MOSTRADO el aviso de conflicto
        private bool mensajeLlegadaMostrado = false; // variable para controlar si ya hemos MOSTRADO el mensaje de llegada de todos los vuelos

        // Llista de PictureBox per representar tants avions com tinguem
        private List<PictureBox> llistaPictures = new List<PictureBox>();
        private Image imagenAvionOriginal;
        private Stack<FlightPlanList> stackVuelos = new Stack<FlightPlanList>();
        private const int TAM_AVION = 25;

        private double escala = 1; //pixeles por cada unidad de las coordenadas
        private double maxX = 1;
        private double maxY = 1;

        //CONSTRUCTOR
        public Simulador(FlightPlanList vuelos, Stack<FlightPlanList> stack, double distancia, double ciclo)
        {
            InitializeComponent();

            this.llistaVuelos = vuelos;
            this.distanciaSeguridad = distancia;
            this.tiempoCiclo = ciclo;
            this.stackVuelos = stack;
            this.stackVuelos.Clear();


            this.llistaVuelos.RestartAll();
            imagenAvionOriginal = new Bitmap(Properties.Resources.avion);


            Label_Info.Text = "Distancia de Seguridad: " + this.distanciaSeguridad + " | Tiempo ciclo: " + this.tiempoCiclo;

            RevisarConflictoInicial();
            CalcularLimitesMundo();
            CalcularEscala();
            MostrarAvionesIniciales();
        }

        private void MostrarAvionesIniciales()
        {
            llistaPictures.Clear();

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                FlightPlan plan = llistaVuelos.GetFlightPlan(i);

                PictureBox pic = new PictureBox();
                pic.Size = new Size(TAM_AVION, TAM_AVION);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BackColor = Color.Transparent;


                ColocarAvion(pic, plan);

                pictureBox_espacioAereo.Controls.Add(pic);
                pic.BringToFront();

                pic.Cursor = Cursors.Hand;

                pic.Tag = plan; //guardamos el plan de vuelo en la propiedad Tag del PictureBox para poder acceder a él más tarde
                pic.Click += pic_Click; //guardamos el evento click para abrir la ventana de información del vuelo al hacer click en el PictureBox

                llistaPictures.Add(pic);
            }

            pictureBox_espacioAereo.Paint += pictureBox_espacioAereo_Paint;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            //"sender" nos dice qué PictureBox ha sido clicado
            PictureBox picClicada = (PictureBox)sender;

            //recuperamos el plan de vuelo que teníamos guardado en el Tag del PictureBox
            FlightPlan avioSeleccionat = (FlightPlan)picClicada.Tag;

            //abrimos la ventana de información de este avión
            AbrirInfoVuelo(avioSeleccionat);
        }

        private void ColocarAvion(PictureBox pic, FlightPlan plan)
        {
            Position pos = plan.GetCurrentPosition();
            Position destino = plan.GetFinalPosition();

            double dx = destino.GetX() - pos.GetX();
            double dy = destino.GetY() - pos.GetY();

            float angulo = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);

            Bitmap imagenRotada = RotarImagen(imagenAvionOriginal, angulo);

            if (pic.Image != null)
            {
                pic.Image.Dispose();
            }

            pic.Image = imagenRotada;

            int x = (int)pixelPantalla(pos.GetX()) - pic.Width / 2;
            int y = (int)pixelPantalla(pos.GetY()) - pic.Height / 2;

            pic.Location = new Point(x, y);
        }

        private void RevisarConflictoInicial()
        {
            if (conflictoRevisado)
                return; // solo se pregunta la primera vez
            conflictoRevisado = true;

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                for (int j = i + 1; j < llistaVuelos.GetCount(); j++)
                {
                    FlightPlan p1 = llistaVuelos.GetFlightPlan(i);
                    FlightPlan p2 = llistaVuelos.GetFlightPlan(j);

                    if (p1.AnticiparConflicto(p2, distanciaSeguridad, tiempoCiclo))
                    {
                        DialogResult respuesta = MessageBox.Show("Los vuelos " + p1.GetId() + " y " + p2.GetId() + " entrarán en conflicto. ¿Quieres resolverlo?", "Conflicto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            // Bajamos la velocidad del vuelo 2 hasta que no haya conflicto
                            if (p2.ResolverConflicto(p1, distanciaSeguridad, tiempoCiclo))
                            {
                                MessageBox.Show("Conflicto resuelto. Nueva velocidad del vuelo " + p2.GetId() + ": " + p2.GetVelocidad().ToString("F2"));
                            }
                            else
                            {
                                MessageBox.Show("No se ha podido resolver el conflicto entre " + p1.GetId() + " y " + p2.GetId() + ". La simulación continuará igual.");
                            }
                        }
                    }
                }
            }
        }

        //Muestra una alarma con los vuelos que esten en conflicto

        private void button_mover_Click(object sender, EventArgs e)
        {
            RevisarConflictoInicial();

            stackVuelos.Push(llistaVuelos.Clone());
            llistaVuelos.Move(tiempoCiclo);
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                //movemos los dibujos a sus nuevas posiciones
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }
            
            bool hayConflictoGeneral = false;

            string vuelosEnConflicto = "";
            //se guarda la distancia mínima global entre todos los vuelos
            double minDistanciaGlobal = double.MaxValue;

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                for (int j = i + 1; j < llistaVuelos.GetCount(); j++)
                {
                    FlightPlan p1 = llistaVuelos.GetFlightPlan(i);
                    FlightPlan p2 = llistaVuelos.GetFlightPlan(j);

                    double dist = p1.Distance(p2);
                    if (dist < minDistanciaGlobal)
                        minDistanciaGlobal = dist;

                    if (p1.ConflictoDuranteCiclo(p2, distanciaSeguridad, tiempoCiclo))
                    {
                        hayConflictoGeneral = true;
                        vuelosEnConflicto = vuelosEnConflicto + p1.GetId() + " y " + p2.GetId() + "\n";
                        //si decidimos darle que no a solucionar conflicto y simulamos,
                        //en el momento del cruce entre los vuelos que entrarán en conflicto saltará la alarma
                    }
                }
            }

            if (hayConflictoGeneral)
            {
                Label_Conflicto.Text = "¡CONFLICTO! Distancia mín: " + minDistanciaGlobal.ToString("F2");
                Label_Conflicto.ForeColor = Color.Red;
            }

            else
            {
                if (llistaVuelos.GetCount() > 1)
                    Label_Conflicto.Text = "Sin conflicto. Distancia mín: " + minDistanciaGlobal.ToString("F2");
                else
                    Label_Conflicto.Text = "Simulación activa (1 solo vuelo).";

                Label_Conflicto.ForeColor = Color.Green;
                avisoMostrado = false;
            }

            //comprobamos si todos los vuelos han llegado a su destino y desactivamos los botones si es así
            bool todosHanLlegado = true;
            for (int i = 0; i < llistaVuelos.GetCount() && todosHanLlegado; i++)
            {
                //si algún avión no ha llegado, ponemos false
                if (!llistaVuelos.GetFlightPlan(i).HasArrived())
                {
                    todosHanLlegado = false;
                }
            }

            if (todosHanLlegado && llistaVuelos.GetCount() > 0)
            {
                button_auto.Enabled = false;
                button_mover.Enabled = false;
                reloj.Stop();
                if (!mensajeLlegadaMostrado)
                {
                    mensajeLlegadaMostrado = true;
                    MessageBox.Show("¡Todos los vuelos han llegado a su destino!");
                }
            }

            pictureBox_espacioAereo.Invalidate();
        }

        private void pictureBox_espacioAereo_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                FlightPlan plan = llistaVuelos.GetFlightPlan(i);
                Trajectories(plan, e.Graphics);

                Position p = plan.GetCurrentPosition();
                SecurityDistance(e.Graphics, pixelPantalla((float)p.GetX()),pixelPantalla((float)p.GetY()), pixelPantalla((float)distanciaSeguridad/2), plan); //distanciaSeguridad/2 porque el radio es la mitad de la distancia de seguridad
            }
        }

        private void Trajectories(FlightPlan plan, Graphics g)
        {
            using (Pen lapiz = new Pen(Color.White, 1))
            {
                Point initial = new Point((int)pixelPantalla(Convert.ToInt32(plan.GetInitialPosition().GetX())), (int)pixelPantalla(Convert.ToInt32(plan.GetInitialPosition().GetY())));
                Point final = new Point((int)pixelPantalla(Convert.ToInt32(plan.GetFinalPosition().GetX())), (int)pixelPantalla(Convert.ToInt32(plan.GetFinalPosition().GetY())));
                g.DrawLine(lapiz, initial, final);
            }
        }
        private void SecurityDistance(Graphics g, float centroX, float centroY, float radio, FlightPlan avionActual)
        {
            bool problems = false;
            int i = 0;

            while (i < llistaVuelos.GetCount())
            {
                FlightPlan otro = llistaVuelos.GetFlightPlan(i);
                if (avionActual != otro && avionActual.Conflicto(otro, this.distanciaSeguridad))
                {
                    problems = true;
                }
                i++;
            }
            if (problems)
            {
                using (Pen lapiz = new Pen(Color.Red, 2))
                {
                    g.DrawEllipse(lapiz, centroX - radio, centroY - radio, radio * 2, radio * 2);
                }
            }
            else
            {
                using (Pen lapiz = new Pen(Color.LimeGreen, 1))
                {
                    g.DrawEllipse(lapiz, centroX - radio, centroY - radio, radio * 2, radio * 2);
                }
            }
        }

        private void AbrirInfoVuelo(FlightPlan plan)
        {
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            InfoVuelo info = new InfoVuelo(plan);
            if (info.ShowDialog() == DialogResult.OK)
            {
                ReiniciarSimulacion();
                conflictoRevisado = true;
                ComprobarNuevasVelocidades();

            }

            else if(estabaEnAutomatico)
            {
                reloj.Start();
            }
        }

        private void button_auto_Click(object sender, EventArgs e)
        {
            if (button_auto.Text == "Automatico")
            {
                RevisarConflictoInicial(); //Comprobamos si hay conflicto antes de mover los aviones
                button_auto.Text = "Parar";
                button_mover.Enabled = false; //where  Enabled = false pone el boton en gris para que no se pueda clicar sobre él.
                reloj.Interval = 100;
                reloj.Start();
            }
            else
            {
                button_auto.Text = "Automatico";
                button_mover.Enabled = true; //where  Enabled = true pone el boton en color para que se pueda clicar sobre él.
                reloj.Stop();
            }
        }

 
        private void reloj_Tick(object sender, EventArgs e)
        {
            //exactamente lo mismo que hacer click en el boton mover, es decir, movemos los aviones y comprobamos si hay conflicto
            button_mover_Click(sender, e);
        }

        private void button_conflicto_Click(object sender, EventArgs e)
        {
            //Si la simulacion automatica esta en marcha, la pausamos mientras preguntamos
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            bool hayConflictoFuturo = false;
            int i = 0;
            while (i < llistaVuelos.GetCount())
            {
                int j = i + 1;
                while (j < llistaVuelos.GetCount())
                {
                    if (llistaVuelos.GetFlightPlan(i).AnticiparConflicto(llistaVuelos.GetFlightPlan(j), distanciaSeguridad, tiempoCiclo))
                    {
                        hayConflictoFuturo = true;
                    }
                    j++;
                }
                i++;
            }

            if (hayConflictoFuturo)
            {
                MessageBox.Show("¡ATENCIÓN! Si mantienen su velocidad, algunos vuelos entrarán en conflicto.", "Anticipar conflicto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Ningún vuelo entrará en conflicto con las velocidades actuales.", "Anticipar conflicto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Si estaba en automatico, seguimos
            if (estabaEnAutomatico)
                reloj.Start();

        }

        private void button_datos_Click(object sender, EventArgs e)
        {
            // Pausamos la simulacion automatica mientras miramos los datos (igual que en button2_Click)
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            DatosVuelos form = new DatosVuelos(llistaVuelos);
            form.ShowDialog();

            // Si estaba en automatico, seguimos
            if (estabaEnAutomatico)
                reloj.Start();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            ReiniciarSimulacion();
            conflictoRevisado = false;
            RevisarConflictoInicial();

        }

        private void ReiniciarSimulacion()
        {
            reloj.Stop();

            llistaVuelos.RestartAll();

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }

            button_auto.Text = "Automatico";
            button_auto.Enabled = true;
            button_mover.Enabled = true;

            avisoMostrado = false;
            Label_Conflicto.Text = "Simulación reiniciada. Pulsa \"Mover\" o \"Automatico\".";
            Label_Conflicto.ForeColor = Color.Blue;

            pictureBox_espacioAereo.Invalidate(); //redibuja trayectorias y circulos


        }
        
        //Comprobamos si el cambio de velocidad elimina el conflicto
        private void ComprobarNuevasVelocidades()
        {
            double dminGlobal = double.MaxValue;
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                for (int j = i + 1; j < llistaVuelos.GetCount(); j++)
                {
                    double dmin = llistaVuelos.GetFlightPlan(i).DistanciaMinima(llistaVuelos.GetFlightPlan(j), double.PositiveInfinity);
                    if (dmin < dminGlobal)
                        dminGlobal = dmin;
                }
            }

            if (llistaVuelos.GetCount() > 1 && dminGlobal < distanciaSeguridad)
            {
                MessageBox.Show("Con las nuevas velocidades TODAVÍA habrá conflicto. Distancia mínima prevista: " + dminGlobal.ToString("F2") + " (seguridad: " + distanciaSeguridad + ")", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Con las nuevas velocidades ya no habrá conflicto. Distancia Mínima prevista: " + dminGlobal.ToString("F2") + " (seguridad: " + distanciaSeguridad + ")", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        // Guardar estado actual de la simulación en un fichero en cualquier momento de la simulación (última posición de los vuelos)
        private void button_estadoActual_Click(object sender, EventArgs e)
        {
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt)|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //para guardar el estado actual de la simulación
                    FlightPlanList llistaTemporal = new FlightPlanList();

                    for (int i = 0; i < llistaVuelos.GetCount(); i++)
                    {
                        FlightPlan planOriginal = llistaVuelos.GetFlightPlan(i);
                        //cogemos los datos del plan original para crear un nuevo FlightPlan con la posición actual como punto de inicio
                        string id = planOriginal.GetId();
                        double xActual = planOriginal.GetCurrentPosition().GetX();
                        double yActual = planOriginal.GetCurrentPosition().GetY();
                        double xFinal = planOriginal.GetFinalPosition().GetX();
                        double yFinal = planOriginal.GetFinalPosition().GetY();
                        double velocitat = planOriginal.GetVelocidad();
                        string companyia = planOriginal.GetCompany();

                        FlightPlan planActualitzat = new FlightPlan(id, xActual, yActual, xFinal, yFinal, velocitat, companyia);

                        llistaTemporal.AddFlightPlan(planActualitzat);
                    }

                    llistaTemporal.GuardarEnFichero(saveFile.FileName);

                    MessageBox.Show("¡Estado de la simulación guardado correctamente en la última posición!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al guardar el fichero");
                }
            }

            if (estabaEnAutomatico)
                reloj.Start();
        }

        private void CalcularLimitesMundo()
        {
            maxX = 1;
            maxY = 1;
            for(int i = 0; i< llistaVuelos.GetCount(); i++)
            {
                FlightPlan plan = llistaVuelos.GetFlightPlan(i);
                maxX = Math.Max(maxX, Math.Max(plan.GetInitialPosition().GetX(), plan.GetFinalPosition().GetX()));
                maxY = Math.Max(maxY, Math.Max(plan.GetInitialPosition().GetY(), plan.GetFinalPosition().GetY()));
            }
            maxX = maxX + 30; //margen para que los aviones del borde no queden cortados
            maxY = maxY + 30;
        }

        private void CalcularEscala() //calcularemos cuantos pixeles corresponden a cada unidad, segun el tamaño actual de nuestro espacio aereo
        {
            double escalaX = pictureBox_espacioAereo.Width / maxX;
            double escalaY = pictureBox_espacioAereo.Height / maxY;
            escala = Math.Min(escalaX, escalaY); //la escala menor para que quepa tanto a lo ancho como largo
        }

        //Convierte una coordenada de nuestro espacio aereo en pixeles de pantalla
        private float pixelPantalla(double coordenada)
        {
            return (float)(coordenada * escala); //la coordenada dvuelve la posicion en pixeles funcionando como parametro
        }
        
        private void Simulador_Resize(object sender, EventArgs e)
        {
            CalcularEscala();
            for(int i = 0; i < llistaPictures.Count; i++)
            {
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }
            this.Invalidate();
            pictureBox_espacioAereo.Invalidate();
        }

        private void Simulador_Paint(object sender, PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_deshacer_Click(object sender, EventArgs e)
        {
            if (stackVuelos.Count == 0)
            {
                return;
            }

            FlightPlanList estadoAnterior = stackVuelos.Pop();
            llistaVuelos.RestoreFrom(estadoAnterior);

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                ColocarAvion(
                    llistaPictures[i],
                    llistaVuelos.GetFlightPlan(i));
            }

            pictureBox_espacioAereo.Invalidate();
        }
        private Bitmap RotarImagen(Image imagen, float angulo)
        {
            Bitmap resultado = new Bitmap(imagen.Width, imagen.Height);

            using (Graphics g = Graphics.FromImage(resultado))
            {
                g.TranslateTransform(imagen.Width / 2f, imagen.Height / 2f);
                g.RotateTransform(angulo);
                g.TranslateTransform(-imagen.Width / 2f, -imagen.Height / 2f);

                g.DrawImage(imagen, new Point(0, 0));
            }

            return resultado;
        }
    }
}
