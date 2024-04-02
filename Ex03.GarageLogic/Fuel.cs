using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ex03.GarageLogic
{
    public class Fuel 
    {
        public string m_TypeOfuel { get; set; }
        public float m_TheCurrentAmountOfFuelInLiters { get;set; }
        public float m_TheMaxAmountOfFuelInLiters { get;  set; }

        public enum eFuelTypes
        {
            Soler,
            Octan96,
            Octan95,
            Octan98
        }
        public Fuel(string i_typeOfuel, float i_theCurrentAmountOfFuelInLiters, float i_theMaxAmountOfFuelInLiters)
        {
            m_TypeOfuel = i_typeOfuel;
            m_TheCurrentAmountOfFuelInLiters = i_theCurrentAmountOfFuelInLiters;
            m_TheMaxAmountOfFuelInLiters = i_theMaxAmountOfFuelInLiters;
        }

        public void RefuelVehicleOnFuel(eFuelTypes i_FuelType, float HowManyFuelToAdd)
        {
            float m_maxValue = m_TheMaxAmountOfFuelInLiters;
            float m_minValue = 0.0f;
            try
            {
                if(m_TypeOfuel== i_FuelType.ToString())
                { }
                else
                {
                    throw new ArgumentException();
                }
                if (m_TheCurrentAmountOfFuelInLiters + HowManyFuelToAdd <= m_TheMaxAmountOfFuelInLiters)
                {
                    m_TheCurrentAmountOfFuelInLiters += HowManyFuelToAdd;
                    Console.WriteLine($"Successfully refueled {HowManyFuelToAdd} liters of {i_FuelType}.");
                }
                else
                {
                    throw new ValueOutOfRangeException(m_minValue, m_maxValue);
                }
            }
            catch (ValueOutOfRangeException vuor)
            {
                Console.WriteLine($"Error: {vuor.Message}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Error: {ae.Message}");
            }
        }
    }
}
