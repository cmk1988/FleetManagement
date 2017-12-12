using System.Collections.Generic;
using FleetManagementConsole.Dtos;

namespace FleetManagementConsole.Services
{
    public interface IVehicleManager
    {
        bool AddVehicle(Vehicle vehicle, ParkingPlaceOutput parkingPlace);
        Dictionary<Vehicle, ParkingPlaceOutput> FindCarsByLicensePlate(string licensePlate);
        void Delete(Vehicle vehicle);
        void AssignParkingPlace(Vehicle vehicle, ParkingPlaceOutput parkingPlace);
        Dictionary<Vehicle, ParkingPlaceOutput> SelectInvalid();
    }
}