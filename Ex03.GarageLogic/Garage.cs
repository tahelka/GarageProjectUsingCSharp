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
                PaymentCompleted
            }
            public Vehicle m_Vehicle { get; set; }
            public string m_OwnerName { get; set; }
            public string m_OwnerPhoneNumber { get; set; }
            public eVehicleStatus m_VehicleStatus { get; set; }
        }
        public Dictionary<string, GaragedVehicle> m_VehiclesInGarage { get; set; }

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, GaragedVehicle>();
        }
        public bool isVehicleInGarage(string i_PlateNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_PlateNumber);
        }

        public void Add(GaragedVehicle i_VehicleToAdd)
        {
            m_VehiclesInGarage[i_VehicleToAdd.m_Vehicle.m_PlateNumber] = i_VehicleToAdd;
        }
    }
}
