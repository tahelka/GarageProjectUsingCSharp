using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        const int k_WheelsNumber = 14;
        public bool DoesContainDangerousMaterials { get; set; }
        public float PayloadCapacity { get; set; }

        public Truck(string i_ModelOfVehicle, string i_PlateNumberOfVehicle) : base(i_ModelOfVehicle, i_PlateNumberOfVehicle)
        {
            Wheels.Capacity = k_WheelsNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"{base.ToString()}
Number of Wheels: {Wheels.Count}
Does Contain Dangerous Materials: {DoesContainDangerousMaterials}
Payload Capacity: {PayloadCapacity} liter");

            return sb.ToString();
        }
    }
}
