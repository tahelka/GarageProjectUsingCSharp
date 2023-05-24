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

        private eFuelType m_fuelType;
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

        public eFuelType FuelType
        {
            get
            {
                return m_fuelType;
            }
            set
            {
                if(m_fuelType != value)
                {
                    throw new ArgumentException("wrong fuel type");
                }

                m_fuelType = value;
            }
        }

        public void AddEnergyToEngine(float i_energyToAdd, eFuelType i_fuelType)
        {
            FuelType = i_fuelType;
            base.AddEnergyToEngine(i_energyToAdd);
        }

        public override string ToString()
        {
            string fuelType = FuelType.ToString();
            return $"Fuel Type: {fuelType} | Energy Amount Left: {EnergyAmountLeft} | Max Energy Possible Amount: {MaxEnergyPossibleAmount}";
        }
    }
}
