using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
//using System.ComponentModel;
using VehicleCreator = Ex03.GarageLogic.VehicleCreator;
using GarageManager = Ex03.GarageLogic.GarageManager;
using Vehicle = Ex03.GarageLogic.Vehicle;
using  Ex03.GarageLogic;
using static Ex03.GarageLogic.Garage;
using static Ex03.GarageLogic.Car;

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
                case eActions.showVehicleInGarage: //done
                    ShowVehiclesInGarage();
                    break;
                case eActions.changeVeihcleStatus: //done
                    ChangeVeihcleStatus();
                    break;
                case eActions.inflateTiersToMax:
                    inflateTiersToMax(); //done
                    break;
                case eActions.fillFuelTank:
                    fillFuelType(); //done
                    break;
                case eActions.chargevehicleBattery:
                    chargeBattery(); //done
                    break;
                case eActions.getVehicleByPlateNum:
                    ShowVehicleState();
                    break;
                case eActions.exit:
                    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException();
            }
        }

        private void ShowVehicleState()
        {
            Console.WriteLine("enter the vehicle License number");
            string plateNumber = GetLicenseNumberOfVehicle();
            if (!m_GarageManager.Garage.isVehicleInGarage(plateNumber))
            {
                throw new ArgumentException();
            }

            Console.WriteLine(m_GarageManager.Garage.VehiclesInGarage[plateNumber].ToString());
        }

        private void chargeBattery()
        {
            Console.WriteLine("enter the vehicle License number");
            string plateNumber = GetLicenseNumberOfVehicle();
            if (!m_GarageManager.Garage.isVehicleInGarage(plateNumber))
            {
                throw new ArgumentException();
            }

            Console.WriteLine("enter the number of minutes to charge");
            int.TryParse(Console.ReadLine(), out int numOfMinutesToAdd);

            ElectricEngine dieselEngine = m_GarageManager.Garage.VehiclesInGarage[plateNumber].Vehicle.Engine as ElectricEngine;
            dieselEngine.AddEnergyToEngine(numOfMinutesToAdd);
        }

        private void fillFuelType()
        {
            Console.WriteLine("enter the vehicle License number");
            string plateNumber = GetLicenseNumberOfVehicle();
            if (!m_GarageManager.Garage.isVehicleInGarage(plateNumber))
            {
                throw new ArgumentException();
            }

            Console.WriteLine("enter the vehicle fuel type");
            PrintEnumOptions<DieselEngine.eFuelType>();
            Enum.TryParse(Console.ReadLine(), out DieselEngine.eFuelType fuelType);
            Console.WriteLine("how much fuel would you like to add?");
            float.TryParse(Console.ReadLine(), out float fuelToAdd);

            DieselEngine dieselEngine = m_GarageManager.Garage.VehiclesInGarage[plateNumber].Vehicle.Engine as DieselEngine;
            dieselEngine.AddEnergyToEngine(fuelToAdd, fuelType);



        }

        private void inflateTiersToMax()
        {
            Console.WriteLine("enter the vehicle License number");
            string plateNumber = GetLicenseNumberOfVehicle();
            if (!m_GarageManager.Garage.isVehicleInGarage(plateNumber))
            {
                throw new ArgumentException();
            }

            m_GarageManager.InflateTiersToMax(plateNumber);
        }

        private void ChangeVeihcleStatus()
        {
            string plateNumber = GetLicenseNumberOfVehicle();
            if(!m_GarageManager.Garage.isVehicleInGarage(plateNumber))
            {
                throw new ArgumentException();
            }

            GaragedVehicle.eVehicleStatus newStatus = ChooseStatusOfVehicle();
            m_GarageManager.setStatusOfAVehicle(plateNumber, newStatus);
        }

        private GaragedVehicle.eVehicleStatus ChooseStatusOfVehicle()
        {
            GaragedVehicle.eVehicleStatus status;
            Console.WriteLine("Please choose one of the following options:");
            printStatusMenu();
            Enum.TryParse(Console.ReadLine(), out status);

            return status;
        }

        private void ShowVehiclesInGarage()
        {
            GaragedVehicle.eVehicleStatus filter = ChooseStatusOfVehicle();
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
                updateGarageVehicleStatusToBeingRepaired(plateNumberOfVehicle);            }
            else
            {
                VehicleCreator.eSupportedVehicleTypes vehicleType = GetVehicleTypeFromUser();
                Vehicle newVehicleToEnterToGarage = CreateVehicleWithBasicDataMembersFromUser(vehicleType, plateNumberOfVehicle);
                if(newVehicleToEnterToGarage.isElectric(vehicleType))
                {
                    newVehicleToEnterToGarage.Engine = new ElectricEngine();
                }
                else
                {
                    newVehicleToEnterToGarage.Engine = new DieselEngine();
                }
                updateEngineDetails(newVehicleToEnterToGarage);
                GetWheelsDetailsFromUser(newVehicleToEnterToGarage);
                GetDeclaredOnlyPropertiesFromUser(newVehicleToEnterToGarage);
                createAndAddGarageVehicle(newVehicleToEnterToGarage);
            }
        }

        private void updateEngineDetails(Vehicle i_Vehicle)
        {
            getEngineDetailsFromUser(i_Vehicle.Engine);
            updateEnergyPrecentleft(i_Vehicle);
        }

        private void updateEnergyPrecentleft(Vehicle i_Vehicle)
        {
            i_Vehicle.EnergyPrecentleft = (float)Math.Round(i_Vehicle.Engine.EnergyAmountLeft / i_Vehicle.Engine.MaxEnergyPossibleAmount, 2);            
        }

        private void getEngineDetailsFromUser(Engine i_Engine)
        {
            Console.WriteLine("Please enter engine's energy amount left");
            float.TryParse(Console.ReadLine(), out float energyAmountLeft);
            i_Engine.EnergyAmountLeft = energyAmountLeft;
            Console.WriteLine("Please enter engine's max energy possible amount");
            float.TryParse(Console.ReadLine(), out float maxEnergyPossibleAmount);
            i_Engine.MaxEnergyPossibleAmount = maxEnergyPossibleAmount;
        }

        private void updateEnergyPrecentleft()
        {

        }

        private void updateGarageVehicleStatusToBeingRepaired(string i_PlateNumberOfVehicle)
        {
            m_GarageManager.Garage.VehiclesInGarage[i_PlateNumberOfVehicle].VehicleStatus = GaragedVehicle.eVehicleStatus.BeingRepaired;
        }

        public void createAndAddGarageVehicle(Vehicle i_Vehicle)
        {
            GaragedVehicle newVehicleToEnterGarage = new GaragedVehicle();
            newVehicleToEnterGarage.Vehicle = i_Vehicle;
            GetOwnerDetails(newVehicleToEnterGarage);
            m_GarageManager.Garage.VehiclesInGarage.Add(newVehicleToEnterGarage.Vehicle.PlateNumber, newVehicleToEnterGarage);
        }

        public void GetOwnerDetails(GaragedVehicle i_GarageVehicle)
        {
            Console.WriteLine("Please enter owner's name");
            i_GarageVehicle.OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter owner's phone number");
            i_GarageVehicle.OwnerPhoneNumber = Console.ReadLine();
        }

        public void GetDeclaredOnlyPropertiesFromUser(Vehicle i_Vehicle)
        {
            List<string> declaredOnlyProperties = GetDeclaredOnlyPropertiesOfObjectWhichHaveSetters(i_Vehicle);

            foreach (string dataMember in declaredOnlyProperties)
            {
                askUserToEnterPropertyValue(i_Vehicle, dataMember);
                string userInputForDataMember = Console.ReadLine();
                setProperty(i_Vehicle, dataMember, userInputForDataMember);
            }
        }
        


        private void setProperty(object i_obj, string i_DataMember, string i_DataMemberValue)
        {
            Type type = i_obj.GetType();
            PropertyInfo dataMemberInfo = type.GetProperty(i_DataMember);
            MethodInfo setMethod = dataMemberInfo.GetSetMethod();
            object valueToSet;

            if (dataMemberInfo.PropertyType.IsEnum)
            {
                if (!Enum.IsDefined(dataMemberInfo.PropertyType, i_DataMemberValue))
                {
                    throw new FormatException();
                }

                valueToSet = Enum.Parse(dataMemberInfo.PropertyType, i_DataMemberValue);
            }
            else
            {
                valueToSet = Convert.ChangeType(i_DataMemberValue, dataMemberInfo.PropertyType);
            }     
            
            setMethod.Invoke(i_obj, new object[] { valueToSet });
        }

        public void PrintEnumOptions<T>()
        {
            if (!typeof(T).IsEnum)
            {
                Console.WriteLine("Invalid type. Please provide an enum type.");
                return;
            }

            Console.Write("Choose one of the followings (case sensitive): ");

            T[] enumValues = (T[])Enum.GetValues(typeof(T));
            string joinedOptions = string.Join(", ", enumValues);
            Console.WriteLine(joinedOptions);

        }
        
        public void askUserToEnterPropertyValue(object i_Obj, string i_DataMember)
        {
            if (!string.IsNullOrEmpty(i_DataMember))
            {
                Console.WriteLine(createMsgForUserToEnterCurrentProperty(i_DataMember));
                checkIfEnumAndAskUserForSpecificValues(i_Obj, i_DataMember);
                //checkIfBoolAndAskUserForSpecificValues(i_Obj, i_DataMember);
            }
        }

        public StringBuilder createMsgForUserToEnterCurrentProperty(string i_DataMember)
        {
            StringBuilder msgForUserToEnterCurrentDataMember = new StringBuilder("Please enter the vehicle's ");

            for (int i = 0; i < i_DataMember.Length; i++)
            {
                char currentChar = i_DataMember[i];

                if (char.IsUpper(currentChar))
                {
                    if (i > 0)
                    {
                        msgForUserToEnterCurrentDataMember.Append(' ');
                    }

                    msgForUserToEnterCurrentDataMember.Append(char.ToLowerInvariant(currentChar));
                }
                else
                {
                    msgForUserToEnterCurrentDataMember.Append(currentChar);
                }
            }
        
            return msgForUserToEnterCurrentDataMember;
        }

        public void checkIfEnumAndAskUserForSpecificValues(object i_Obj, string i_DataMember)
        {
            Type type = i_Obj.GetType();
            PropertyInfo dataMemberInfo = type.GetProperty(i_DataMember);

            if (dataMemberInfo.PropertyType.IsEnum)
            {
                AskUserToEnterSpecificEnumValues(i_Obj, dataMemberInfo);
            }
        }

        public void AskUserToEnterSpecificEnumValues(object i_Obj, PropertyInfo i_DataMemberInfo)
        {
            Type enumType = i_DataMemberInfo.PropertyType;
            object instance = Activator.CreateInstance(this.GetType());
            MethodInfo printEnumOptionsMethod = instance.GetType().GetMethod("PrintEnumOptions").MakeGenericMethod(enumType);
            printEnumOptionsMethod.Invoke(instance, null);
        }

        public List<string> GetDeclaredOnlyPropertiesOfObjectWhichHaveSetters(object i_Obj)
        {
            Type type = i_Obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            List<string> declaredOnlyPropertiesOfObjectWhichHaveSetters = new List<string>();

            foreach (PropertyInfo property in properties)
            {
                if(property.CanWrite)
                {
                    declaredOnlyPropertiesOfObjectWhichHaveSetters.Add(property.Name);
                }
            }

            return declaredOnlyPropertiesOfObjectWhichHaveSetters;
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
                for (int i = 0; i < i_vehicle.Wheels.Capacity; i++)
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

        public Vehicle CreateVehicleWithBasicDataMembersFromUser(VehicleCreator.eSupportedVehicleTypes vehicleType, string i_PlateNumberOfVehicle)
        {
            Console.WriteLine("Please enter model of vehicle");
            string modelOfVehicle = Console.ReadLine();

            return m_VehicleCreator.buildVehicleByType(vehicleType, modelOfVehicle, i_PlateNumberOfVehicle);
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
            Console.WriteLine("Please enter plate number of vehicle");
            return Console.ReadLine();
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

        public eNumOfDoors ChooseNumOfDoors()
        {
            Console.WriteLine("choose number of doors from the list");
            foreach (eNumOfDoors value in Enum.GetValues(typeof(eNumOfDoors)))
            {
                Console.WriteLine(value.ToString());
            }

            Enum.TryParse(Console.ReadLine(), out eNumOfDoors res);
            return res;
        }

        public eColor ChooseCarColor()
        {
            Console.WriteLine("choose the color of the car from the list");
            foreach (eColor value in Enum.GetValues(typeof(eColor)))
            {
                Console.WriteLine(value.ToString());
            }

            Enum.TryParse(Console.ReadLine(), out eColor res);
            return res;
        }

    }
}
