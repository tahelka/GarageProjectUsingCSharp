using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Vehicle buildVehicleByType(eSupportedVehicleTypes i_vehicleType, string i_ModelOfVehicle, string i_PlateNumberOfVehicle)
        {
            Vehicle res;
            bool isElectricCar = true;

            switch (i_vehicleType)
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
                    break;
            }

           
            return res;
        }

        
       

    }
}
