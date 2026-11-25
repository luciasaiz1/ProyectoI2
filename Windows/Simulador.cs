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
        // ATRIBUTOS
        private Estilo estilo = new Estilo();
        private FlightPlanList llistaVuelos;
        private double distanciaSeguridad;
        private double tiempoCiclo;
        private bool conflictoRevisado = false; 
        private bool mensajeLlegadaMostrado = false; 
        private List<PictureBox> llistaPictures = new List<PictureBox>();
        private Image imagenAvionOriginal;
        private Stack<FlightPlanList> stackVuelos = new Stack<FlightPlanList>();
        private const int TAM_AVION = 25;
        private bool mostrarIds = false;
        private double escala = 1;
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

        // MÉTODOS
        // Comuniacaión entre forms
        // Abre la ventana de información del vuelo al hacer click en el avión 
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox picClicada = (PictureBox)sender;
            FlightPlan avioSeleccionat = (FlightPlan)picClicada.Tag;
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            InfoVuelo info = new InfoVuelo(avioSeleccionat);
            if (info.ShowDialog() == DialogResult.OK)
            {
                conflictoRevisado = true;
                ComprobarNuevasVelocidades();
            }

            else if (estabaEnAutomatico)
            {
                reloj.Start();
            }
        }

        // Estética
        private void Simulador_Paint(object sender, PaintEventArgs e)
        {
            estilo.PintarFondo(e.Graphics, this.ClientRectangle);
        }
        // Tamaño de la simulación
        private void CalcularLimitesMundo()
        {
            maxX = 1;
            maxY = 1;
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                FlightPlan plan = llistaVuelos.GetFlightPlan(i);
                maxX = Math.Max(maxX, Math.Max(plan.GetInitialPosition().GetX(), plan.GetFinalPosition().GetX()));
                maxY = Math.Max(maxY, Math.Max(plan.GetInitialPosition().GetY(), plan.GetFinalPosition().GetY()));
            }
            maxX = maxX + 30; // Margen para que los aviones del borde no queden cortados
            maxY = maxY + 30;
        }
        // Calcula la escala de la simulación según el tamaño del espacio aéreo
        private void CalcularEscala()
        {
            double escalaX = pictureBox_espacioAereo.Width / maxX;
            double escalaY = pictureBox_espacioAereo.Height / maxY;
            escala = Math.Min(escalaX, escalaY);
        }
        // Convierte una coordenada en píxeles de pantalla
        private float pixelPantalla(double coordenada)
        {
            return (float)(coordenada * escala); // Devuelve la posición en pixeles funcionando como parámetro
        }
        // Recalcula la escala si cambiamos el tamaño de la ventana
        private void Simulador_Resize(object sender, EventArgs e)
        {
            CalcularEscala();
            for (int i = 0; i < llistaPictures.Count; i++)
            {
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }
            this.Invalidate();
            pictureBox_espacioAereo.Invalidate();
        }
        // Rota la imagen del avión según la dirección del vuelo
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
        // Coloca el avión en la posición actual del vuelo
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
        // Dibuja la trayectoria de un vuelo en el espacio aéreo
        private void Trajectories(FlightPlan plan, Graphics g)
        {
            using (Pen lapiz = new Pen(Color.White, 1))
            {
                Point initial = new Point((int)pixelPantalla(Convert.ToInt32(plan.GetInitialPosition().GetX())), (int)pixelPantalla(Convert.ToInt32(plan.GetInitialPosition().GetY())));
                Point final = new Point((int)pixelPantalla(Convert.ToInt32(plan.GetFinalPosition().GetX())), (int)pixelPantalla(Convert.ToInt32(plan.GetFinalPosition().GetY())));
                g.DrawLine(lapiz, initial, final);
            }
        }
        // Dibuja un círculo alrededor del avión actual para indicar la distancia de seguridad y cambia el color si hay conflicto
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
        // Dibuja en la PictureBox lo anterior 
        private void pictureBox_espacioAereo_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                FlightPlan plan = llistaVuelos.GetFlightPlan(i);
                Trajectories(plan, e.Graphics);

                Position p = plan.GetCurrentPosition();
                SecurityDistance(e.Graphics, pixelPantalla((float)p.GetX()), pixelPantalla((float)p.GetY()), pixelPantalla((float)(distanciaSeguridad) / 2), plan); //distanciaSeguridad/2 porque el radio es la mitad de la distancia de seguridad 

                if (mostrarIds)
                {
                    string id = plan.GetId();
                    SizeF tamTexto = e.Graphics.MeasureString(id, this.Font);

                    float x = pixelPantalla(p.GetX()) - tamTexto.Width / 2;
                    float y = pixelPantalla(p.GetY()) - TAM_AVION / 2f - tamTexto.Height;

                    e.Graphics.DrawString(id, this.Font, Brushes.White, x, y);
                }
            }
        }
        private void button_IDs_Click(object sender, EventArgs e)
        {
            mostrarIds = !mostrarIds;
            if (mostrarIds)
            {
                button_IDs.Text = "Ocultar IDs";
            }
            else
            {
                button_IDs.Text = "Mostrar IDs";
            }
            pictureBox_espacioAereo.Invalidate();
        }
        // Muestra los aviones en su posición inicial y los dibuja en el espacio aéreo
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

                pic.Tag = plan; // Guardamos el plan de vuelo en la propiedad Tag del PictureBox para poder acceder a él más tarde
                pic.Click += pic_Click; // Guardamos el evento click para abrir la ventana de información del vuelo al hacer click en el PictureBox

                llistaPictures.Add(pic);
            }
            pictureBox_espacioAereo.Paint += pictureBox_espacioAereo_Paint;
        }
        // Cambia el label de conflicto según la distancia mínima entre vuelos y si hay conflicto o no
        private void DistanciasLabel()
        {
            bool hayConflictoGeneral = false;
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

                    // Usamos Conflicto() en lugar de la matriz con tiempoCiclo
                    if (p1.Conflicto(p2, distanciaSeguridad))
                    {
                        hayConflictoGeneral = true;
                    }
                }
            }

            if (hayConflictoGeneral)
            {
                Label_Conflicto.Text = "¡CONFLICTO! Distancia mínima: " + minDistanciaGlobal.ToString("F2");
                Label_Conflicto.ForeColor = Color.Red;
            }
            else
            {
                if (llistaVuelos.GetCount() > 1)
                {
                    Label_Conflicto.Text = "Sin conflicto. Distancia mínima: " + minDistanciaGlobal.ToString("F2");

                }
                else
                {
                    Label_Conflicto.Text = "Simulación activa (1 solo vuelo)";
                }
                Label_Conflicto.ForeColor = Color.Green;
            }
        }

        // Funciones relevantes antes de los movimientos
        // Devuelve un string con los vuelos que entrarán en conflicto según la matriz de conflictos
        private string ObtenerTextoConflictos(bool[,] matriz)
        {
            string vuelosEnConflicto = "";

            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                for (int j = i + 1; j < llistaVuelos.GetCount(); j++)
                {
                    if (matriz[i, j])
                    {
                        vuelosEnConflicto += llistaVuelos.GetFlightPlan(i).GetId()+ " y " + llistaVuelos.GetFlightPlan(j).GetId() + "\n";
                    }
                }
            }
            return vuelosEnConflicto;
        }
        // Revisar si hay conflicto 
        private void RevisarConflictoInicial()
        {
            if (conflictoRevisado)
            {
                return; // Solo se pregunta la primera vez
            }
            conflictoRevisado = true;

            bool[,] matriz = llistaVuelos.ObtenerMatrizConflictos(distanciaSeguridad, double.PositiveInfinity);
            string vuelosEnConflicto = ObtenerTextoConflictos(matriz);

            if (vuelosEnConflicto == "")
            {
                return; // No hay conflictos, no se muestra ningún mensaje
            }

            DialogResult respuesta = MessageBox.Show("Los siguientes vuelos entrarán en conflicto:\n\n" + vuelosEnConflicto + "\n¿Quieres resolverlos?","Conflictos",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                if (llistaVuelos.ResolverConflictos(distanciaSeguridad, tiempoCiclo))
                {
                    MessageBox.Show("Todos los conflictos se han resuelto.", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se han podido resolver todos los conflictos. La simulación continuará igual.", "Conflictos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

        // Movimiento de los aviones
        // Mueve los aviones según el tiempo de ciclo y actualiza la posición de los PictureBox
        private void button_mover_Click(object sender, EventArgs e)
        {
            RevisarConflictoInicial();

            stackVuelos.Push(llistaVuelos.Clone());
            llistaVuelos.Move(tiempoCiclo);
            for (int i = 0; i < llistaVuelos.GetCount(); i++)
            {
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }
            DistanciasLabel();

            // Comprobamos si todos los vuelos han llegado a su destino y desactivamos los botones si es así
            bool todosHanLlegado = true;
            for (int i = 0; i < llistaVuelos.GetCount() && todosHanLlegado; i++)
            {
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
                    MessageBox.Show("¡Todos los vuelos han llegado a su destino!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            pictureBox_espacioAereo.Invalidate();
        }
        // Mueve los aviones cada tick
        private void reloj_Tick(object sender, EventArgs e)
        {
            button_mover_Click(sender, e);
        }
        // Mueve los aviones automáticamente cada tiempo de ciclo
        private void button_auto_Click(object sender, EventArgs e)
        {
            if (button_auto.Text == "Automático")
            {
                RevisarConflictoInicial(); // Comprobamos si hay conflicto antes de mover los aviones
                button_auto.Text = "Parar";
                button_mover.Enabled = false;
                reloj.Interval = 100;
                reloj.Start();
            }
            else
            {
                button_auto.Text = "Automático";
                button_mover.Enabled = true; 
                reloj.Stop();
            }
        }
        // Deshacer el último movimiento de los aviones
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
                ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
            }

            button_auto.Enabled = true;
            button_auto.Text = "Automático";
            button_mover.Enabled = true;

            DistanciasLabel();
            pictureBox_espacioAereo.Invalidate();
        }

        // Otros botones
        // Pregunta si hay conflicto y ofrece solucionarlo 
        private void button_conflicto_Click(object sender, EventArgs e)
        {
            //Si la simulacion automática esta en marcha, la pausamos mientras preguntamos
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            bool[,] matriz = llistaVuelos.ObtenerMatrizConflictos(distanciaSeguridad, double.PositiveInfinity);
            bool hayConflictoFuturo = ObtenerTextoConflictos(matriz) != "";

            if (hayConflictoFuturo)
            {
                MessageBox.Show("¡ATENCIÓN! Si mantienen su velocidad, algunos vuelos entrarán en conflicto.", "Anticipar conflicto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conflictoRevisado = false;
                RevisarConflictoInicial();
            }
            else
            {
                MessageBox.Show("Ningún vuelo entrará en conflicto con las velocidades actuales.", "Anticipar conflicto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Si estaba en automático, seguimos
            if (estabaEnAutomatico)
            {
                reloj.Start();
            }
        }
        // Muestra los datos de los vuelos en un DataGridView
        private void button_datos_Click(object sender, EventArgs e)
        {
            // Pausamos la simulacion automatica mientras miramos los datos
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            DatosVuelos form = new DatosVuelos(llistaVuelos);
            form.ShowDialog();

            // Si estaba en automático, seguimos
            if (estabaEnAutomatico)
            {
                reloj.Start();
            }
        }
        private void button_compañias_Click(object sender, EventArgs e)
        {
            bool estabaEnAutomatico = reloj.Enabled;
            reloj.Stop();

            DatosCompañias form = new DatosCompañias(llistaVuelos);
            form.ShowDialog();

            // Si estaba en automático, seguimos
            if (estabaEnAutomatico)
            {
                reloj.Start();
            }
        }
        // Resetea la simulación a su estado inicial
        private void button_reset_Click(object sender, EventArgs e)
        {
            reloj.Stop();

            DialogResult result = MessageBox.Show("Estás seguro de que quieres reiniciar la simulación? (Perderás todos los cambios aplicados)","Reiniciar simulación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                reloj.Start();
                return;
            }
            else
            {
                llistaVuelos.RestartAll();

                for (int i = 0; i < llistaVuelos.GetCount(); i++)
                {
                    ColocarAvion(llistaPictures[i], llistaVuelos.GetFlightPlan(i));
                }

                button_auto.Text = "Automático";
                button_auto.Enabled = true;
                button_mover.Enabled = true;

                Label_Conflicto.Text = "Simulación reiniciada. Pulsa \"Mover\" o \"Automático\".";
                Label_Conflicto.ForeColor = Color.FromArgb(11, 25, 44);

                pictureBox_espacioAereo.Invalidate();
                conflictoRevisado = false;
                RevisarConflictoInicial();
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
                    // Guardar el estado actual de la simulación
                    FlightPlanList llistaTemporal = new FlightPlanList();

                    for (int i = 0; i < llistaVuelos.GetCount(); i++)
                    {
                        // Cogemos los datos del plan original para crear un nuevo FlightPlan con la posición actual como punto de inicio
                        FlightPlan planOriginal = llistaVuelos.GetFlightPlan(i);
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

        // Cierra el simulador
        private void button_volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
