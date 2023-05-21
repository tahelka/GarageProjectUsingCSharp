using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public float EnergyAmountLeft { get; set; }
        public float MaxEnergyAmountPossible { get; set; }

        public virtual void AddEnergyToEngine(float i_EnergyToAdd)
        {
            EnergyAmountLeft = i_EnergyToAdd;
        }
    }
}
