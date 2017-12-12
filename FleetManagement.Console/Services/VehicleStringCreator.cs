using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public static class VehicleStringCreator
    {
        private static string getVehicleOutputString(Vehicle vehicle)
        {
            return $"{vehicle.Manufacturer}, {vehicle.Model}, {vehicle.LicensePlate}, {vehicle.Year}, {vehicle.NewPrice} Euro, ";
        }

        public static string getOutputString(Car car)
        {
            return getVehicleOutputString(car) + $"{car.Capacity} ccm, {car.Power} PS, {car.PollutantClass.ToString()}, ";
        }

        public static string getOutputString(Motorcycle motorcycle)
        {
            return getVehicleOutputString(motorcycle) + $"{motorcycle.Capacity} ccm, ";
        }

        public static string getOutputString(Truck truck)
        {
            return getVehicleOutputString(truck) + $"{truck.Axis} Achsen, {truck.Payload} t, ";
        }

        public static string GetOutputString(Vehicle vehicle)
        {
            if (vehicle is Car)
                return getOutputString(vehicle as Car);
            else if (vehicle is Motorcycle)
                return getOutputString(vehicle as Motorcycle);
            else if (vehicle is Truck)
                return getOutputString(vehicle as Truck);
            return null;
        }
    }
}
