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

            if (this.HasArrived())
            {
                return;
            }

            double distancia = tiempo * this.velocidad / 60; // Calculamos la distancia recorrida en el tiempo dado

            // Raones trigonométricas (2D)
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            // Nueva posición del avión 
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

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
        // Reinicia el vuelo a su posición inicial y velocidad inicial
        public void Restart()
        {
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
            this.velocidad = this.initialvelocidad;
        }
        // Distacia entre dos vuelos (actual y otro)
        public double Distance(FlightPlan plan)
        {
            double distance = this.currentPosition.Distancia(plan.GetCurrentPosition());
            return distance;
        }

        // Muestra por consola los datos del vuelo (debuggig en SimulatorConsole)
        public void EscribeConsola()
        {
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
            {
                Console.WriteLine("Ha llegado al destino");
            }
        }
        // Devuelve una copia del vuelo (para poder modificarlo sin afectar al original)
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
        // Conflictos y anticipación de conflictos
        // Devuelve true si la distancia entre dos vuelos es menor que la distancia de seguridad
        public bool Conflicto(FlightPlan b, double DistanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < DistanciaSeguridad)
            {
                conflicto = true;
            }
            return conflicto;
        }
        // Calcula el tiempo que queda para llegar en minutos.
        private double TiempoHastaDestino()
        {
            if (this.HasArrived() || this.velocidad <= 0)
            {
                return 0;
            }
            double distanciaRestante = this.currentPosition.Distancia(this.finalPosition);
            double velocidadPorUnidadTiempo = this.velocidad / 60;
            return distanciaRestante / velocidadPorUnidadTiempo;
        }
        // Velocidad en X en unidades/minuto 
        private double VelocidadX()
        {
            if (this.TiempoHastaDestino() == 0)
            {
                return 0;
            }

            double distanciasRestante = this.currentPosition.Distancia(this.finalPosition);
            double coseno = (this.finalPosition.GetX() - this.currentPosition.GetX()) / distanciasRestante;
            return (this.velocidad / 60) * coseno;
        }

        // Velocidad en Y en unidades/minuto 
        private double VelocidadY()
        {
            if (this.TiempoHastaDestino() == 0)
            {
                return 0;
            }    

            double distanciasRestante = this.currentPosition.Distancia(this.finalPosition);
            double seno = (this.finalPosition.GetY() - this.currentPosition.GetY()) / distanciasRestante;
            return (this.velocidad / 60) * seno;
        }
        // Devuelve la menor distancia alcanzada durante la duración del vuelo
        private double DistanciaMinimaEnIntervalo(double d0x, double d0y, double wx, double wy, double duracion)
        {
            // (d0x, d0y) = posicion relativa al principio del intervalo (B-A)
            // (wx,wy) = velocidad relativa

            double w2 = wx * wx + wy * wy;
            double t = 0; 

            if (w2 > 0) // Si la velocidad relativa es cero, la distancia no cambia
            {
                t = -(d0x * wx + d0y * wy) / w2; // Instante de mínima distancia (hecho con la derivada temporal)

                if (t < 0)
                {
                    t = 0;
                }
                if (t > duracion)
                {
                    t = duracion;
                }
            }

            double dx = d0x + wx * t;
            double dy = d0y + wy * t;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        // Distancia mínima entre un vuelo y otro
        public double DistanciaMinima(FlightPlan b, double horizonte)
        {
             // Datos de cada avión
            double vax = this.VelocidadX();
            double vay = this.VelocidadY();
            double vbx = b.VelocidadX();
            double vby = b.VelocidadY();
            double tA = this.TiempoHastaDestino();
            double tB = b.TiempoHastaDestino();

            double T = Math.Min(tA, tB);
            if (T > horizonte)
            {
                T = horizonte;
            }

            double d0x = b.currentPosition.GetX() - this.currentPosition.GetX();
            double d0y = b.currentPosition.GetY() - this.currentPosition.GetY();

            double minimo = DistanciaMinimaEnIntervalo(d0x, d0y, vbx - vax, vby - vay, T);

            // El primero ya ha llegado y el otro sigue volando
            double duracion2 = Math.Max(tA, tB) - T;
            if (T + duracion2 > horizonte)
            {
                duracion2 = horizonte - T;
            }
            if (duracion2 > 0)
            {
                // Posiciones de los dos aviones en el instante T
                double ax = this.currentPosition.GetX() + vax * T;
                double ay = this.currentPosition.GetY() + vay * T;
                double bx = b.currentPosition.GetX() + vbx * T;
                double by = b.currentPosition.GetY() + vby * T;

                double wx, wy;
                if (tA > tB)
                {
                    wx = -vax; // Se mueve A, B esta quieto -> velocidad relativa = 0 - va
                    wy = -vay;
                }
                else
                {
                    wx = vbx; // Se mueve B, A esta quieto -> velocidad relativa = vb - 0
                    wy = vby;

                }

                double minimo2 = DistanciaMinimaEnIntervalo(bx - ax, by - ay, wx, wy, duracion2);
                if (minimo2 < minimo)
                {
                    minimo = minimo2;
                }
            }
            return minimo;
        }
        // Coprueba si dos vuelos entrarán en conflicto durante la simulación
        public bool AnticiparConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            double distanciaMinima = this.DistanciaMinima(b, double.PositiveInfinity);
            return distanciaMinima < distanciaSeguridad;
        }
        // Intenta evitar el conflicto reduciendo progresivamente la velocidad de un vuelo un 10% (máximo 20 iteraciones)
        public bool ResolverConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {
            double velocidadOriginal = this.velocidad;  // La guardamos por si no se puede resolver
            int intentos = 0;
            bool conflicto = this.AnticiparConflicto(b, distanciaSeguridad, tiempoCiclo); 

            while (conflicto && intentos < 20) 
            {
                this.velocidad = this.velocidad * 0.9;
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
