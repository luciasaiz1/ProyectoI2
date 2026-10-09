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
        // Atributos

        string id; // identificador
        Position initialPosition; //posicion inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        string company; //compañia aerea

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, string company)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.company = company;
        }

        //Getters i Setters
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


        // Metodos

        public void Move(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {

            //Si el avion ya llego a su destin, no se mueve
            if (this.HasArrived())
            {
                return;
            }
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;


            // QUE NO SE PASE DEL DESTINO
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

        // METODO VUELO HA LLEGADO A SU DESTINO

        public bool HasArrived()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;
           

            return resultado;
        }


        // DETECTAR CONFLICTO
        public bool Conflicto(FlightPlan b, double DistanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < DistanciaSeguridad)
                conflicto = true;
            
            return conflicto;
        }

        //ANTICIPAR CONFLICTO

        public bool AnticiparConflicto(FlightPlan b, double distanciaSeguridad, double tiempoCiclo)
        {

            //1. Guardar ahora donde estan los dos aviones
            Position guardadaA = this.currentPosition;
            Position guardadaB = b.currentPosition;

            //2. Usamos pasos 10 veces mas pequenos que el ciclo para no "saltarnos"  un conflicto
            double paso = tiempoCiclo / 10;
            bool conflicto = false;
            int pasos = 0; //seguridad: evita un bucle infinito si una velocidad es cero

            //3. Ensayo general: avanzamos hasta que haya conflicto o hasta que los dos lleguem
            while (!conflicto && !(this.HasArrived() && b.HasArrived()) && pasos < 100000)
            {
                if (this.Conflicto(b,distanciaSeguridad))
                {
                    conflicto = true;
                }
                else
                {
                    this.Move(paso);
                    b.Move(paso);
                    pasos++;
                }
            }
            if (!conflicto && this.Conflicto(b, distanciaSeguridad))
            {
                conflicto = true;
            }
            //5. Devolvemos los aviones a donde estaban antes de la simulación
            this.currentPosition = guardadaA;
            b.currentPosition = guardadaB;
            return conflicto;
        }

        //4. comprobamos tambien la posicion final por si acaban demasiado cerca
       
        
        public void Restart()
        {
            //mueve el avión a la posición inicial
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
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
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);

            // 2 DECIMALES
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
            {
                Console.WriteLine("Ha llegado al destino");
            }
            Console.WriteLine("******************************");
        }
        // CAMBIOS
    }
}
