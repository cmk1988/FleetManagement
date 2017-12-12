using FleetManagementConsole.Dtos;
using FleetManagementConsole.Services;
using System.Collections.Generic;

namespace FleetManagementConsole.Factories
{
    public class VehicleManagerFactory
    {
        public static VehicleManager Create(IGarageManager garageManager)
        {
            return new VehicleManager(new Dictionary<Vehicle, ParkingPlaceOutput>
            {
                { new Car
                    {
                        Manufacturer = "VW",
                        Model = "Käfer",
                        LicensePlate = "K-GS-01",
                        Year = 1965,
                        NewPrice = 9999m,
                        Capacity = 1000,
                        Power = 30,
                        PollutantClass = PollutantClasses.Normal
                    },
                    garageManager?.GetParkingPlace(100)
                },
                { new Car
                    {
                        Manufacturer = "Opel",
                        Model = "Kadett",
                        LicensePlate = "K-GS-02",
                        Year = 1964,
                        NewPrice = 12000m,
                        Capacity = 1600,
                        Power = 60,
                        PollutantClass = PollutantClasses.Diesel
                    },
                    garageManager?.GetParkingPlace(101)
                },
                { new Motorcycle
                    {
                        Manufacturer = "BMW",
                        Model = "R1200r",
                        LicensePlate = "K-GS-03",
                        Year = 1999,
                        NewPrice = 6000m,
                        Capacity = 1170
                    },
                    garageManager?.GetParkingPlace(200)
                },
                { new Truck
                    {
                        Manufacturer = "Mercedes",
                        Model = "LG 315",
                        LicensePlate = "K-GS-04",
                        Year = 1960,
                        NewPrice = 23000m,
                        Axis = 2,
                        Payload = 5.5
                    },
                    garageManager?.GetParkingPlace(300)
                }
            });
        }
    }
}
