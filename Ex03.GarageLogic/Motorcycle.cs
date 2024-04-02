using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public static string m_LicenseType { get; set; }
        public static int m_EngineVolumeInCc { get; set; }
        public enum eLicenseTypes
        {
            A1,
            A2,
            AB,
            B2
        }
        public Motorcycle() { }
    }
}

