using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        const int k_WheelsNumber = 4;
        public enum eColor
        {
            White,
            Black,
            Yellow,
            Red
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public eColor m_Color;
        public eNumOfDoors m_NumOfDoors;

        public Car(string i_ModelOfVehicle, string i_PlateNumberOfVehicle, float i_EnergyPrecentLeft) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle, i_EnergyPrecentLeft)
        {
            m_Wheels.Capacity = k_WheelsNumber;
        }
    }
}
