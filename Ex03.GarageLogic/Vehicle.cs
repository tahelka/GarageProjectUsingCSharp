using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string m_Model { get; set; }
        public string m_PlateNumber { get; set; }
        public float m_EnergyPrecentleft { get; set; }
        public List<Wheel> m_Wheels { get; set; }
        public Engine m_Engine { get; set; }

        protected Vehicle(string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft)
        {
            m_Model = i_ModelOfVehicle;
            m_PlateNumber = i_PlateNumberOfVehicle;
            m_EnergyPrecentleft = i_EnergyPrecentLeft;
        }

        public void attachWheel(string i_Manufacturer, int i_MaxTierPressureByManufacturer, int i_CurrentTierPressure)
        {
            m_Wheels.Add(new Wheel(i_Manufacturer, i_MaxTierPressureByManufacturer, i_CurrentTierPressure));
        }

        public void attachAllWheelsWithSameDetails(string i_WheelManufacturer, int i_WheelMaxTierPressureByManufacturer, int i_WheelCurrentTierPressure)
        {
            for (int i = 0; i < m_Wheels.Capacity; i++)
            {
                attachWheel(i_WheelManufacturer, i_WheelMaxTierPressureByManufacturer, i_WheelCurrentTierPressure);
            }
        }

        public void SetTirePressure(int tirePressure)
        {

        }





    }
}
