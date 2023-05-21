using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturer;
        public int MaxTierPressureByManufacturer { get; set; }
        public int CurrentTierPressure { get; private set; }

        public void WheelInflating(int i_AirPressureAmountToAdd)
        {
            if (i_AirPressureAmountToAdd > MaxTierPressureByManufacturer)
            {
                throw new ValueOutOfRangeException(i_AirPressureAmountToAdd, 0, MaxTierPressureByManufacturer);
            }

            CurrentTierPressure = i_AirPressureAmountToAdd;
        }

    }
}
