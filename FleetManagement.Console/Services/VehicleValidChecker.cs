using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class VehicleValidChecker
    {
        private static bool checkVehicle(Vehicle vehicle)
        {
            return string.IsNullOrEmpty(vehicle.Manufacturer) &&
                string.IsNullOrEmpty(vehicle.Model) &&
                string.IsNullOrEmpty(vehicle.LicensePlate) &&
                vehicle.NewPrice != 0 &&
                vehicle.Year != 0;
        }

        public static bool checkCar(Car car)
        {
            return car.Capacity != 0 &&
                car.Power != 0;
        }

        public static bool checkMotorcycle(Motorcycle motorcycle)
        {
            return motorcycle.Capacity != 0;
        }

        public static bool checkTruck(Truck truck)
        {
            return truck.Axis != 0 &&
                truck.Payload != 0;
        }

        public static bool Check(Vehicle vehicle)
        {
            if (vehicle is Car)
                return checkCar(vehicle as Car);
            else if (vehicle is Motorcycle)
                return checkMotorcycle(vehicle as Motorcycle);
            else if (vehicle is Truck)
                return checkTruck(vehicle as Truck);
            return false;
        }
    }
}
