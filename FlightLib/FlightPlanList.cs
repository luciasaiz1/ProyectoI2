using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        // ATRIBUTOS
        private List<FlightPlan> llistaVuelos = new List<FlightPlan>();
        private string erroresLectura = "";

        // CONSTRUCTOR
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= llistaVuelos.Count)
                return null;
            else
                return llistaVuelos[i];
        }

        // MÉTODOS
        // Getters y Setters
        public int GetCount()
        {
            return llistaVuelos.Count;
        }
        public List<FlightPlan> GetVuelos()
        {
            return llistaVuelos;
        }
        public string GetErroresLectura()
        {
            return erroresLectura;
        }

        // Añade el FlightPlan del parámetro p a la lista, devolviendo si se añadió correctamente 
        public int AddFlightPlan(FlightPlan p)
        {
            if (p != null)
            {
                llistaVuelos.Add(p);
                return 0;
            }
            return -1;
        }
        // Devuelve una copia de la lista de vuelos
        public FlightPlanList Clone()
        {
            FlightPlanList copia = new FlightPlanList();

            foreach (FlightPlan vuelo in llistaVuelos)
            {
                copia.AddFlightPlan(vuelo.Clone());
            }

            return copia;
        }
        // Restaura el estado de los vuelos de la lista al estado del parámetro
        public void RestoreFrom(FlightPlanList estado)
        {
            for (int i = 0; i < llistaVuelos.Count; i++)
            {
                FlightPlan actual = llistaVuelos[i];
                FlightPlan guardado = estado.GetFlightPlan(i);
                actual.SetCurrentPosition(new Position(guardado.GetCurrentPosition().GetX(),guardado.GetCurrentPosition().GetY()));
                actual.SetVelocidad(guardado.GetVelocidad());
            }
        }
        // Elimina todos los vuelos de la lista
        public void Clear()
        {
            llistaVuelos.Clear();
        }
        // Escribe en la consola los datos de todos los vuelos de la lista
        public void EscribeConsola()
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.EscribeConsola();
            }
        }
        // Mueve todos los vuelos de la lista el tiempo indicado en el parámetro
        public void Move(double tiempo)
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.Move(tiempo);
            }
        }
        // Reinicia todos los vuelos de la lista a su posición y velocidad originales
        public void RestartAll() 
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.Restart();
            }
        }

        // Conflictos
        // Devuelve una matriz de booleanos indicando si hay conflicto entre cada par de vuelos de la lista
        public bool[,] ObtenerMatrizConflictos(double distanciaSeguridad, double horizonte)
        {
            int cantidadVuelos = llistaVuelos.Count;
            bool[,] matriz = new bool[cantidadVuelos, cantidadVuelos];

            for (int i = 0; i < cantidadVuelos; i++)
            {
                for (int j = i + 1; j < cantidadVuelos; j++)
                {
                    bool conflicto = llistaVuelos[i].DistanciaMinima(llistaVuelos[j], horizonte) < distanciaSeguridad;
                    matriz[i, j] = conflicto;
                    matriz[j, i] = conflicto;
                }
            }
            return matriz;
        }
        // Resuelve los conflictos entre los vuelos de la lista, devolviendo si se han resuelto todos correctamente
        public bool ResolverConflictos(double distanciaSeguridad, double tiempoCiclo)
        {
            int maxPasadas = llistaVuelos.Count * llistaVuelos.Count;
            bool huboCambios = true;
            int pasada = 0;

            while (huboCambios && pasada < maxPasadas)
            {
                huboCambios = false;
                bool[,] matriz = ObtenerMatrizConflictos(distanciaSeguridad, double.PositiveInfinity);

                for (int i = 0; i < llistaVuelos.Count; i++)
                {
                    for (int j = i + 1; j < llistaVuelos.Count; j++)
                    {
                        if (!matriz[i, j])
                        {
                            continue;
                        }

                        FlightPlan primero = llistaVuelos[i];
                        FlightPlan segundo = llistaVuelos[j];
                        double velocidadSegundo = segundo.GetVelocidad();

                        segundo.ResolverConflicto(primero, distanciaSeguridad, tiempoCiclo);
                        if (Math.Abs(segundo.GetVelocidad() - velocidadSegundo) > 0.000001)
                        {
                            huboCambios = true;
                            continue;
                        }

                        double velocidadPrimero = primero.GetVelocidad();
                        primero.ResolverConflicto(segundo, distanciaSeguridad, tiempoCiclo);
                        if (Math.Abs(primero.GetVelocidad() - velocidadPrimero) > 0.000001)
                        {
                            huboCambios = true;
                        }
                    }
                }

                pasada++;
            }

            bool[,] conflictosFinales = ObtenerMatrizConflictos(distanciaSeguridad, double.PositiveInfinity);
            for (int i = 0; i < llistaVuelos.Count; i++)
            {
                for (int j = i + 1; j < llistaVuelos.Count; j++)
                {
                    if (conflictosFinales[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        // Lee los vuelos de un fichero de texto, devolviendo si se han leído correctamente 
        public bool LeerDelFichero(string nombreFichero)
        {
            llistaVuelos.Clear();
            erroresLectura = "";

            int numLinea = 0;

            try
            {
                using (StreamReader r = new StreamReader(nombreFichero))
                {
                    string linia = r.ReadLine();
                    while (linia != null)
                    {
                        numLinea++;
                        if (linia.Trim() != "") // Solo si la línea no está vacía la procesamos
                        {
                            string[] trozos = linia.Trim().Split(' ');
                            if (trozos.Length != 7)
                            {
                                erroresLectura = erroresLectura + "Linea " + numLinea + ": tiene " + trozos.Length + " datos en vez de 7.\n";
                            }
                            else
                            {
                                try
                                {
                                    string id = trozos[0];
                                    double cpx = Convert.ToDouble(trozos[1]);
                                    double cpy = Convert.ToDouble(trozos[2]);
                                    double fpx = Convert.ToDouble(trozos[3]);
                                    double fpy = Convert.ToDouble(trozos[4]);
                                    double velocidad = Convert.ToDouble(trozos[5]);
                                    string company = trozos[6];

                                    if (velocidad <= 0 || velocidad > 1000)
                                        erroresLectura = erroresLectura + "Linea " + numLinea + ": la velocidad debe estar entre 0 y 1000.\n";
                                    else if (cpx == fpx && cpy == fpy)
                                        erroresLectura = erroresLectura + "Linea " + numLinea + ": el origen y el destino son el mismo punto.\n";
                                    else
                                        llistaVuelos.Add(new FlightPlan(trozos[0], cpx, cpy, fpx, fpy, velocidad, trozos[6]));
                                }
                                catch (FormatException)
                                {
                                    erroresLectura = erroresLectura + "Linea" + numLinea + ": hay texto donde deberia haber un numero.\n";
                                }
                            }
                        }
                        linia = r.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                erroresLectura = "No se encuentra el fichero " + nombreFichero;
            }

            catch (Exception)
            {
                erroresLectura = "No se puede leer el fichero " + nombreFichero;
            }
            if(erroresLectura != "")

            {
                llistaVuelos.Clear();
                return false;
            }
            return true;
        }
        // Guarda los vuelos de la lista en un fichero de texto
        public void GuardarEnFichero(string nombreFichero)
        {
            StreamWriter W = new StreamWriter(nombreFichero);
            foreach (FlightPlan vol in llistaVuelos)
            {
                // Formato de las lineas: ID PosXIni PosYIni PosXFin PosYFin Velocidad Compañia
                string linia = vol.GetId() + " " + vol.GetInitialPosition().GetX() + " " + vol.GetInitialPosition().GetY() + " " + vol.GetFinalPosition().GetX() + " " + vol.GetFinalPosition().GetY() + " " + vol.GetVelocidad() + " " + vol.GetCompany();
                W.WriteLine(linia);
            }
            W.Close();
        }
    }
}

