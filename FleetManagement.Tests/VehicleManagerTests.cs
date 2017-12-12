using FleetManagementConsole.Dtos;
using System.Collections.Generic;
using FleetManagementConsole;
using FleetManagement.Tests.Service;
using FleetManagementConsole.Factories;
using NUnit.Framework;

namespace FleetManagement.Tests
{
    [TestFixture]
    public class VehicleManagerTests
    {
        [Test]
        public void FindCarsByLicensePlateTest_OneCar()
        {
            var expect = new List<Vehicle>
            {
                new Car
                {
                    Manufacturer = "Opel",
                    Model = "Kadett",
                    LicensePlate = "K-GS-02",
                    Year = 1964,
                    NewPrice = 12000m,
                    Capacity = 1600,
                    Power = 60,
                    PollutantClass = PollutantClasses.Diesel
                }
            };
            var sut = VehicleManagerFactory.Create(null);

            var result = sut.FindCarsByLicensePlate("k-gs-02");
            Assert.IsTrue(PropertyComparer.AreEqual(expect, new List<Vehicle>(result.Keys)));
        }

        [Test]
        public void FindCarsByLicensePlateTest_AllVehicles()
        {
            var expect = new List<Vehicle>
            {
                new Car
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
                new Car
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
                new Motorcycle
                {
                    Manufacturer = "BMW",
                    Model = "R1200r",
                    LicensePlate = "K-GS-03",
                    Year = 1999,
                    NewPrice = 6000m,
                    Capacity = 1170
                },
                new Truck
                {
                    Manufacturer = "Mercedes",
                    Model = "LG 315",
                    LicensePlate = "K-GS-04",
                    Year = 1960,
                    NewPrice = 23000m,
                    Axis = 2,
                    Payload = 5.5
                }
            };
            var sut = VehicleManagerFactory.Create(null);

            var result = sut.FindCarsByLicensePlate("");

            Assert.IsTrue(PropertyComparer.AreEqual(expect, new List<Vehicle>(result.Keys)));
        }
    }
}
