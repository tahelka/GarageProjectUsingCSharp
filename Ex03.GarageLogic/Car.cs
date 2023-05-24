using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        const int k_WheelsNumber = 4;
        public eColor Color { get; set; }
        //{
        //    get { return Color; }
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(eColor), value))
        //        {
        //            Color = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid enum value");
        //        }
        //    }
        //}

        public eNumOfDoors NumOfDoors { get; set; }
        //{
        //    get { return NumOfDoors; }
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(eNumOfDoors), value))
        //        {
        //            NumOfDoors = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid enum value");
        //        }
        //    }
        //}

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
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Number of Doors: {NumOfDoors}");

            return sb.ToString();
        }
        //public override string GetSpecialPropertiesNames()
        //{
        //    return Enum.GetNames(typeof(eCarSpecialProperties));
        //}
    }
}
