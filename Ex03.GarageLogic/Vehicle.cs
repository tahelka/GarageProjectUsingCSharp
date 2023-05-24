using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public float EnergyPrecentleft { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Engine Engine { get; set; }

        protected Vehicle(string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft)
        {
            Model = i_ModelOfVehicle;
            PlateNumber = i_PlateNumberOfVehicle;
            EnergyPrecentleft = i_EnergyPrecentLeft;
            Wheels = new List<Wheel>();
        }

        public void attachWheel(string i_Manufacturer, int i_MaxTierPressureByManufacturer, int i_CurrentTierPressure)
        {
            Wheels.Add(new Wheel(i_Manufacturer, i_MaxTierPressureByManufacturer, i_CurrentTierPressure));
        }

        public void attachAllWheelsWithSameDetails(string i_WheelManufacturer, int i_WheelMaxTierPressureByManufacturer, int i_WheelCurrentTierPressure)
        {
            for (int i = 0; i < Wheels.Capacity; i++)
            {
                attachWheel(i_WheelManufacturer, i_WheelMaxTierPressureByManufacturer, i_WheelCurrentTierPressure);
            }
        }

        public void SetTirePressure(int tirePressure)
        {

        }

        public bool isElectric(VehicleCreator.eSupportedVehicleTypes i_VehicleType)
        {
            return i_VehicleType.ToString().IndexOf("electric", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        //public abstract string GetSpecialPropertiesNames();

    }
}
