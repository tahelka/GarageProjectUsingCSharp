using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public bool isElectricEngine{ get; set;  }

        private float m_energyAmountLeft;
        public float EnergyAmountLeft
        {
            get
            {
                return m_energyAmountLeft;
            }
            set
            {
                if(value > MaxEnergyPossibleAmount)
                {
                    throw new ValueOutOfRangeException(value, 0, MaxEnergyPossibleAmount);
                }

                m_energyAmountLeft = value;
            }
        }

        public float MaxEnergyPossibleAmount { get; set; }

        protected Engine()
        {
            isElectricEngine = false;
        }
        public virtual void AddEnergyToEngine(float i_EnergyToAdd)
        {
            EnergyAmountLeft = i_EnergyToAdd;
        }


    }
}
