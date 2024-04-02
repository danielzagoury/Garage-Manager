using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public static string m_Color { get; set; }
        public static int m_NumberOfDoors { get; set; }
        public enum eColor
        {
            blue,
            white,
            red,
            yellow
        }
        public Car() { }
    }
}
