using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GaragedVehicle> r_VehiclesInGarage;
 

        public Garage()
        {
            r_VehiclesInGarage = new Dictionary<string, GaragedVehicle>();
        }

        public bool IsVehicleInGarage(string i_PlateNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_PlateNumber);
        }

        public GaragedVehicle GetGaragedVehicle(string i_PlateNumber)
        {
            return r_VehiclesInGarage[i_PlateNumber];
        }

        public void AddVehicleToGarage(GaragedVehicle i_GaragedVehicle)
        {
            r_VehiclesInGarage.Add(i_GaragedVehicle.Vehicle.PlateNumber,i_GaragedVehicle);
        }

        public List<string> GetVehiclesPlateNumbersByStatus(GaragedVehicle.eVehicleStatus i_status)
        {
            List<string> plateNumbers = new List<string>();
            foreach (GaragedVehicle vehicle in r_VehiclesInGarage.Values)
            {
                if (vehicle.VehicleStatus == i_status)
                {
                    plateNumbers.Add(vehicle.Vehicle.PlateNumber);
                }
            }

            return plateNumbers;
        }

        public void SetStatusOfAVehicle(string i_PlateNumber, GaragedVehicle.eVehicleStatus i_NewStatus)
        {
            r_VehiclesInGarage[i_PlateNumber].VehicleStatus = i_NewStatus;
            //Garage.GetGaragedVehicle(i_PlateNumber).VehicleStatus = i_NewStatus;
        }
    }
}
