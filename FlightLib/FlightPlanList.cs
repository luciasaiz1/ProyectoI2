using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public bool LeerDelFichero(string nombreFichero)
        {
            llistaVuelos.Clear();
            bool correcto = true;
            try
            {
                StreamReader r = new StreamReader(nombreFichero);
                string linia = r.ReadLine();
                while (linia != null)
                {
                    string[] trozos = linia.Split(' ');

                    if (trozos.Length == 7)
                    {
                        string id = trozos[0];
                        double cpx = Convert.ToDouble(trozos[1]);
                        double cpy = Convert.ToDouble(trozos[2]);
                        double fpx = Convert.ToDouble(trozos[3]);
                        double fpy = Convert.ToDouble(trozos[4]);
                        double velocidad = Convert.ToDouble(trozos[5]);
                        string company = trozos[6];

                        FlightPlan fp = new FlightPlan(id, cpx, cpy, fpx, fpy, velocidad, company);
                        llistaVuelos.Add(fp);
                    }
                    else
                    {
                        Console.WriteLine("Error: línea con formato incorrecto: " + linia);
                        correcto = false;
                    }
                    linia = r.ReadLine();
                }
                r.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: no se encuentra el fichero " + nombreFichero);
                correcto = false;
            }
            catch (Exception)
            {
                correcto = false;
                Console.WriteLine("Error: no se puede leer el fichero " + nombreFichero);
            }
            return correcto;
            
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

