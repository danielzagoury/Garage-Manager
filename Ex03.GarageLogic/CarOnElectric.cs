using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.ClientDetails;
using static Ex03.GarageLogic.Fuel;

namespace Ex03.GarageLogic
{ 
    public class CarOnElectric : Car
    {
        public CarOnElectric(
        string i_ClientName, string i_ClientPhone, eVehicleCondition i_Condition, 
        string i_modelOfTheCar, string i_licenseNumber, float i_energyLeft,
        string i_ManufacturerName, float i_CurrentAirPressure,
        float i_batteryTimeRemainingInHours, string i_color, int i_numberOfDoors)
        {
            electriclInstance = new Electric(i_batteryTimeRemainingInHours, 4.8f);
            m_ClientDetails = new ClientDetails(i_ClientName, i_ClientPhone, i_Condition);
            m_Tires = Tire.AddTires(5, i_ManufacturerName, i_CurrentAirPressure, 30.0f);
            m_ModelOfTheCar = i_modelOfTheCar;
            m_LicenseNumber = i_licenseNumber;
            m_EnergyLeft = i_energyLeft;
            m_Color = i_color;
            m_NumberOfDoors = i_numberOfDoors;
        }
    }
}


 
