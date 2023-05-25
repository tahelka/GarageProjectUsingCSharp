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

        //private eFuelType m_fuelType;


        //public eFuelType FuelType
        //{
        //    get
        //    {
        //        return m_fuelType;
        //    }
        //    set
        //    {
        //        if (m_fuelType != value)
        //        {
        //            throw new ArgumentException("wrong fuel type");
        //        }

        //        m_fuelType = value;
        //    }
        //}

        public void AddEnergyToEngine(float i_energyToAdd, eFuelType i_fuelType)
        {
            checkIfFuelTypeMatches(i_fuelType);
            base.AddEnergyToEngine(i_energyToAdd);
        }

        private void checkIfFuelTypeMatches(eFuelType i_fuelType)
        {
            if (FuelType != i_fuelType)
            {
                throw new ArgumentException("wrong fuel type");
            }
        }

        public override string ToString()
        {
            string fuelType = FuelType.ToString();
            string puralOfEnergyAmountLeft = EnergyAmountLeft == 1 ? "" : "s";
            string puralOfMaxEnergyPossibleAmount = MaxEnergyPossibleAmount == 1 ? "" : "s";

            return $"Fuel Type: {fuelType} | Energy Amount Left: {EnergyAmountLeft} Liter{puralOfEnergyAmountLeft} | Max Energy Possible Amount: {MaxEnergyPossibleAmount} Liter{puralOfMaxEnergyPossibleAmount}";
        }
    }
}
