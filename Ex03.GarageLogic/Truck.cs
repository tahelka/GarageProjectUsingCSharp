using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        const int k_WheelsNumber = 14;
        public bool m_DoesContainDangerousMaterials { get; set; }
        private float m_PayloadCapacity { get; set; }

        public Truck(string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft)
        {
            m_Wheels.Capacity = k_WheelsNumber;
        }
    }
}
