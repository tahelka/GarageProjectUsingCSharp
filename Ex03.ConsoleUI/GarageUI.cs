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
            VehicleCreator.eSupportedVehicleTypes vehicleType = GetVehicleTypeFromUser();
            Vehicle newVehicleToEnterToGarage = m_VehicleCreator.buildVehicleByType(vehicleType);

            askUserEnterDetailsOfVehicle(newVehicleToEnterToGarage);

            // enter number, color, wheels

            //create the vehicle
            //vehicle.getDetails()


        }

        public void askUserEnterDetailsOfVehicle(Vehicle i_Vehicle)
        {
            Type typeOfVehicle = i_Vehicle.GetType();
            MethodInfo[] allMethods = typeOfVehicle.GetMethods();
            List<ParameterInfo[]> methodsParamsOfGivenVehicle = new List<ParameterInfo[]>();


            foreach (MethodInfo method in allMethods)
            {
                methodsParamsOfGivenVehicle.Add(method.GetParameters());
            }

            int i = 1;
            foreach (ParameterInfo[] param in methodsParamsOfGivenVehicle)
            {
                Console.WriteLine($"params of method number {i}");
                foreach (ParameterInfo par in param)
                {
                    Console.WriteLine(par.Name);

                }
                i++;
            }


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
