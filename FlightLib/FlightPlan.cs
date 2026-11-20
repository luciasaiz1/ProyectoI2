using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // ATRIBUTOS
        Position initialPosition; 
        Position currentPosition; 
        Position finalPosition; 
        double velocidad;
        double initialvelocidad;
        string company;
        string id;

        // CONSTRUCTOR
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, string company)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.initialvelocidad = velocidad;
            this.company = company;
        }

        // MÉTODOS
        // Getters y Setters
        public void SetId(string id)
        {
            this.id = id;
        }

        public string GetId()
        {
            return this.id;
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        public Position GetInitialPosition()
        {
            return this.initialPosition;
        }

        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition=currentPosition;
        }

        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }

        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        public Position GetFinalPosition()
        {
            return this.finalPosition;
        }

        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }

        public double GetVelocidad()
        {
            return this.velocidad;
        }

        public void SetCompany(string company)
        {
            this.company = company;
        }
        public string GetCompany()
        {
            return this.company;
        }

        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        public void Move(double tiempo)
        {

            if (this.HasArrived()) // Si el avión ya llegó a su destino no se mueve

            {
                return;
            }

            double distancia = tiempo * this.velocidad / 60; // Calculamos la distancia recorrida en el tiempo dado


            // Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            // Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;


            // Comprobamos si ha llegado al destino o no
            Position nextPosition = new Position(x, y);
            if (currentPosition.Distancia(nextPosition) < hipotenusa)
            {
                currentPosition = nextPosition;

            }
            else
            {
                currentPosition = finalPosition;
            }
        }

        // Si ha llegado al destino devuelve true, si no, devuelve false
        public bool HasArrived()
        {
            return this.currentPosition.Distancia(this.finalPosition) < 0.0001;
        }


        // Devuelve true si la distancia entre los vuelos es menor que la distancia de seguridad
        public bool Conflicto(FlightPlan b, double DistanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < DistanciaSeguridad)
                conflicto = true;
            
            return conflicto;
        }

        public void Restart()
        {
            //mueve el avión a la posición inicial
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
            this.velocidad = this.initialvelocidad;
        }

        public double Distance(FlightPlan plan)
        {
            //devuelve la distancia con el plan de vuelo recibido como argumento
            double distance = this.currentPosition.Distancia(plan.GetCurrentPosition());
            return distance;
        }


        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);

            // 2 DECIMALES
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
            {
                Console.WriteLine("Ha llegado al destino");
            }
        }
        public FlightPlan Clone()
        {
            FlightPlan copia = new FlightPlan(
                this.id,
                this.initialPosition.GetX(),
                this.initialPosition.GetY(),
                this.finalPosition.GetX(),
                this.finalPosition.GetY(),
                this.velocidad,
                this.company);

            copia.SetCurrentPosition(new Position(
                this.currentPosition.GetX(),
                this.currentPosition.GetY()));

            return copia;
        }

        // MÉTODOS PARA ANTICIPAR CONFLICTO (Calcula la fórmula de la distancia entre aviones en funcion del tiempo y busca su minimo con la derivada)
        // Tiempo que le falta a este vuelo para llegar a su destino (en minutos). Si ya ha llegado, devuelve 0. Si la velocidad es 0, devuelve 0.
        private double TiempoHastaDestino()
        {
            if (this.HasArrived() || this.velocidad <= 0)
                return 0;
            double distanciaRestante = this.currentPosition.Distancia(this.finalPosition);
            double velocidadPorUnidadTiempo = this.velocidad / 60; //igual que en mover
            return distanciaRestante / velocidadPorUnidadTiempo;
        }

        // Componente X del vector velocidad (0 si el avion está quieto). Devuelve la velocidad en unidades de distancia por minuto.
        private double VelocidadX()
        {
            if (this.TiempoHastaDestino() == 0)
                return 0;

            double distanciasRestante = this.currentPosition.Distancia(this.finalPosition);
            double coseno = (this.finalPosition.GetX() - this.currentPosition.GetX()) / distanciasRestante;
            return (this.velocidad / 60) * coseno;
        }

        // Componente Y del vector velocidad. Devuelve la velocidad en unidades de distancia por minuto.
        private double VelocidadY()
        {
            if (this.TiempoHastaDestino() == 0)
                return 0;

            double distanciasRestante = this.currentPosition.Distancia(this.finalPosition);
            double seno = (this.finalPosition.GetY() - this.currentPosition.GetY()) / distanciasRestante;
            return (this.velocidad / 60) * seno;
        }
        
        // Calcula la distancia mínima entre dos móviles en movimiento rectilíneo uniforme dentro de un intervalo
        // Parámetros:
        //   d0x, d0y: componentes de la posición relativa inicial (B - A)
        //   wx, wy: componentes de la velocidad relativa (vB - vA)
        //   duracion: duración máxima del intervalo de observación
        // Devuelve la menor distancia alcanzada durante el intervalo [0, duracion]
        private double DistanciaMinimaEnIntervalo(double d0x, double d0y, double wx, double wy, double duracion)
        {
            // (d0x, d0y) = posicion relativa al principio del intervalo (B-A)
            //(wx,wy) = velocidad relativa

            double w2 = wx * wx + wy * wy;
            double t = 0; //si la velocidad relativa es cero, la distancia no cambio, miramos t= 0.

            if (w2 > 0)
            {
                t = -(d0x * wx + d0y * wy) / w2; // Instante de mínimo acercamiento obtenido igualando a cero la derivada de d^2(t)

                if (t < 0)
                    t = 0;
                if (t > duracion)
                    t = duracion; //el momento mas cercano seria despues del intervalo

            }

            double dx = d0x + wx * t;
            double dy = d0y + wy * t;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        // Distancia mínima entre vuelo y el vuelo "b" desde ahora hasta "horizonte" unidades de tiempo.
        public double DistanciaMinima(FlightPlan b, double horizonte)
            {
                // Datos de cada avión
                double vax = this.VelocidadX();
                double vay = this.VelocidadY();
                double vbx = b.VelocidadX();
                double vby = b.VelocidadY();
                double tA = this.TiempoHastaDestino();
                double tB = b.TiempoHastaDestino();

                // Fase 1: Los dos aviones vuelan (hasta que aterriza el primero o se alcanza el horizonte)
                double T = Math.Min(tA, tB);
                if (T > horizonte)
                    T = horizonte;

                double d0x = b.currentPosition.GetX() - this.currentPosition.GetX();
                double d0y = b.currentPosition.GetY() - this.currentPosition.GetY();

                double minimo = DistanciaMinimaEnIntervalo(d0x, d0y, vbx - vax, vby - vay, T);

                // Fase 2: El primero ya ha llegado y el otro sigue
                double duracion2 = Math.Max(tA, tB) - T;
                if (T + duracion2 > horizonte)
                    duracion2 = horizonte - T;

                if (duracion2 > 0)
                {
                    // Posiciones de los dos aviones en el instante T
                    double ax = this.currentPosition.GetX() + vax * T;
                    double ay = this.currentPosition.GetY() + vay * T;
                    double bx = b.currentPosition.GetX() + vbx * T;
                    double by = b.currentPosition.GetY() + vby * T;

                    //Ahora solo se mueve el que todavía no ha llegado
                    double wx, wy;
                    if(tA > tB)
                    {
                        wx = -vax; //se mueve A, B esta quieto -> velocidad relativa = 0 - va
                        wy = -vay;
                    }
                    else
                    {
                        wx = vbx; //se mueve B, A esta queito -> velocidad relativa = vb - 0
                        wy = vby;

                    }

                    double minimo2 = DistanciaMinimaEnIntervalo(bx - ax, by - ay, wx, wy, duracion2);
                    if (minimo2 < minimo)
                        minimo = minimo2;

                }
                return minimo;

            }

        // Comprueba si dos vuelos el vuelo y el vuelo "b" entraran en conflicto en algún punto de la ruta,
        // devuelve true si entran en conflicto, false si no. La distancia de seguridad se pasa como parámetro
        public bool AnticiparConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            double distanciaMinima = this.DistanciaMinima(b, double.PositiveInfinity);
            return distanciaMinima < distanciaSeguridad;
        }

        // Devuelve true si los vuelos entran en conflicto durante el próximo ciclo de simulación.
        public bool ConflictoDuranteCiclo(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            double distanciaMinima = this.DistanciaMinima(b, tiempoCiclo);
            return distanciaMinima < distanciaSeguridad;
        }

        // Intenta evitar el conflicto reduciendo progresivamente la velocidad del vuelo un 10% (máximo 20 iteraciones). Devuelve true si lo consigue
        // Si no lo consigue (porque, por ejemplo, los dos vuelos empiezan muy juntos), deja la velocidad como estaba
        public bool ResolverConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            double velocidadOriginal = this.velocidad; // la guardamos por si no se puede resolver
            int intentos = 0;
            bool conflicto = this.AnticiparConflicto(b, distanciaSeguridad, tiempoCiclo); 

            while (conflicto && intentos < 20) // Máximo 20 intentos para no quedarnos en un bucle infinito
            {
                this.velocidad = this.velocidad * 0.9; // Bajamos la velocidad un 10%
                conflicto = this.AnticiparConflicto(b, distanciaSeguridad, tiempoCiclo);
                intentos++;
            }

            if (conflicto)
            {
                this.velocidad = velocidadOriginal; // No se ha podido: dejamos la velocidad original
                return false;
            }
            return true;
        }
    }
}
