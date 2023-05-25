
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_energyAmountLeft;
        public float MaxEnergyPossibleAmount { get; set; }

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

        public virtual void AddEnergyToEngine(float i_EnergyToAdd)
        {
            EnergyAmountLeft = i_EnergyToAdd;
        }
    }
}
