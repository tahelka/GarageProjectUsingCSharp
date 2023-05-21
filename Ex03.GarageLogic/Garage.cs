using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            public string OwnerPhoneNumber { get; set; }
            public eVehicleStatus VehicleStatus { get; set; }
        }
        public Dictionary<string, GaragedVehicle> VehiclesInGarage { get; set; }

        public Garage()
        {
            VehiclesInGarage = new Dictionary<string, GaragedVehicle>();
        }
        public bool isVehicleInGarage(string i_PlateNumber)
        {
            return VehiclesInGarage.ContainsKey(i_PlateNumber);
        }

        public void Add(GaragedVehicle i_VehicleToAdd)
        {
            VehiclesInGarage[i_VehicleToAdd.Vehicle.m_PlateNumber] = i_VehicleToAdd;
        }
    }
}
