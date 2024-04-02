using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.ClientDetails;
using static Ex03.GarageLogic.Fuel;
using static Ex03.GarageLogic.GarageManager;
using static Ex03.GarageLogic.Motorcycle;
namespace Ex03.ConsoleUI
{
    public enum eVehicleType
    {
        CarOnFuel,
        ElectricCar,
        MotorcycleOnFuel,
        ElectricMotorcycle,
        Truck
    }
    public class GarageFunction
    {
        public static List<Vehicle> r_Vehicles = new List<Vehicle>();
        public string io_licenseNumber;
        private GarageManager m_garageManager;
        public GarageFunction(GarageManager garageManager)
        {
            m_garageManager = garageManager;
        }
        public bool ChecksIfTheVehicleIsFound()
        {
            Console.WriteLine("Enter the License Number of the vehicle");
            io_licenseNumber = Console.ReadLine();
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.m_LicenseNumber == io_licenseNumber)
                {
                    vehicle.m_ClientDetails.ChangeCondition(ClientDetails.eVehicleCondition.InRepair);
                    Console.WriteLine("Vehicle found and marked as InRepair.");
                    return true;
                }
            }
            return false;
        }
        public static void addVehicle(Vehicle i_vehicle)
        {
            r_Vehicles.Add(i_vehicle);
        }
        public int ChooseVehicleType()
        {
            Console.WriteLine("Choose the type of vehicle you want to put in the garage:");
            foreach (eVehicleType type in Enum.GetValues(typeof(eVehicleType)))
            {
                Console.WriteLine($"{(int)type} - {type}");
            }
            int choice;
            do
            {
                Console.Write("Enter the corresponding number: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(eVehicleType), choice));
            return choice;
        }
            
        public static MotorcycleOnElectric GetMotorcycleOnElectricDetails(string i_licenseNumber)
        {
            Console.WriteLine("Enter client name:");
            string i_clientName = Console.ReadLine();
            Console.WriteLine("Enter client phone:");
            string i_clientPhone = Console.ReadLine();
            Console.WriteLine("Enter vehicle condition:(InRepair, Repaired,Paid)");
            eVehicleCondition i_condition;
            string i_conditionStr = Console.ReadLine();
            try
            {
                if (!Enum.TryParse(i_conditionStr, out i_condition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {
                Enum.TryParse(i_conditionStr, out i_condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("The parsing didnt work");
                i_condition = eVehicleCondition.InRepair;
            }
            Console.WriteLine("Enter model of the car:");
            string i_modelOfTheCar = Console.ReadLine();
            Console.WriteLine("Enter energy left:");
            float i_energyLeft;
            float.TryParse(Console.ReadLine(), out i_energyLeft);
            Console.WriteLine("Enter manufacturer name:");
            string i_manufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            float i_currentAirPressure;
            float.TryParse(Console.ReadLine(), out i_currentAirPressure);
            Console.WriteLine("Enter battery time remaining in hours:");
            float i_batteryTimeRemainingInHours;
            float.TryParse(Console.ReadLine(), out i_batteryTimeRemainingInHours);
            Console.WriteLine("Enter maximum battery time in hours:");
            Console.WriteLine("Enter license type:");
            string i_licenseType = Console.ReadLine();
            Console.WriteLine("Enter engine volume in cc:");
            int engineVolumeInCc;
            int.TryParse(Console.ReadLine(), out engineVolumeInCc);
            return new MotorcycleOnElectric(i_clientName, i_clientPhone, i_condition, i_modelOfTheCar, i_licenseNumber, i_energyLeft, i_manufacturerName,
                                              i_currentAirPressure, i_batteryTimeRemainingInHours,
                                               i_licenseType, engineVolumeInCc);

        }
        public static MotorcycleOnFuel GetMotorcycleOnFuelDetails(string i_licenseNumber)
        {
            Console.WriteLine("Enter client name:");
            string i_clientName = Console.ReadLine();
            Console.WriteLine("Enter client phone:");
            string i_clientPhone = Console.ReadLine();
            Console.WriteLine("Enter vehicle condition:(InRepair, Repaired,Paid)");
            eVehicleCondition i_condition;
            string i_conditionStr = Console.ReadLine();

            try
            {
                if (!Enum.TryParse(i_conditionStr, out i_condition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            try
            {
                Enum.TryParse(i_conditionStr, out i_condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("The parsing didnt work");
                i_condition = eVehicleCondition.InRepair;
            }
            Console.WriteLine("Enter manufacturer name:");
            string i_manufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            float i_currentAirPressure;
            float.TryParse(Console.ReadLine(), out i_currentAirPressure);
            Console.WriteLine("Enter model of the car:");
            string i_modelOfTheCar = Console.ReadLine();
            //Console.WriteLine("Enter license number:");
            //string i_licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter energy left:");
            float i_energyLeft;
            float.TryParse(Console.ReadLine(), out i_energyLeft);
            Console.WriteLine("Enter the current amount of fuel in liters:");
            float i_currentAmountOfFuelInLiters;
            float.TryParse(Console.ReadLine(), out i_currentAmountOfFuelInLiters);
            Console.WriteLine("Enter license type:");
            string i_licenseType = Console.ReadLine();
            Console.WriteLine("Enter engine volume in cc:");
            int i_engineVolumeInCc;
            int.TryParse(Console.ReadLine(), out i_engineVolumeInCc);
            return new MotorcycleOnFuel(
                i_clientName, i_clientPhone, i_condition,
                i_manufacturerName, i_currentAirPressure,
                i_modelOfTheCar, i_licenseNumber, i_energyLeft,
                i_currentAmountOfFuelInLiters, i_licenseType, i_engineVolumeInCc);
        }
        public static CarOnFuel GetCarOnFuelDetails(string i_licenseNumber)
        {
            Console.WriteLine("Enter client name:");
            string i_clientName = Console.ReadLine();
            Console.WriteLine("Enter client phone:");
            string i_clientPhone = Console.ReadLine();
            Console.WriteLine("Enter vehicle condition:(InRepair, Repaired,Paid)");
            eVehicleCondition i_condition;
            string i_conditionStr = Console.ReadLine();
            try
            {
                if (!Enum.TryParse(i_conditionStr, out i_condition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {
                Enum.TryParse(i_conditionStr, out i_condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("The parsing didnt work");
                i_condition = eVehicleCondition.InRepair;
            }
            Console.WriteLine("Enter manufacturer name:");
            string i_manufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            float i_currentAirPressure;
            float.TryParse(Console.ReadLine(), out i_currentAirPressure);
            Console.WriteLine("Enter model of the car:");
            string i_modelOfTheCar = Console.ReadLine();
            Console.WriteLine("Enter energy left:");
            float i_energyLeft;
            float.TryParse(Console.ReadLine(), out i_energyLeft);

            Console.WriteLine("Enter the current amount of fuel in liters:");
            float i_currentAmountOfFuelInLiters;
            float.TryParse(Console.ReadLine(), out i_currentAmountOfFuelInLiters);

            Console.WriteLine("Enter color:");
            string i_color = Console.ReadLine();

            Console.WriteLine("Enter number of doors:");
            int i_numberOfDoors;
            int.TryParse(Console.ReadLine(), out i_numberOfDoors);

            return new CarOnFuel(i_clientName, i_clientPhone, i_condition,
                i_manufacturerName, i_currentAirPressure,
                i_modelOfTheCar, i_licenseNumber, i_energyLeft,
                i_currentAmountOfFuelInLiters, i_color, i_numberOfDoors);
        }
        public static CarOnElectric GetCarOnElectricDetails(string i_licenseNumber)
        {
            Console.WriteLine("Enter client name:");
            string i_clientName = Console.ReadLine();

            Console.WriteLine("Enter client phone:");
            string i_clientPhone = Console.ReadLine();


            Console.WriteLine("Enter vehicle condition:(InRepair, Repaired,Paid)");
            eVehicleCondition i_condition;
            string i_conditionStr = Console.ReadLine();


            try
            {
                if (!Enum.TryParse(i_conditionStr, out i_condition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            try
            {
                Enum.TryParse(i_conditionStr, out i_condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("The parsing didnt work");
                i_condition = eVehicleCondition.InRepair;
            }
            Console.WriteLine("Enter model of the car:");
            string i_modelOfTheCar = Console.ReadLine();
            Console.WriteLine("Enter energy left:");
            float i_energyLeft;
            float.TryParse(Console.ReadLine(), out i_energyLeft);

            Console.WriteLine("Enter manufacturer name:");
            string i_manufacturerName = Console.ReadLine();

            Console.WriteLine("Enter current air pressure:");
            float i_currentAirPressure;
            float.TryParse(Console.ReadLine(), out i_currentAirPressure);

            Console.WriteLine("Enter battery time remaining in hours:");
            float i_batteryTimeRemainingInHours;
            float.TryParse(Console.ReadLine(), out i_batteryTimeRemainingInHours);

            Console.WriteLine("Enter color:");
            string i_color = Console.ReadLine();

            Console.WriteLine("Enter number of doors:");
            int i_numberOfDoors;
            int.TryParse(Console.ReadLine(), out i_numberOfDoors);

            return new CarOnElectric(i_clientName, i_clientPhone, i_condition,
                i_modelOfTheCar, i_licenseNumber, i_energyLeft,
                i_manufacturerName, i_currentAirPressure,
                i_batteryTimeRemainingInHours, i_color, i_numberOfDoors);
        }
        public static Truck GetTruckDetails(string i_licenseNumber)
        {
            Console.WriteLine("Enter client name:");
            string i_clientName = Console.ReadLine();
            Console.WriteLine("Enter client phone:");
            string i_clientPhone = Console.ReadLine();
            Console.WriteLine("Enter vehicle condition:(InRepair, Repaired,Paid)");
            eVehicleCondition i_condition;
            string i_conditionStr = Console.ReadLine();


            try
            {
                if (!Enum.TryParse(i_conditionStr, out i_condition))
                {
                    throw new ArgumentException("Invalid vehicle condition entered.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                Enum.TryParse(i_conditionStr, out i_condition);
            }
            catch (FormatException)
            {
                Console.WriteLine("The parsing didnt work");
                i_condition = eVehicleCondition.InRepair;
            }
            Console.WriteLine("Enter manufacturer name:");
            string i_manufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            float i_currentAirPressure;
            float.TryParse(Console.ReadLine(), out i_currentAirPressure);
            Console.WriteLine("Enter model of the car:");
            string i_modelOfTheCar = Console.ReadLine();
            Console.WriteLine("Enter energy left:");
            float i_energyLeft;
            float.TryParse(Console.ReadLine(), out i_energyLeft);
            Console.WriteLine("Enter the current amount of fuel in liters:");
            float i_currentAmountOfFuelInLiters;
            float.TryParse(Console.ReadLine(), out i_currentAmountOfFuelInLiters);
            Console.WriteLine("Enter if the truck carries hazardous materials (true/false):");
            bool i_hazardousMaterials;
            bool.TryParse(Console.ReadLine(), out i_hazardousMaterials);
            Console.WriteLine("Enter cargo volume:");
            float i_cargoVolume;
            float.TryParse(Console.ReadLine(), out i_cargoVolume);
            return new Truck(i_clientName, i_clientPhone, i_condition, i_manufacturerName, i_currentAirPressure,
                i_modelOfTheCar, i_licenseNumber, i_energyLeft, i_currentAmountOfFuelInLiters,
                i_hazardousMaterials, i_cargoVolume);
        }
        public void ViewTheListOfLicenseNumbersWithFilter()
        {
            Console.WriteLine("Do you want to filter by (InRepair, Repaired, Paid)? Type the condition or type 'no' to see all.");
            string i_Filter = Console.ReadLine();

            if (i_Filter.ToLower() == "no")
            {
                foreach (Vehicle vehicle in r_Vehicles)
                {
                    Console.WriteLine(vehicle.m_LicenseNumber);
                }
            }
            else
            {
                switch (i_Filter)
                {
                    case "Repaired":
                        foreach (Vehicle vehicle in r_Vehicles)
                        {
                            if (vehicle.m_ClientDetails.m_Condition == ClientDetails.eVehicleCondition.Repaired)
                            {
                                Console.WriteLine(vehicle.m_LicenseNumber);
                            }
                        }
                        break;
                    case "InRepair":
                        foreach (Vehicle vehicle in r_Vehicles)
                        {
                            if (vehicle.m_ClientDetails.m_Condition == ClientDetails.eVehicleCondition.InRepair)
                            {
                                Console.WriteLine(vehicle.m_LicenseNumber);
                            }
                        }
                        break;
                    case "Paid":
                        foreach (Vehicle vehicle in r_Vehicles)
                        {
                            if (vehicle.m_ClientDetails.m_Condition == ClientDetails.eVehicleCondition.Paid)
                            {
                                Console.WriteLine(vehicle.m_LicenseNumber);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid filter condition.");
                        break;
                }
            }
        }
        public void ChangeCondition(string i_LicenseNumber, eVehicleCondition i_NewCondition)
        {
            bool licenseNumberFound = false;

            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.m_LicenseNumber == i_LicenseNumber)
                {
                    vehicle.m_ClientDetails.m_Condition = i_NewCondition;
                    Console.WriteLine($"Condition of vehicle with license number {i_LicenseNumber} changed to {i_NewCondition}.");
                    licenseNumberFound = true;
                    break;
                }
            }
            if (!licenseNumberFound)
            {
                throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not found.");
            }
        }
        public void InflateAirToTheMaximum(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.m_LicenseNumber == i_LicenseNumber)
                {
                    foreach (Tire tire in vehicle.m_Tires)
                    {
                        tire.m_CurrentAirPressure = tire.m_MaximumAirPressure;
                    }
                    Console.WriteLine($"Air pressure inflated to maximum for vehicle with license number {i_LicenseNumber}.");
                    return;
                }
            }
            throw new ArgumentException($"Vehicle with license number {i_LicenseNumber} not found.");
        }
        public static void RefuelVehicleOnFuel(string i_licenseNumber, eFuelTypes i_FuelType, float i_HowManyFuelToAdd)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.m_LicenseNumber == i_licenseNumber)
                {
                    float m_minValue = vehicle.fuelInstance.m_TheMaxAmountOfFuelInLiters;
                    float m_maxValue = 0.0f;
                    try
                    {
                        if (vehicle.fuelInstance.m_TheCurrentAmountOfFuelInLiters + i_HowManyFuelToAdd <= vehicle.fuelInstance.m_TheMaxAmountOfFuelInLiters)
                        {
                            vehicle.fuelInstance.m_TheCurrentAmountOfFuelInLiters += i_HowManyFuelToAdd;
                            Console.WriteLine($"Successfully refueled {i_HowManyFuelToAdd} liters of {i_FuelType} for vehicle {i_licenseNumber}.");
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(m_maxValue, m_minValue);
                        }
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: The specified fuel type does not match the vehicle's fuel type.");
                }
            }
        }
        public static void ChargeAnElectricVehicle(string i_LicenseNumber, float HowManyMinuteToAdd)
        {
        foreach (Vehicle vehicle in r_Vehicles)
        {
                if (vehicle.m_LicenseNumber == i_LicenseNumber)
                {
                    float m_minValue = vehicle.electriclInstance.m_MaximumBatteryTimeInHours;
                    float m_maxValue = 0.0f;
                    try
                    {
                        if (vehicle.electriclInstance.m_BatteryTimeRemainingInHours + HowManyMinuteToAdd / 60 <= vehicle.electriclInstance.m_MaximumBatteryTimeInHours)
                        {
                            vehicle.electriclInstance.m_BatteryTimeRemainingInHours += HowManyMinuteToAdd / 60;

                            Console.WriteLine($"Successfully charge {HowManyMinuteToAdd} minutes for vehicle {i_LicenseNumber}.");
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(m_maxValue, m_minValue);
                        }
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public static void DisplayCompleteDataOfTheVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in r_Vehicles)
            {
                if (vehicle.m_LicenseNumber == i_LicenseNumber)
                {
                    if (vehicle is CarOnElectric)
                    {
                        string CarOnElectricPrint = string.Format(
                                                "Client Name: {0}\n" +
                                                "Client Phone: {1}\n" +
                                                "Condition: {2}\n" +
                                                "Model of the Car: {3}\n" +
                                                "License Number: {4}\n" +
                                                "Energy Left: {5}\n" +
                                                "Manufacturer Name: {6}\n" +
                                                "Current Air Pressure: {7}\n" +
                                                "Maximum air pressure: {8}\n" +
                                                "Battery Time Remaining: {9}\n" +
                                                "Maximum battery time in hours:{10}\n" +
                                                "Color: {11}\n" +
                                                "Number of Doors: {12}"+
                                                "Number of Wheels: {13}\n", vehicle.m_ClientDetails.m_ClientName
                                                                         , vehicle.m_ClientDetails.m_ClientPhone
                                                                         , vehicle.m_ClientDetails.m_Condition.ToString()
                                                                         , vehicle.m_ModelOfTheCar
                                                                         , vehicle.m_LicenseNumber
                                                                         , vehicle.m_EnergyLeft.ToString()
                                                                          , vehicle.m_Tires[0].m_ManufacturerName
                                                                          , vehicle.m_Tires[0].m_CurrentAirPressure.ToString()
                                                                          , "30.0"
                                                                          , vehicle.electriclInstance.m_BatteryTimeRemainingInHours.ToString()
                                                                          , "4.8"
                                                                          , m_Color.ToString()
                                                                          , m_NumberOfDoors.ToString()
                                                                          ,"5");
                        Console.WriteLine(CarOnElectricPrint);
                    }
                    if (vehicle is CarOnFuel)
                    {
                        string CarOnFuelPrint = string.Format(
                                                "Client Name: {0}\n" +
                                                "Client Phone: {1}\n" +
                                                "Condition: {2}\n" +
                                                "Model of the Car: {3}\n" +
                                                "License Number: {4}\n" +
                                                "Energy Left: {5}\n" +
                                                "Manufacturer Name: {6}\n" +
                                                "Current Air Pressure: {7}\n" +
                                                "Maximum air pressure: {8}\n" +
                                                "//Type of fuel{9}\n" +
                                                "Current amount of fuel in liters:{10}\n" +
                                                "TheMaxAmountOfFuelInLiters: {11}\n" +
                                                "Color: {12}\n" +
                                                "Number of Doors: {13}"+
                                                "Number of Wheels: {14}\n", vehicle.m_ClientDetails.m_ClientName
                                                                         , vehicle.m_ClientDetails.m_ClientPhone
                                                                         , vehicle.m_ClientDetails.m_Condition.ToString()
                                                                         , vehicle.m_ModelOfTheCar
                                                                         , vehicle.m_LicenseNumber
                                                                         , vehicle.m_EnergyLeft.ToString()
                                                                          , vehicle.m_Tires[0].m_ManufacturerName
                                                                          , vehicle.m_Tires[0].m_CurrentAirPressure.ToString()
                                                                          , "30"
                                                                          , "Octan95"
                                                                          , vehicle.fuelInstance.m_TheCurrentAmountOfFuelInLiters.ToString()
                                                                          , "58.0"
                                                                          , m_Color.ToString()
                                                                          , m_NumberOfDoors.ToString()
                                                                          ,"5");
                        Console.WriteLine(CarOnFuelPrint);
                    }
                    if (vehicle is MotorcycleOnElectric)
                    {
                        string MotorcycleOnElectricPrint = string.Format(
                                                "Client Name: {0}\n" +
                                                "Client Phone: {1}\n" +
                                                "Condition: {2}\n" +
                                                "Model of the Car: {3}\n" +
                                                "License Number: {4}\n" +
                                                "Energy Left: {5}\n" +
                                                "Manufacturer Name: {6}\n" +
                                                "Current Air Pressure: {7}\n" +
                                                "Maximum air pressure: {8}\n" +
                                                "Battery Time Remaining: {9}\n" +
                                                "Maximum battery time in hours:{10}\n" +
                                                "Licence type: {11}\n" +
                                                "Number of Doors: {12}"+
                                                "Number of Wheels: {13}\n" 
                                                                        , vehicle.m_ClientDetails.m_ClientName
                                                                         , vehicle.m_ClientDetails.m_ClientPhone
                                                                         , vehicle.m_ClientDetails.m_Condition.ToString()
                                                                         , vehicle.m_ModelOfTheCar
                                                                         , vehicle.m_LicenseNumber
                                                                         , vehicle.m_EnergyLeft.ToString()
                                                                          , vehicle.m_Tires[0].m_ManufacturerName
                                                                          , vehicle.m_Tires[0].m_CurrentAirPressure.ToString()
                                                                          , "29.0"
                                                                          , vehicle.electriclInstance.m_BatteryTimeRemainingInHours.ToString()
                                                                          , "2.8"
                                                                          , m_LicenseType
                                                                          , m_EngineVolumeInCc.ToString()
                                                                          , "2");
                        Console.WriteLine(MotorcycleOnElectricPrint);
                    }
                    if (vehicle is MotorcycleOnFuel)
                    {
                        string MotorcycleOnFuelPrint = string.Format(
                                                "Client Name: {0}\n" +
                                                "Client Phone: {1}\n" +
                                                "Condition: {2}\n" +
                                                "Model of the Car: {3}\n" +
                                                "License Number: {4}\n" +
                                                "Energy Left: {5}\n" +
                                                "Manufacturer Name: {6}\n" +
                                                "Current Air Pressure: {7}\n" +
                                                "Maximum air pressure: {8}\n" +
                                                "/Type of fuel: {9}\n" +
                                                "CurrentAmountOfFuelInLiters:{10}\n" +
                                                "Maximum in liters: {11}\n" +
                                                "Licence Type: {12}:\n" +
                                                "Number of Doors: {13}" +
                                                "Number of Wheels: {14}:\n"
                                                                        , vehicle.m_ClientDetails.m_ClientName
                                                                         , vehicle.m_ClientDetails.m_ClientPhone
                                                                         , vehicle.m_ClientDetails.m_Condition.ToString()
                                                                         , vehicle.m_ModelOfTheCar
                                                                         , vehicle.m_LicenseNumber
                                                                         , vehicle.m_EnergyLeft.ToString()
                                                                          , vehicle.m_Tires[0].m_ManufacturerName
                                                                          , vehicle.m_Tires[0].m_CurrentAirPressure.ToString()
                                                                          , "29.0"
                                                                          , "Octagon98"
                                                                          , vehicle.fuelInstance.m_TheCurrentAmountOfFuelInLiters
                                                                          , "5.8"
                                                                          , m_LicenseType
                                                                          , m_EngineVolumeInCc.ToString()
                                                                          , "2");
                        Console.WriteLine(MotorcycleOnFuelPrint);
                    }
                    if (vehicle is Truck)
                    {
                        string TruckPrint = string.Format(
                                                "Client Name: {0}\n" +
                                                "Client Phone: {1}\n" +
                                                "Condition: {2}\n" +
                                                "Model of the Car: {3}\n" +
                                                "License Number: {4}\n" +
                                                "Energy Left: {5}\n" +
                                                "Manufacturer Name: {6}\n" +
                                                "Current Air Pressure: {7}\n" +
                                                "Maximum air pressure: {8}\n" +
                                                "Type of fuel: {9}\n" +
                                                "CurrentAmountOfFuelInLiters:{10}\n" +
                                                "Maximum in liters: {11}\n" +
                                                "Have hazardous materials: {12}\n" +
                                                "CargoVolumes: {13}\n"+
                                                "Number os wheels:{14}"
                                                                        , vehicle.m_ClientDetails.m_ClientName
                                                                         , vehicle.m_ClientDetails.m_ClientPhone
                                                                         , vehicle.m_ClientDetails.m_Condition.ToString()
                                                                         , vehicle.m_ModelOfTheCar
                                                                         , vehicle.m_LicenseNumber
                                                                         , vehicle.m_EnergyLeft.ToString()
                                                                          , vehicle.m_Tires[0].m_ManufacturerName
                                                                          , vehicle.m_Tires[0].m_CurrentAirPressure.ToString()
                                                                          , "29.0"
                                                                          , "Octagon98"
                                                                          , vehicle.fuelInstance.m_TheCurrentAmountOfFuelInLiters
                                                                          , "110.0"
                                                                          , vehicle.trucklInstance.m_HazardousMaterials
                                                                          , vehicle.trucklInstance.m_CargoVolume.ToString()
                                                                          , "12");
                        Console.WriteLine(TruckPrint);
                    }
                }
            }
        }
    }
}

  


