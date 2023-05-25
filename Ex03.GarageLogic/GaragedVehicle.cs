using System;

namespace Ex03.GarageLogic
{
    public class GaragedVehicle
    {
        public enum eVehicleStatus
        {
            BeingRepaired,
            Repaired,
            PaymentCompleted,
        }
        public Vehicle Vehicle { get; set; }
        public string OwnerName { get; set; }
        private string m_OwnerPhoneNumber;
        public eVehicleStatus VehicleStatus { get; set; }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                foreach (char charInStr in value)
                {
                    if (!char.IsDigit(charInStr))
                    {
                        throw new FormatException("phone number must only contain numbers");
                    }
                }

                m_OwnerPhoneNumber = value;
            }
        }

        public GaragedVehicle()
        {
            VehicleStatus = eVehicleStatus.BeingRepaired;
        }

        public override string ToString()
        {
            return $@"
Owner Name: {OwnerName}
Owner Phone Number: {OwnerPhoneNumber}
Vehicle Status: {VehicleStatus}
{Vehicle}";

        }

        public static void PrintStatusMenu()
        {
            foreach (eVehicleStatus status in Enum.GetValues(typeof(eVehicleStatus)))
            {
                int value = (int)status;
                string optionName = status.ToString();
                Console.WriteLine($"{value}. {optionName}");
            }
        }
    }
}
