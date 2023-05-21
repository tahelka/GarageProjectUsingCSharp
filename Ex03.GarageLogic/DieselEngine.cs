using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class DieselEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public void AddEnergyToEngine(float i_energyToAdd, string i_fuelType)
        {
            Enum.TryParse(i_fuelType, out m_FuelType); //throw an exeption if wrong parse
            base.AddEnergyToEngine(i_energyToAdd);
        }
    }
}
