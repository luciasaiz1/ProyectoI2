using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Position
    {
        // ATRIBUTOS
        double x; 
        double y;

        // CONSTRUCTOR
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // MÉTODOS
        // Getters y Setters
        public double GetX()
        { 
            return x;
        }

        public double GetY()
        { 
            return y;
        }

        // Retorna la distancia entre las posición que llama al método y la posición que se pasa como parámetro
        public double Distancia(Position b)
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return Math.Round(resultado, 2);
        }


    }
}
