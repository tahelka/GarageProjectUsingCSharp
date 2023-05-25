using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public Garage Garage { get; }

        public GarageManager()
        {
            Garage = new Garage();
        }

        public List<string> GetVehiclesPlateNumbersByStatus(Garage.GaragedVehicle.eVehicleStatus i_status)
        {
            List<string> plateNumbers = null;
            foreach (GaragedVehicle vehicle in Garage.VehiclesInGarage.Values)
            {
                if (vehicle.VehicleStatus == i_status || vehicle.VehicleStatus == GaragedVehicle.eVehicleStatus.All)
                {
                    plateNumbers.Add(vehicle.Vehicle.PlateNumber);
                }
            }

            return plateNumbers;
        }

        public void SetStatusOfAVehicle(string i_PlateNumber, GaragedVehicle.eVehicleStatus i_NewStatus)
        {
            Garage.VehiclesInGarage[i_PlateNumber].VehicleStatus = i_NewStatus;
        }

        public void InflateTiersToMax(string i_PlateNumber)
        {
            Vehicle vehicle = Garage.VehiclesInGarage[i_PlateNumber].Vehicle;
            foreach(Wheel wheel in vehicle.Wheels)
            {
                wheel.WheelInflateToMax();
            }
        }
    }
}
