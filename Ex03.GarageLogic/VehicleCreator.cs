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

        public Vehicle buildVehicleByType(eSupportedVehicleTypes i_type)
        {
            Vehicle res;

            switch (i_type)
            {
                case eSupportedVehicleTypes.ElectricCar:
                    res = BuildElectricCar();
                    break;
                case eSupportedVehicleTypes.DieselCar:
                    res = BuildDieselCar();
                    break;
                case eSupportedVehicleTypes.ElectricMotorcycle:
                    res = BuildElectricMotorcycle();
                    break;
                case eSupportedVehicleTypes.DieselMotorcycle:
                    res = BuildDieselMotorcycle();
                    break;
                case eSupportedVehicleTypes.Truck:
                    res = BuildTruck();
                    break;
                default:
                    res = null; 
                    break;
            }

            return res;
        }

        public Vehicle BuildElectricCar()
        {
            return new Car("electric");
        }

        public Vehicle BuildDieselCar()
        {
            return new Car("diesel");
        }

        public Vehicle BuildElectricMotorcycle()
        {
            return new Motorcycle("electric");
        }

        public Vehicle BuildDieselMotorcycle()
        {
            return new Motorcycle("diesel");
        }

        public Vehicle BuildTruck()
        {
            return new Truck();
        }


    }
}
