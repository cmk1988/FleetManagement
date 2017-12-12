using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public static class VehicleTaxCalculator
    {
        public static decimal Calculate(Car car)
        {
            return (car.Capacity+99)/100*10m*((int)car.PollutantClass+1);
        }

        public static decimal Calculate(Motorcycle motorcycle)
        {
            return (motorcycle.Capacity + 99) / 100 * 20m;
        }

        public static decimal Calculate(Truck truck)
        {
            return (decimal)truck.Payload*100m;
        }

        public static decimal Calculate(Vehicle vehicle)
        {
            if (vehicle is Car)
                return Calculate(vehicle as Car);
            else if (vehicle is Motorcycle)
                return Calculate(vehicle as Motorcycle);
            else if (vehicle is Truck)
                return Calculate(vehicle as Truck);
            return 0m;
        }
    }
}
