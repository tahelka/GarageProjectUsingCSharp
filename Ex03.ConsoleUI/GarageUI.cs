using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using VehicleCreator = Ex03.GarageLogic.VehicleCreator;
using Vehicle = Ex03.GarageLogic.Vehicle;
using  Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public bool IsGarageInAction { get; set; }
        private readonly VehicleCreator r_VehicleCreator;
        private readonly Garage r_Garage;

        public GarageUI()
        {
            r_VehicleCreator = new VehicleCreator();
            r_Garage = new Garage();
            IsGarageInAction = true;
        }

        public enum eActions
        {
            EnterNewVehicle = 1,
            ShowVehicleInGarage,
            ChangeVehicleStatus,
            InflateTiersToMax,
            FillFuelTank,
            ChargeVehicleBattery,
            GetVehicleByPlateNum,
            Exit
        }

        public void ChooseAction()
        {
            eActions action = getActionNumber();
            try
            {
                switch(action)
                {
                    case eActions.EnterNewVehicle:
                        enterNewVehicleToGarage();
                        break;
                    case eActions.ShowVehicleInGarage:
                        showVehiclesInGarage();
                        break;
                    case eActions.ChangeVehicleStatus:
                        changeVeihcleStatus();
                        break;
                    case eActions.InflateTiersToMax:
                        inflateTiersToMax();
                        break;
                    case eActions.FillFuelTank:
                        fillFuel();
                        break;
                    case eActions.ChargeVehicleBattery:
                        chargeBattery();
                        break;
                    case eActions.GetVehicleByPlateNum:
                        showVehicleState();
                        break;
                    case eActions.Exit:
                        IsGarageInAction = false;
                        break;
                    default:
                        throw new ValueOutOfRangeException(
                            (float)action,
                            (float)eActions.EnterNewVehicle,
                            (float)eActions.Exit);
                }
            }
            catch(ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void showVehicleState()
        {
            string plateNumber = getLicenseNumberOfVehicle();
            if (!r_Garage.IsVehicleInGarage(plateNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }
            Console.WriteLine("========================================");
            Console.WriteLine(r_Garage.GetGaragedVehicle(plateNumber).ToString());
            Console.WriteLine("========================================");
        }

        private void chargeBattery()
        {
            string plateNumber = getLicenseNumberOfVehicle();
            if (!r_Garage.IsVehicleInGarage(plateNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            Vehicle vehicle = r_Garage.GetGaragedVehicle(plateNumber).Vehicle;
            if (!(vehicle.Engine is ElectricEngine))
            {
                throw new ArgumentException("this vehicle energy source is not electricity");
            }

            Console.WriteLine("enter the number of minutes to charge");
            int.TryParse(Console.ReadLine(), out int numOfMinutesToAdd);
            ElectricEngine electricEngine = vehicle.Engine as ElectricEngine;
            electricEngine.AddEnergyToEngine(numOfMinutesToAdd);
            vehicle.UpdateEnergyPercentLeft();
        }

        private void fillFuel()
        {
            string plateNumber = getLicenseNumberOfVehicle();
            if (!r_Garage.IsVehicleInGarage(plateNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            Vehicle vehicle = r_Garage.GetGaragedVehicle(plateNumber).Vehicle;
            if(!(vehicle.Engine is DieselEngine))
            {
                throw new ArgumentException("this vehicle doesn't run on fuel");
            }

            Console.WriteLine("enter the vehicle fuel type");
            PrintEnumOptions<DieselEngine.eFuelType>();
            string fuelTypeAsString = Console.ReadLine();
            checkValidationOfEnumValue(typeof(DieselEngine.eFuelType), fuelTypeAsString);
            Enum.TryParse(fuelTypeAsString, out DieselEngine.eFuelType fuelType);
            Console.WriteLine("how much fuel would you like to add?");
            if(!float.TryParse(Console.ReadLine(), out float fuelToAdd))
            {
                throw new FormatException("Invalid input");
            }

            DieselEngine dieselEngine = vehicle.Engine as DieselEngine;
            dieselEngine.AddEnergyToEngine(fuelToAdd, fuelType);
            vehicle.UpdateEnergyPercentLeft();
        }

        private void inflateTiersToMax()
        {
            string plateNumber = getLicenseNumberOfVehicle();
            if (!r_Garage.IsVehicleInGarage(plateNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            r_Garage.GetGaragedVehicle(plateNumber).Vehicle.InflateTiersToMax();
        }

        private void changeVeihcleStatus()
        {
            string plateNumber = getLicenseNumberOfVehicle();
            if(!r_Garage.IsVehicleInGarage(plateNumber))
            {
                throw new ArgumentException("Vehicle is not in garage");
            }

            GaragedVehicle.eVehicleStatus newStatus = ChooseStatusOfVehicle();
            r_Garage.SetStatusOfAVehicle(plateNumber, newStatus);
        }

        private GaragedVehicle.eVehicleStatus ChooseStatusOfVehicle()
        {
            Console.WriteLine("Please choose one of the following options:");
            GaragedVehicle.PrintStatusMenu();
            if (!Enum.TryParse(Console.ReadLine(), out GaragedVehicle.eVehicleStatus status))
            {
                throw new FormatException($"{status} is not a valid option");
            }

            return status;
        }

        private void showVehiclesInGarage()
        {
            GaragedVehicle.eVehicleStatus filter = ChooseStatusOfVehicle();
            printVehiclesByFilter(filter);
        }

        private void printVehiclesByFilter(GaragedVehicle.eVehicleStatus i_Filter)
        {
            Console.WriteLine(
                Enum.IsDefined(typeof(GaragedVehicle.eVehicleStatus), i_Filter)
                    ? $"All vehicles in the garage in status {i_Filter}:"
                    : "All vehicles in the garage:");

            List<string> vehiclesList = r_Garage.GetVehiclesPlateNumbersByStatus(i_Filter);
            if(vehiclesList.Count > 0)
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

        private eActions getActionNumber()
        {
            Console.WriteLine("Please choose one of the following options:");
            printActionsMenu();
            Enum.TryParse(Console.ReadLine(), out eActions chosenActionByUser);
            return chosenActionByUser;
        }

        private void printActionsMenu()
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

        private void enterNewVehicleToGarage()
        {         
            string plateNumberOfVehicle = getLicenseNumberOfVehicle();
            bool isVehicleInGarage = r_Garage.IsVehicleInGarage(plateNumberOfVehicle);

            if (isVehicleInGarage)
            {
                updateGarageVehicleStatusToBeingRepaired(plateNumberOfVehicle);
            }
            else
            {
                VehicleCreator.eSupportedVehicleTypes vehicleType = getVehicleTypeFromUser();
                Vehicle newVehicleToEnterToGarage = createVehicleWithBasicDataMembersFromUser(vehicleType, plateNumberOfVehicle);
                if(newVehicleToEnterToGarage.IsElectric(vehicleType))
                {
                    newVehicleToEnterToGarage.Engine = new ElectricEngine();
                }
                else
                {
                    newVehicleToEnterToGarage.Engine = new DieselEngine();
                    getDieselEngineDetails((DieselEngine)newVehicleToEnterToGarage.Engine);
                }

                updateEngineDetails(newVehicleToEnterToGarage);
                getWheelsDetailsFromUser(newVehicleToEnterToGarage);
                getDeclaredOnlyPropertiesFromUser(newVehicleToEnterToGarage);
                createAndAddGarageVehicle(newVehicleToEnterToGarage);
            }
        }

        private void getDieselEngineDetails(DieselEngine i_Engine)
        {
            Console.WriteLine("Please enter vehicle's fuel type");
            askUserToEnterSpecificEnumValues(typeof(DieselEngine).GetProperty("FuelType"));
            string enumValueFromUser = Console.ReadLine();
            checkValidationOfEnumValue(typeof(DieselEngine.eFuelType), enumValueFromUser);
            Enum.TryParse(enumValueFromUser, out DieselEngine.eFuelType enumFuelType);
            i_Engine.FuelType = enumFuelType;
        }

        private void checkValidationOfEnumValue(Type i_EnumType, string i_EnumValue)
        {
            if (!Enum.IsDefined(i_EnumType, i_EnumValue))
            {
                throw new FormatException("Invalid enum value");
            }
        }

        private void updateEngineDetails(Vehicle i_Vehicle)
        {
            getEngineDetailsFromUser(i_Vehicle.Engine);
            i_Vehicle.UpdateEnergyPercentLeft();
        }

        private void getEngineDetailsFromUser(Engine i_Engine)
        {
            Console.WriteLine("Please enter engine's max energy possible amount");
            if(!float.TryParse(Console.ReadLine(), out float maxEnergyPossibleAmount))
            {
                throw new FormatException("Invalid input");
            }

            i_Engine.MaxEnergyPossibleAmount = maxEnergyPossibleAmount;
            Console.WriteLine("Please enter engine's energy amount left");
            if(!float.TryParse(Console.ReadLine(), out float energyAmountLeft))
            {
                throw new FormatException("Invalid Input");
            }

            i_Engine.EnergyAmountLeft = energyAmountLeft;
        }

        private void updateGarageVehicleStatusToBeingRepaired(string i_PlateNumberOfVehicle)
        {
            r_Garage.GetGaragedVehicle(i_PlateNumberOfVehicle).VehicleStatus = GaragedVehicle.eVehicleStatus.BeingRepaired;
        }

        private void createAndAddGarageVehicle(Vehicle i_Vehicle)
        {
            GaragedVehicle newVehicleToEnterGarage = new GaragedVehicle
            {
                Vehicle = i_Vehicle
            };
            getOwnerDetails(newVehicleToEnterGarage);
            r_Garage.AddVehicleToGarage(newVehicleToEnterGarage);
        }

        private void getOwnerDetails(GaragedVehicle i_GarageVehicle)
        {
            Console.WriteLine("Please enter owner's name");
            i_GarageVehicle.OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter owner's phone number");
            i_GarageVehicle.OwnerPhoneNumber = Console.ReadLine();
        }

        private void getDeclaredOnlyPropertiesFromUser(Vehicle i_Vehicle)
        {
            List<string> declaredOnlyProperties = getDeclaredOnlyPropertiesOfObjectWhichHaveSetters(i_Vehicle);

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
                checkValidationOfEnumValue(dataMemberInfo.PropertyType, i_DataMemberValue);
                valueToSet = Enum.Parse(dataMemberInfo.PropertyType, i_DataMemberValue);
            }
            else
            {
                valueToSet = Convert.ChangeType(i_DataMemberValue, dataMemberInfo.PropertyType);
            }     
            
            setMethod.Invoke(i_obj, new object[] { valueToSet });
        }
     
        private void askUserToEnterPropertyValue(object i_Obj, string i_DataMember)
        {
            if (!string.IsNullOrEmpty(i_DataMember))
            {
                Console.WriteLine(createMsgForUserToEnterCurrentProperty(i_DataMember));
                checkIfEnumOrBoolAndAskUserForSpecificValues(i_Obj, i_DataMember);
            }
        }

        private StringBuilder createMsgForUserToEnterCurrentProperty(string i_DataMember)
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

        private void checkIfEnumOrBoolAndAskUserForSpecificValues(object i_Obj, string i_DataMember)
        {
            Type type = i_Obj.GetType();
            PropertyInfo dataMemberInfo = type.GetProperty(i_DataMember);

            if (dataMemberInfo.PropertyType.IsEnum)
            {
                askUserToEnterSpecificEnumValues(dataMemberInfo);
            } 
            else if(dataMemberInfo.PropertyType == typeof(bool))
            {
                askUserForSpecificBoolValues();
            }
        }

        private void askUserForSpecificBoolValues()
        {
            Console.WriteLine("Type true/false (case sensitive): ");
        }

        private void askUserToEnterSpecificEnumValues(PropertyInfo i_DataMemberInfo)
        {
            Type enumType = i_DataMemberInfo.PropertyType;
            object instance = Activator.CreateInstance(this.GetType());
            MethodInfo printEnumOptionsMethod = instance.GetType().GetMethod("PrintEnumOptions").MakeGenericMethod(enumType);
            printEnumOptionsMethod.Invoke(instance, null);
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

        private List<string> getDeclaredOnlyPropertiesOfObjectWhichHaveSetters(object i_Obj)
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

        private void getWheelsDetailsFromUser(Vehicle i_Vehicle)
        {
            string wheelManufacturer;
            int wheelMaxTierPressureByManufacturer;
            int wheelCurrentTierPressure;

            Console.WriteLine("Would you like to set all wheels with the same parameters? Y/N");
            string userAnswer = Console.ReadLine();
            if(userAnswer != "Y" && userAnswer != "N")
            {
                throw new ArgumentException("Invalid Input");
            }

            if (userAnswer == "Y")
            {
                askUserForWheelDetails(out wheelManufacturer, out wheelMaxTierPressureByManufacturer, out wheelCurrentTierPressure);
                i_Vehicle.AttachAllWheelsWithSameDetails(wheelManufacturer, wheelMaxTierPressureByManufacturer, wheelCurrentTierPressure); 
            }
            else
            {
                for (int i = 0; i < i_Vehicle.Wheels.Capacity; i++)
                {
                    askUserForWheelDetails(out wheelManufacturer, out wheelMaxTierPressureByManufacturer, out wheelCurrentTierPressure);
                    i_Vehicle.AttachWheel(wheelManufacturer, wheelMaxTierPressureByManufacturer, wheelCurrentTierPressure);
                }
            }
        }

        private void askUserForWheelDetails(out string o_Manufacturer, out int o_MaxTierPressureByManufacturer, out int o_CurrentTierPressure)
        {
            Console.WriteLine("Please enter wheel manufacturer");
            o_Manufacturer = Console.ReadLine();

            Console.WriteLine("Please enter max tier pressure by manufacturer");
            if(!int.TryParse(Console.ReadLine(), out o_MaxTierPressureByManufacturer))
            {
                throw new FormatException("Invalid Input");
            }

            Console.WriteLine("Please enter current tier pressure");
            if(!int.TryParse(Console.ReadLine(), out o_CurrentTierPressure))
            {
                throw new FormatException("Invalid Input");
            }
        }

        private Vehicle createVehicleWithBasicDataMembersFromUser(VehicleCreator.eSupportedVehicleTypes i_VehicleType, string i_PlateNumberOfVehicle)
        {
            Console.WriteLine("Please enter model of vehicle");
            string modelOfVehicle = Console.ReadLine();

            return r_VehicleCreator.BuildVehicleByType(i_VehicleType, modelOfVehicle, i_PlateNumberOfVehicle);
        }
        
        private string getLicenseNumberOfVehicle()
        {
            Console.WriteLine("Please enter plate number of vehicle");
            string licenseNumberFromUser = Console.ReadLine();
            doesStringContainsOnlyNumbersOrLetters(licenseNumberFromUser);
            return licenseNumberFromUser;
        }

        private void doesStringContainsOnlyNumbersOrLetters(string i_Str)
        {
            foreach (char charInStr in i_Str)
            {
                if (!char.IsLetter(charInStr) && !char.IsDigit(charInStr))
                {
                    throw new FormatException();
                }
            }
        }

        private VehicleCreator.eSupportedVehicleTypes getVehicleTypeFromUser()
        {
            Console.WriteLine("Please enter vehicle type from the following options which you would like to enter into our garage");
            r_VehicleCreator.PrintAllSupportedVehicleTypes();
            if(!Enum.TryParse(Console.ReadLine(), out VehicleCreator.eSupportedVehicleTypes vehicleChosenType) || !Enum.IsDefined(typeof(VehicleCreator.eSupportedVehicleTypes), vehicleChosenType))
            {
                throw new FormatException("Invalid vehicle type");
            }

            return vehicleChosenType;
        }
    }
}
