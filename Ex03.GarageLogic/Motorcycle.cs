using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        const int k_WheelsNumber = 2;
        public int EngineCapacity { get; set; }
        public eLicenseType LicenseType { get; set; }
        //{
        //    get { return LicenseType; }
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(eLicenseType), value))
        //        {
        //            LicenseType = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid enum value");
        //        }
        //    }
        //}

        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }


        public Motorcycle(string i_ModelOfVehicle, string i_PlateNumberOfVehicle) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle)
        {
            Wheels.Capacity = k_WheelsNumber;
        }



    }
}
