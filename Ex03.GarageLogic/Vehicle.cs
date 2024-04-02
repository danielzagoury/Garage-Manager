using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle 
    {
        public string m_ModelOfTheCar { get; set; }
        public string m_LicenseNumber { get; set; }
        public float m_EnergyLeft { get; set; }
        public static Tire TireInstance { get; set; }
        public List<Tire> m_Tires { get; set; }
        public ClientDetails m_ClientDetails { get; set; }
        public Fuel fuelInstance=null;
        public Electric electriclInstance = null;
        public Truck trucklInstance = null;
        public Vehicle() { }
        
     public float ShowHowMuchEnergyLeft()
     {
            return m_EnergyLeft;
     }
    }
}

