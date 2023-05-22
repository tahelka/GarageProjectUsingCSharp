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
            Truck,
            ElectricMotorcycle,
            DieselMotorcycle
        }

        List<string> m_VehicleTypesSupportedInSystem;

        public VehicleCreator()
        {
            m_VehicleTypesSupportedInSystem = new List<string>() { "Car", "Motorcycle", "Truck"};
        }

        public Vehicle buildVehicleByType(eSupportedVehicleTypes i_vehicleType, string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft)
        {
            Vehicle res;
            bool isElectricCar = true;

            switch (i_vehicleType)
            {
                case eSupportedVehicleTypes.ElectricCar:
                case eSupportedVehicleTypes.DieselCar:
                    res = new Car(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft);
                    break;                  
                case eSupportedVehicleTypes.ElectricMotorcycle:
                case eSupportedVehicleTypes.DieselMotorcycle:
                    res = new Motorcycle(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft);
                    break;
                case eSupportedVehicleTypes.Truck:
                    res = new Truck(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft);
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }

           
            return res;
        }

        
       

    }
}
