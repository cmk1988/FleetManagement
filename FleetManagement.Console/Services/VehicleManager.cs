using FleetManagementConsole.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagementConsole.Services
{
    public class VehicleManager : IVehicleManager
    {
        private Dictionary<Vehicle, ParkingPlaceOutput> vehicleList;

        public VehicleManager(Dictionary<Vehicle, ParkingPlaceOutput> vehicleList)
        {
            this.vehicleList = vehicleList;
        }

        public Dictionary<Vehicle, ParkingPlaceOutput> FindCarsByLicensePlate(string licensePlate)
        {
            string lowerSS = licensePlate.ToLower();
            return vehicleList.Where(x => x.Key.LicensePlate.
                ToLower().
                Contains(lowerSS)).
                ToDictionary(x => x.Key, x => x.Value);
        }

        public Dictionary<Vehicle, ParkingPlaceOutput> SelectInvalid()
        {
            return vehicleList.Where(x => x.Value == null || !VehicleValidChecker.Check(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public bool AddVehicle(Vehicle vehicle, ParkingPlaceOutput parkingPlace)
        {
            if(!this.vehicleList.Any(x=>x.Key.LicensePlate==vehicle.LicensePlate))
            {
                this.vehicleList.Add(vehicle, parkingPlace);
                return true;
            }
            return false;                
        }

        public void Delete(Vehicle vehicle)
        {
            this.vehicleList.Remove(vehicle);
        }

        public void AssignParkingPlace(Vehicle vehicle, ParkingPlaceOutput parkingPlace)
        {
            this.vehicleList[vehicle] = parkingPlace;
        }
    }
}
