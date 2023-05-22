using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        public int MaxTierPressureByManufacturer { get; set; }
        public int CurrentTierPressure { get; private set; }

        public Wheel(string i_Manufacturer, int i_MaxTierPressureByManufacturer, int i_CurrentTierPressure)
        {
            m_Manufacturer = i_Manufacturer;
            MaxTierPressureByManufacturer = i_MaxTierPressureByManufacturer;
            CurrentTierPressure = i_CurrentTierPressure;
        }

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
