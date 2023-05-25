
namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public override void AddEnergyToEngine(float i_MinutesToAdd)
        {
            base.AddEnergyToEngine(i_MinutesToAdd / 60);
        }

        public override string ToString()
        {
            string puralOfEnergyAmountLeft = EnergyAmountLeft == 1 ? "" : "s";
            string puralOfMaxEnergyPossibleAmount = MaxEnergyPossibleAmount == 1 ? "" : "s";

            return $"Electric Engine | Energy Amount Left: {EnergyAmountLeft} hour{puralOfEnergyAmountLeft} | Max Energy Possible Amount: {MaxEnergyPossibleAmount} hour{puralOfMaxEnergyPossibleAmount}";
        }
    }
}
