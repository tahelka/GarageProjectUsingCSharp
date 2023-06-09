﻿using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_WheelsNumber = 4;
        public eColor Color { get; set; }
        public eNumOfDoors NumOfDoors { get; set; }

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

        public Car(string i_ModelOfVehicle, string i_PlateNumberOfVehicle) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle)
        {
            Wheels.Capacity = k_WheelsNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"{base.ToString()}
Color: {Color}
Number of Doors: {NumOfDoors}");

            return sb.ToString();
        }
    }
}