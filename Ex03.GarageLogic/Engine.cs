
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_EnergyAmountLeft;
        public float MaxEnergyPossibleAmount { get; set; }

        public float EnergyAmountLeft
        {
            get
            {
                return m_EnergyAmountLeft;
            }
            set
            {
                if(value + m_EnergyAmountLeft >= MaxEnergyPossibleAmount)
                {
                    m_EnergyAmountLeft = MaxEnergyPossibleAmount;
                }
                else if(value + m_EnergyAmountLeft < 0)
                {
                    throw new ValueOutOfRangeException(value, 0, MaxEnergyPossibleAmount);
                }
                else
                {
                    m_EnergyAmountLeft += value;
                }
            }
        }

        public virtual void AddEnergyToEngine(float i_EnergyToAdd)
        {
            EnergyAmountLeft = i_EnergyToAdd;
        }
    }
}
