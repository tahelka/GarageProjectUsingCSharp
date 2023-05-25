using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        public int MaxTierPressureByManufacturer { get; set; }
        public int CurrentTierPressure { get; private set; }

        public Wheel(string i_Manufacturer, int i_MaxTierPressureByManufacturer, int i_CurrentTierPressure)
        {
            r_Manufacturer = i_Manufacturer;
            MaxTierPressureByManufacturer = i_MaxTierPressureByManufacturer;
            CurrentTierPressure = i_CurrentTierPressure;
        }

        public void WheelInflateToMax()
        {
            CurrentTierPressure = MaxTierPressureByManufacturer;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"Manufacturer: {r_Manufacturer}
Max Tire Pressure: {MaxTierPressureByManufacturer}
Current Tire Pressure: {CurrentTierPressure}");

            return sb.ToString();
        }
    }
}
