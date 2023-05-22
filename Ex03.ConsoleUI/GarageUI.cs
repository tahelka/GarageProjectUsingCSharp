using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using VehicleCreator = Ex03.GarageLogic.VehicleCreator;
using GarageManager = Ex03.GarageLogic.GarageManager;
using Vehicle = Ex03.GarageLogic.Vehicle;
using  Ex03.GarageLogic;
using static Ex03.GarageLogic.Garage;

namespace Ex03.ConsoleUI
{
    
    public class GarageUI
    {
        VehicleCreator m_VehicleCreator;
        GarageManager m_GarageManager;

        public GarageUI()
        {
            m_VehicleCreator = new VehicleCreator();
            m_GarageManager = new GarageManager();
        }
        public enum eActions
        {
            enterNewVechicle = 1,
            showVehicleInGarage,
            changeVeihcleStatus,
            inflateTiersToMax,
            fillFuelTank,
            chargevehicleBattery,
            getVehicleByPlateNum,
            exit
        }
        public void ChooseAction()
        {
            eActions action = getActionNumber();
            switch (action)
            {
                case eActions.enterNewVechicle:
                    EnterNewVehicleToGarage();
                    break;
                case eActions.showVehicleInGarage:
                    ShowVehiclesInGarage();
                    break;
                case eActions.changeVeihcleStatus:

                case eActions.inflateTiersToMax:

                case eActions.fillFuelTank:

                case eActions.chargevehicleBattery:

                case eActions.getVehicleByPlateNum:

                case eActions.exit:
                    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException();
            }
        }

        private void ShowVehiclesInGarage()
        {
            GaragedVehicle.eVehicleStatus filter;
            Console.WriteLine("Please choose one of the following options:");
            printStatusMenu();
            Enum.TryParse(Console.ReadLine(), out filter);

            PrintVehiclesByFilter(filter);
        }

