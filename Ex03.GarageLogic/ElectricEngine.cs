
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
            string pluralOfEnergyAmountLeft = EnergyAmountLeft == 1 ? "" : "s";
            string pluralOfMaxEnergyPossibleAmount = MaxEnergyPossibleAmount == 1 ? "" : "s";

            return $@"Electric Engine 
Energy Amount Left: {EnergyAmountLeft} hour{pluralOfEnergyAmountLeft}
Max Energy Possible Amount: {MaxEnergyPossibleAmount} hour{pluralOfMaxEnergyPossibleAmount}";
        }
    }
}
