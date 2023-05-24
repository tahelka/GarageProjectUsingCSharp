using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class DieselEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public eFuelType FuelType { get; set; }
        //{
        //    get { return FuelType; }
        //    set
        //    {
        //        if (Enum.IsDefined(typeof(eFuelType), value))
        //        {
        //            FuelType = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid enum value");
        //        }
        //    }
        //}

        public void AddEnergyToEngine(float i_energyToAdd, string i_fuelType)
        {
            Enum.TryParse(i_fuelType, out eFuelType enumFuelType);
            if(FuelType != enumFuelType)
            {
                throw new ArgumentException("Wrong fuel type");
            }
            base.AddEnergyToEngine(i_energyToAdd);
        }
    }
}
