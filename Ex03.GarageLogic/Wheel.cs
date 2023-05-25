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

        public void WheelInflateToMax()
        {
            CurrentTierPressure = MaxTierPressureByManufacturer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"Manufacturer: {m_Manufacturer}
Max Tire Pressure: {MaxTierPressureByManufacturer}
Current Tire Pressure: {CurrentTierPressure}");

            return sb.ToString();
        }
    }
}
