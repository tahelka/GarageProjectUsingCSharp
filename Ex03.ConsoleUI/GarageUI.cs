using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using VehicleCreator = Ex03.GarageLogic.VehicleCreator;
using GarageManager = Ex03.GarageLogic.GarageManager;
using Vehicle = Ex03.GarageLogic.Vehicle;

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
            chargeVehicalBattery,
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

                case eActions.changeVeihcleStatus:

                case eActions.inflateTiersToMax:

                case eActions.fillFuelTank:

                case eActions.chargeVehicalBattery:

                case eActions.getVehicleByPlateNum:

                case eActions.exit:
                    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException();
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
1. Enter New Vechicle to the garage
2. Show Vehicles In the Garage
3. Change the status of Veihcle in the garage
4. inflate Tiers of a vehical To Maximum
5. fill Fuel the Tank
6. Charge Vehical Battery
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
            //vhicle.getDetails()


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
                printAllSupportedVehicaleTypes();
                Enum.TryParse(Console.ReadLine(), out vehicleChosenType);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("out of range");
                GetVehicleTypeFromUser();
            }

            return vehicleChosenType;
        }

        public void printAllSupportedVehicaleTypes()
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
