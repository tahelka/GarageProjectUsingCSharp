using System;

namespace Ex03.GarageLogic
{
    public class DieselEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public eFuelType FuelType { get; set; }

        public void AddEnergyToEngine(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            checkIfFuelTypeMatches(i_FuelType);
            base.AddEnergyToEngine(i_EnergyToAdd);
        }

        private void checkIfFuelTypeMatches(eFuelType i_FuelType)
        {
            if (FuelType != i_FuelType)
            {
                throw new ArgumentException("wrong fuel type");
            }
        }

        public override string ToString()
        {

            string fuelType = FuelType.ToString();
            string pluralOfEnergyAmountLeft = EnergyAmountLeft == 1 ? "" : "s";
            string pluralOfMaxEnergyPossibleAmount = MaxEnergyPossibleAmount == 1 ? "" : "s";

            return $@"Fuel Type: {fuelType} 
Energy Amount Left: {EnergyAmountLeft} Liter{pluralOfEnergyAmountLeft}
Max Energy Possible Amount: {MaxEnergyPossibleAmount} Liter{pluralOfMaxEnergyPossibleAmount}";
        }
    }
}
