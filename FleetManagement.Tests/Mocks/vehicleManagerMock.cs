using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagementConsole.Dtos;

namespace FleetManagement.Tests.Mocks
{
    public class vehicleManagerMock : IVehicleManager
    {
        public Action<string> FindCarsByLicensePlateAction { get; set; }
        public Action<Vehicle, ParkingPlaceOutput> AddVehicleAction { get; set; }
        public Action<Vehicle, ParkingPlaceOutput> AssignParkingPlaceAction { get; set; }
        public Action<Vehicle> DeleteAction { get; set; }
        public Action SelectInvalidAction { get; set; }

        public bool AddVehicleReturn { get; set; }
        public Dictionary<Vehicle, ParkingPlaceOutput> SelectInvalidReturn { get; set; }
        public Dictionary<Vehicle, ParkingPlaceOutput> FindCarsByLicensePlateReturn { get; set; }

        public vehicleManagerMock()
        {

        }

        public vehicleManagerMock(Action<string> action)
        {
            this.FindCarsByLicensePlateAction = action;
        }

        public bool AddVehicle(Vehicle vehicle, ParkingPlaceOutput parkingPlace)
        {
            this.AddVehicleAction?.Invoke(vehicle, parkingPlace);
            return AddVehicleReturn;
        }

        public void AssignParkingPlace(Vehicle vehicle, ParkingPlaceOutput parkingPlace)
        {
            this.AssignParkingPlaceAction?.Invoke(vehicle, parkingPlace);
        }

        public void Delete(Vehicle vehicle)
        {
            this.DeleteAction?.Invoke(vehicle);
        }

        public Dictionary<Vehicle, ParkingPlaceOutput> FindCarsByLicensePlate(string licensePlate)
        {
            this.FindCarsByLicensePlateAction?.Invoke(licensePlate);
            return FindCarsByLicensePlateReturn;
        }

        public Dictionary<Vehicle, ParkingPlaceOutput> SelectInvalid()
        {
            this.SelectInvalidAction?.Invoke();
            return SelectInvalidReturn;
        }
    }
}
