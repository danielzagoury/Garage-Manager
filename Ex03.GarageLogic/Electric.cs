using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric
    {
        public float m_BatteryTimeRemainingInHours { get; set; }
        public float m_MaximumBatteryTimeInHours { get; set; }
        public Electric (float i_BatteryTimeRemainingInHours,float i_MaximumBatteryTimeInHours)
        {
            m_BatteryTimeRemainingInHours = i_BatteryTimeRemainingInHours;
            m_MaximumBatteryTimeInHours= i_MaximumBatteryTimeInHours;
        }
        protected void BatteryCharging(float i_HowManyHoursAddToCharging)
        {
            float m_maxValue = m_MaximumBatteryTimeInHours;
            float m_minValue = 0.0f;
            try
            {
                if (!float.TryParse(i_HowManyHoursAddToCharging.ToString(), out float litersToAdd))
                {
                    throw new FormatException("Invalid format for amount of hours to add.");
                }
                if (m_BatteryTimeRemainingInHours+ i_HowManyHoursAddToCharging> m_MaximumBatteryTimeInHours)
                {
                    throw new ValueOutOfRangeException(m_minValue, m_maxValue);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Error: {fe.Message}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
 }


