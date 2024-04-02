using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.ClientDetails;

namespace Ex03.GarageLogic
{
    public class CarOnFuel : Car
    {
        public CarOnFuel(
            string i_ClientName, string i_ClientPhone, eVehicleCondition i_Condition, 
            string i_ManufacturerName, float i_CurrentAirPressure,
            string i_modelOfTheCar, string i_licenseNumber, float i_energyLeft,
            float i_TheCurrentAmountOfFuelInLiters,string i_color, int i_numberOfDoors)
        {
            fuelInstance = new Fuel("Octagon95", i_TheCurrentAmountOfFuelInLiters, 58.0f);
            m_ClientDetails = new ClientDetails(i_ClientName, i_ClientPhone, i_Condition);
            m_Tires = Tire.AddTires(5, i_ManufacturerName, i_CurrentAirPressure, 30.0f);
            m_LicenseNumber = i_licenseNumber;
            m_ModelOfTheCar = i_modelOfTheCar;
            m_EnergyLeft = i_energyLeft;
            m_Color = i_color;
            m_NumberOfDoors = i_numberOfDoors;
        }
    }
}

