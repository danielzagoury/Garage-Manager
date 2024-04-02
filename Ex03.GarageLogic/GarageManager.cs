using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public readonly List<Vehicle> r_Vehicles = new List<Vehicle>();
        public GarageManager()
        {
            r_Vehicles = new List<Vehicle>();
        }
    }
}

