using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public class GaragedVehicle
        {
            public enum eVehicleStatus
            {
                BeingRepaired,
                Repaired,
                PaymentCompleted,
                All
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
                            throw new FormatException();
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
{Vehicle.ToString()}";

            }
        }
        public Dictionary<string, GaragedVehicle> VehiclesInGarage { get; set; }

        public Garage()
        {
            VehiclesInGarage = new Dictionary<string, GaragedVehicle>();
        }

        public bool IsVehicleInGarage(string i_PlateNumber)
        {
            return VehiclesInGarage.ContainsKey(i_PlateNumber);
        }

        //public void Add(GaragedVehicle i_VehicleToAdd)
        //{
        //    VehiclesInGarage[i_VehicleToAdd.Vehicle.PlateNumber] = i_VehicleToAdd;
        //}
    }
}
