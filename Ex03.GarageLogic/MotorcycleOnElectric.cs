using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.ClientDetails;

namespace Ex03.GarageLogic
{
    public class MotorcycleOnElectric : Motorcycle 
    {
        

        public MotorcycleOnElectric(
            string i_ClientName, string i_ClientPhone, eVehicleCondition i_Condition,
            string i_modelOfTheCar, string i_licenseNumber, float i_energyLeft,
            string i_ManufacturerName, float i_CurrentAirPressure,
            float i_batteryTimeRemainingInHours,
            string i_LicenseType, int i_EngineVolumeInCc)
        {
            m_ClientDetails = new ClientDetails(i_ClientName, i_ClientPhone, i_Condition);
            m_ModelOfTheCar = i_modelOfTheCar;
            m_LicenseNumber = i_licenseNumber;
            m_EnergyLeft = i_energyLeft;
            m_Tires = Tire.AddTires(2, i_ManufacturerName, i_CurrentAirPressure, 29.0f);
            electriclInstance = new Electric(i_batteryTimeRemainingInHours, 2.8f);
            m_LicenseType = i_LicenseType;
            m_EngineVolumeInCc = i_EngineVolumeInCc;
        }
    }
}