        private void PrintVehiclesByFilter(GaragedVehicle.eVehicleStatus i_Filter)
        {
            Console.WriteLine(
                i_Filter != GaragedVehicle.eVehicleStatus.All
                    ? $"All vehicles in the garage in status {i_Filter}:"
                    : "All vehicles in the garage:");

            List<string> vehiclesList = m_GarageManager.getVehiclesPlateNumbersByStatus(i_Filter);
            if(vehiclesList != null)
            {
                foreach(string plateNumber in vehiclesList)
                {
                    Console.WriteLine(plateNumber);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        private void printStatusMenu()
        {
            foreach (Garage.GaragedVehicle.eVehicleStatus status in Enum.GetValues(typeof(Garage.GaragedVehicle.eVehicleStatus)))
            {
                int value = (int)status;
                string optionName = status.ToString();
                Console.WriteLine($"{value}. {optionName}");
            }
        }

        public eActions getActionNumber()
        {
            eActions chosenActionByUser = 0;

            try
            {
                Console.WriteLine("Please choose one of the following options:");
                printActionsMenu();
                Enum.TryParse(Console.ReadLine(), out chosenActionByUser);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("out of range");
                getActionNumber();
            }

            return chosenActionByUser;
        }


        public void printActionsMenu()
        {
            Console.WriteLine($@"
1. Enter New vehicle to the garage
2. Show Vehicles In the Garage
3. Change the status of vehicle in the garage
4. inflate Tiers of a vehicle To Maximum
5. fill Fuel the Tank
6. Charge vehicle Battery
7. get Vehicle details
8. exit");
        }

        public void EnterNewVehicleToGarage()
        {         
            string plateNumberOfVehicle = GetLicenseNumberOfVehicle();
            bool isVehicleInGarage = m_GarageManager.Garage.isVehicleInGarage(plateNumberOfVehicle);

            if (isVehicleInGarage)
            {
                //
            }
            else
            {
                VehicleCreator.eSupportedVehicleTypes vehicleType = GetVehicleTypeFromUser();
                Vehicle newVehicleToEnterToGarage = CreateVehicleWithBasicPropertiesFromUser(vehicleType, plateNumberOfVehicle);
                newVehicleToEnterToGarage.m_Engine.UpdateEngineIfVehicleIsElectric(vehicleType);
                GetWheelsDetailsFromUser(newVehicleToEnterToGarage);
                

            }
        }

        public void GetWheelsDetailsFromUser(Vehicle i_vehicle)
        {
            string wheelManufacturer;
            int WheelMaxTierPressureByManufacturer;
            int wheelCurrentTierPressure;

            Console.WriteLine("Would you like to set all wheels with the same parameters? Y/N");
            string userAnswer = Console.ReadLine();
            if(userAnswer != "Y" && userAnswer != "N")
            {
                throw new Exception("Invalid Input");
            }

            if (userAnswer == "Y")
            {
                askUserForWheelDetails(out wheelManufacturer, out WheelMaxTierPressureByManufacturer, out wheelCurrentTierPressure);
                i_vehicle.attachAllWheelsWithSameDetails(wheelManufacturer, WheelMaxTierPressureByManufacturer, wheelCurrentTierPressure); 
            }
            else
            {
                for (int i = 0; i < i_vehicle.m_Wheels.Capacity; i++)
                {
                    askUserForWheelDetails(out wheelManufacturer, out WheelMaxTierPressureByManufacturer, out wheelCurrentTierPressure);
                    i_vehicle.attachWheel(wheelManufacturer, WheelMaxTierPressureByManufacturer, wheelCurrentTierPressure);
                }
            }
        }

        public void askUserForWheelDetails(out string o_Manufacturer, out int o_MaxTierPressureByManufacturer, out int o_CurrentTierPressure)
        {
            Console.WriteLine("Please enter wheel manufacturer");
            o_Manufacturer = Console.ReadLine();

            Console.WriteLine("Please enter max tier pressure by manufacturer");
            int.TryParse(Console.ReadLine(), out o_MaxTierPressureByManufacturer);
            // check if parse did well

            Console.WriteLine("Please enter current tier pressure");
            int.TryParse(Console.ReadLine(), out o_CurrentTierPressure);
            // check if parse did well

        }

        public Vehicle CreateVehicleWithBasicPropertiesFromUser(VehicleCreator.eSupportedVehicleTypes vehicleType, string i_PlateNumberOfVehicle)
        {
            Console.WriteLine("Please enter model of vehicle");
            string modelOfVehicle = Console.ReadLine();
            
            Console.WriteLine("Please enter energy precent left in vehicle");
            if(!float.TryParse(Console.ReadLine(), out float energyPrecentLeft))
            {
                throw new FormatException();
            }

            return m_VehicleCreator.buildVehicleByType(vehicleType, modelOfVehicle, i_PlateNumberOfVehicle, energyPrecentLeft);

        }


        public bool isVehicleElectric()
        {
            bool isElectricVehicle;

            Console.WriteLine("Is your vehicle on battery? Y/N");
            string userChoice = Console.ReadLine();
            if (userChoice != "Y" && userChoice != "N")
            {
                throw new Exception("Please Enter Y/N");
            }

            isElectricVehicle = userChoice == "Y" ? true : false;           

            return isElectricVehicle;
        }
        
        public string GetLicenseNumberOfVehicle()
        {
            Console.WriteLine("Please enter Number Of Vehicle");
            return Console.ReadLine();
        }

        public void GetOwnerDetails(GaragedVehicle i_VehicleInGarage)
        {
            // DRAFT! NOT READY METHOD

            Console.WriteLine("Please enter owner's name");
            i_VehicleInGarage.OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter owner's phone number");
            i_VehicleInGarage.OwnerPhoneNumber = int.Parse(Console.ReadLine());

            i_VehicleInGarage.VehicleStatus = GaragedVehicle.eVehicleStatus.BeingRepaired;
        }

        public VehicleCreator.eSupportedVehicleTypes GetVehicleTypeFromUser()
        {
            VehicleCreator.eSupportedVehicleTypes vehicleChosenType = 0;

            try
            {
                Console.WriteLine("Please enter vehicle type from the following options which you would like to enter into our garage");
                printAllSupportedvehicleeTypes();
                Enum.TryParse(Console.ReadLine(), out vehicleChosenType);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("out of range");
                GetVehicleTypeFromUser();
            }

            return vehicleChosenType;
        }

        public void printAllSupportedvehicleeTypes()
        {
            foreach (VehicleCreator.eSupportedVehicleTypes action in Enum.GetValues(typeof(VehicleCreator.eSupportedVehicleTypes)))
            {
                int value = (int)action;
                string optionName = action.ToString();
                Console.WriteLine($"{value}. {optionName}");
            }
        }

    }
}
