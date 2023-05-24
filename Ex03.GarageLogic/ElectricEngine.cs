using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public void AddEnergyToEngine(float i_MinutesToAdd)
        {
            base.AddEnergyToEngine(i_MinutesToAdd / 60);
        }

        public override string ToString()
        {
            return $"Electric Engine | Energy Amount Left: {EnergyAmountLeft} hours | Max Energy Possible Amount: {MaxEnergyPossibleAmount} hours";
        }
    }
}
