using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Stack
    {
        private Stack<FlightPlanList> stackVuelos = new Stack<FlightPlanList>();
      
        public Stack<FlightPlanList> GetStack()
        {
            return stackVuelos;
        }
    }
}
