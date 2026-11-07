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
        private List<FlightPlan> llistaVuelos = new List<FlightPlan>();
        public int AddFlightPlan(FlightPlan p)
        {
            if (p != null)
            {
                llistaVuelos.Add(p);
                return 0;
            }
            return -1;
        }

        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= llistaVuelos.Count)
                return null;
            else
                return llistaVuelos[i];
        }
        public int GetCount()
        {
            return llistaVuelos.Count;
        }
        public List<FlightPlan> GetVuelos()
        {
            return llistaVuelos;
        }

        public void Clear()
        {
            llistaVuelos.Clear();
        }

        public void Move(double tiempo)
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.Move(tiempo);
            }
        }
        public void RestartAll() 
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.Restart();
            }
        }

        public void EscribeConsola()
        {
            foreach (FlightPlan vol in llistaVuelos)
            {
                vol.EscribeConsola();
            }
        }

        private string erroresLectura = "";

        //devuelve un texto con los errores encontrados en la ultima lectura de fichero
        public string GetErroresLectura()
        {
            return erroresLectura;
        }

        //Lee los planes de vuelo de nuestro fichero de texto
        //una linea por vuelo, 7 datos separados por espacios.

        //Parametros dados: ruta del fichero. Devuelve true si todas las lineas son correctas; si alguna falla, la lista queda vacía

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
                        if (linia.Trim() != "") //las lineas vacias se ignoran
                        {

                            string[] trozos = linia.Trim().Split(' ');

                            if (trozos.Length != 7)

                                erroresLectura = erroresLectura + "Linea " + numLinea + ": tiene " + trozos.Length + " datos en vez de 7.\n";

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
                llistaVuelos.Clear(); //si hay errores no cargamos nada, para no simular con errores y datos incompletos
                return false;
            }
            return true;
        }

        public void GuardarEnFichero(string nombreFichero)
        {
            StreamWriter W = new StreamWriter(nombreFichero);
            foreach (FlightPlan vol in llistaVuelos)
            {
                // Format per línia: ID PosXIni PosYIni PosXFin PosYFin Velocitat Companyia
                string linia = vol.GetId() + " " + vol.GetInitialPosition().GetX() + " " + vol.GetInitialPosition().GetY() + " " + vol.GetFinalPosition().GetX() + " " + vol.GetFinalPosition().GetY() + " " + vol.GetVelocidad() + " " + vol.GetCompany();
                W.WriteLine(linia);
            }
            W.Close();
        }
    }
}

