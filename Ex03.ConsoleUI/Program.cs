using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.ClientDetails;
using static Ex03.GarageLogic.Fuel;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        static void Main()
        {
            GarageManager garageManager = new GarageManager();
            GarageFunction garageFunction = new GarageFunction(garageManager);

            while (true)
            {
                Console.WriteLine("Choose what you want to do:");
                Console.WriteLine("1. Enter new Vehicles");
                Console.WriteLine("2. View the list of license numbers");
                Console.WriteLine("3. Change the status of a car in the garage");
                Console.WriteLine("4. Inflate the tires to the maximum");
                Console.WriteLine("5. Refuel a fuel-driven vehicle");
                Console.WriteLine("6. Charge an electric vehicle");
                Console.WriteLine("7. Display complete data of the vehicle");
                Console.WriteLine("8. Quit");

                string userChoiceStr = Console.ReadLine();
                int userChoice = 0;

                try
                {
                    userChoice = int.Parse(userChoiceStr);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        int choiceKindOfVehicle = garageFunction.ChooseVehicleType();
                        bool IslicenseNumberFound = garageFunction.ChecksIfTheVehicleIsFound();
                        
                        if (IslicenseNumberFound == false)
                        {
                            switch (choiceKindOfVehicle)
                            {
                                case 0:
                                    GarageFunction.addVehicle(GarageFunction.GetCarOnFuelDetails(garageFunction.io_licenseNumber));

                                    break;
                                case 1:
                                    GarageFunction.addVehicle(GarageFunction.GetCarOnElectricDetails(garageFunction.io_licenseNumber));

                                    break;
                                case 2:
                                    GarageFunction.addVehicle(GarageFunction.GetMotorcycleOnFuelDetails(garageFunction.io_licenseNumber));

                                    break;
                                case 3:
                                    GarageFunction.addVehicle(GarageFunction.GetMotorcycleOnElectricDetails(garageFunction.io_licenseNumber));
                                    break;
                                case 4:
                                    GarageFunction.addVehicle(GarageFunction.GetTruckDetails(garageFunction.io_licenseNumber));
                                    break;
                                default:
                                    Console.WriteLine("Invalid vehicle type.");
                                    break;
                            }
                        }
                        else
                        {
                            garageFunction.ChecksIfTheVehicleIsFound();
                        }
                        break;
                    case 2:
                        garageFunction.ViewTheListOfLicenseNumbersWithFilter();
                        break;
                    case 3:
                        Console.WriteLine("Enter the license number of the vehicle:");
                        string i_LicenseNumber = Console.ReadLine();

                        Console.WriteLine("Enter the new condition of the vehicle (InRepair, Repaired, Paid):");
                        string newConditionStr = Console.ReadLine();

                        eVehicleCondition i_NewCondition;
                        if (!Enum.TryParse(newConditionStr, out i_NewCondition))
                        {
                            Console.WriteLine("Invalid condition entered.");
                            return;
                        }
                        garageFunction.ChangeCondition(i_LicenseNumber, i_NewCondition);
                        break;
                    case 4:
                        Console.WriteLine("Enter license number to flate air to the maximum ");
                        string i_LicenseNumber1 = Console.ReadLine();
                        garageFunction.InflateAirToTheMaximum(i_LicenseNumber1);
                        break;
                    case 5:
                        Console.WriteLine("Enter the license number of the vehicle:");
                        string i_licenseNumber = Console.ReadLine();
                        Console.WriteLine("Enter the fuel type (Soler, Octan96, Octan95, Octan98):");
                        string i_fuelTypeInput = Console.ReadLine();

                        eFuelTypes fuelType;
                        Enum.TryParse(i_fuelTypeInput, out fuelType);
                        Console.WriteLine("Enter the amount of fuel to add:");
                        string i_HowManyFuelToAddStr= Console.ReadLine();
                        float i_HowManyFuelToAdd;
                        if (!float.TryParse(i_HowManyFuelToAddStr, out i_HowManyFuelToAdd))
                        {
                            Console.WriteLine("Invalid amount of fuel.");
                            return;
                        }
                        GarageFunction.RefuelVehicleOnFuel(i_licenseNumber, fuelType, i_HowManyFuelToAdd);
                        break;
                    case 6:
                        Console.WriteLine("Enter the license number of the vehicle:");
                        string i_licenseNumber2 = Console.ReadLine();
                        Console.WriteLine("Enter how many miniuts you want to charge");
                        string i_HowManyMinuteToAddStr = Console.ReadLine();
                        float i_HowManyMinuteToAdd=float.Parse(i_HowManyMinuteToAddStr);
                        GarageFunction.ChargeAnElectricVehicle(i_licenseNumber2, i_HowManyMinuteToAdd);
                        break;
                    case 7:
                        Console.WriteLine("Enter the license number of the vehicle the you want to see all the data:");
                        string i_licenseNumber3 = Console.ReadLine();
                        GarageFunction.DisplayCompleteDataOfTheVehicle(i_licenseNumber3);
                        break;
                    case 8:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        
    }
}


