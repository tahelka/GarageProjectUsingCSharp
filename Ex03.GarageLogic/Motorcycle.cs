using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        const int k_WheelsNumber = 2;
        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }

        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft)
        {
            m_Wheels.Capacity = k_WheelsNumber;
        }



    }
}
