using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public float EnergyPercentLeft { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Engine Engine { get; set; }

        protected Vehicle(string i_ModelOfVehicle, string i_PlateNumberOfVehicle)
        {
            Model = i_ModelOfVehicle;
            PlateNumber = i_PlateNumberOfVehicle;
            Wheels = new List<Wheel>();
        }

        public void AttachWheel(string i_Manufacturer, int i_MaxTierPressureByManufacturer, int i_CurrentTierPressure)
        {
            Wheels.Add(new Wheel(i_Manufacturer, i_MaxTierPressureByManufacturer, i_CurrentTierPressure));
        }

        public void AttachAllWheelsWithSameDetails(string i_WheelManufacturer, int i_WheelMaxTierPressureByManufacturer, int i_WheelCurrentTierPressure)
        {
            for (int i = 0; i < Wheels.Capacity; i++)
            {
                AttachWheel(i_WheelManufacturer, i_WheelMaxTierPressureByManufacturer, i_WheelCurrentTierPressure);
            }
        }

        public bool IsElectric(VehicleCreator.eSupportedVehicleTypes i_VehicleType)
        {
            return i_VehicleType.ToString().IndexOf("electric", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"Model: {Model}
Plate Number: {PlateNumber}
Energy Percent Left: {EnergyPercentLeft * 100}%
{Engine}
{Wheels[0]}");

            return sb.ToString();
        }

        public void UpdateEnergyPercentLeft()
        {
            EnergyPercentLeft = Engine.EnergyAmountLeft / Engine.MaxEnergyPossibleAmount;
        }

        public void InflateTiersToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.WheelInflateToMax();
            }
        }
    }




}
