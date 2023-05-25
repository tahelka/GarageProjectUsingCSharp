using System;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eSupportedVehicleTypes
        {
            ElectricCar = 1,
            DieselCar,
            DieselTruck,
            ElectricMotorcycle,
            DieselMotorcycle
        }

        public Vehicle BuildVehicleByType(eSupportedVehicleTypes i_VehicleType, string i_ModelOfVehicle, string i_PlateNumberOfVehicle)
        {
            Vehicle res;
            
            switch (i_VehicleType)
            {
                case eSupportedVehicleTypes.ElectricCar:
                case eSupportedVehicleTypes.DieselCar:
                    res = new Car(i_ModelOfVehicle, i_PlateNumberOfVehicle);
                    break;                  
                case eSupportedVehicleTypes.ElectricMotorcycle:
                case eSupportedVehicleTypes.DieselMotorcycle:
                    res = new Motorcycle(i_ModelOfVehicle, i_PlateNumberOfVehicle);
                    break;
                case eSupportedVehicleTypes.DieselTruck:
                    res = new Truck(i_ModelOfVehicle, i_PlateNumberOfVehicle);
                    break;
                default:
                    throw new ArgumentException();
            }
 
            return res;
        }

        public void PrintAllSupportedVehicleTypes()
        {
            foreach (eSupportedVehicleTypes action in Enum.GetValues(typeof(eSupportedVehicleTypes)))
            {
                int value = (int)action;
                string optionName = action.ToString();
                Console.WriteLine($"{value}. {optionName}");
            }
        }
    }
}
