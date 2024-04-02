using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.ClientDetails;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {

        public bool m_HazardousMaterials { get; set; }
        public float m_CargoVolume { get; set; }
        public Truck (bool i_HazardousMaterials,float i_CargoVolume)
        {
            m_HazardousMaterials=i_HazardousMaterials;
            m_CargoVolume=i_CargoVolume;
        }
        public Truck(string i_ClientName, string i_ClientPhone, eVehicleCondition i_Condition, 
            string i_ManufacturerName, float i_CurrentAirPressure,
            string i_modelOfTheCar, string i_licenseNumber, float i_energyLeft,
            float i_TheCurrentAmountOfFuelInLiters,
            bool i_HazardousMaterials,float i_CargoVolume)
        {
            m_ClientDetails = new ClientDetails(i_ClientName, i_ClientPhone, i_Condition);
            m_ModelOfTheCar = i_modelOfTheCar;
            m_LicenseNumber = i_licenseNumber;
            m_EnergyLeft = i_energyLeft;
            m_Tires = Tire.AddTires(12, i_ManufacturerName, i_CurrentAirPressure, 28.0f);
            fuelInstance = new Fuel("Soler", i_TheCurrentAmountOfFuelInLiters, 110.0f);
            trucklInstance = new Truck(i_HazardousMaterials, i_CargoVolume);
            
        }
    }
}
