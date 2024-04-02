using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        public string m_ManufacturerName { get; set; }
        public float m_CurrentAirPressure { get; set; }
        public float m_MaximumAirPressure { get; set; }
        public Tire(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaximumAirPressure = i_MaximumAirPressure;
        }
        
        protected void TireInflation(float i_HowManyAirAddToCharging)
        {
            float m_maxValue = m_MaximumAirPressure;//m_BatteryTimeRemainingInHours;
            float m_minValue = 0.0f;
            try
            {
                float i_airToAdd;
                if (!float.TryParse(i_HowManyAirAddToCharging.ToString(), out i_airToAdd))
                {
                    throw new FormatException("Invalid format for air pressure.");
                }
                if (m_CurrentAirPressure + i_airToAdd > m_MaximumAirPressure)
                {
                    throw new ValueOutOfRangeException(m_maxValue, m_minValue);
                }
                m_CurrentAirPressure = m_CurrentAirPressure + i_HowManyAirAddToCharging;
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)

            {
                Console.WriteLine(i_ValueOutOfRangeException.Message);
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
            }
        }
        public static List<Tire> AddTires(int numberOfTires, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            List<Tire> tires = new List<Tire>();
            for (int i = 0; i < numberOfTires; i++)
            {
                tires.Add(new Tire(i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure));
            }
            return tires;
        }
    }

}
    


