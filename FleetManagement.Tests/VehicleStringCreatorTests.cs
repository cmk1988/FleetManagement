using FleetManagementConsole.Services;
using FleetManagementConsole;
using FleetManagementConsole.Dtos;
using NUnit.Framework;

namespace FleetManagement.Tests
{
    [TestFixture]
    public class VehicleStringCreatorTests
    {
        [Test]
        public void GetOutputStringTest_Car()
        {
            var expect = "Opel, Kadett, K-GS-02, 1964, 12000 Euro, 1600 ccm, 60 PS, Diesel, ";
            Vehicle car = new Car
            {
                Manufacturer = "Opel",
                Model = "Kadett",
                LicensePlate = "K-GS-02",
                Year = 1964,
                NewPrice = 12000m,
                Capacity = 1600,
                Power = 60,
                PollutantClass = PollutantClasses.Diesel
            };

            var result = VehicleStringCreator.GetOutputString(car);
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void GetOutputStringTest_Motorcycle()
        {
            var expect = "BMW, R1200r, K-GS-03, 1999, 6000 Euro, 1170 ccm, ";
            Vehicle motorcycle = new Motorcycle
            {
                Manufacturer = "BMW",
                Model = "R1200r",
                LicensePlate = "K-GS-03",
                Year = 1999,
                NewPrice = 6000m,
                Capacity = 1170
            };

            var result = VehicleStringCreator.GetOutputString(motorcycle);
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void GetOutputStringTest_Truck()
        {
            var expect = "Mercedes, LG 315, K-GS-04, 1960, 23000 Euro, 2 Achsen, 5.5 t, ";
            Vehicle truck = new Truck
            {
                Manufacturer = "Mercedes",
                Model = "LG 315",
                LicensePlate = "K-GS-04",
                Year = 1960,
                NewPrice = 23000m,
                Axis = 2,
                Payload = 5.5
            };

            var result = VehicleStringCreator.GetOutputString(truck);
            Assert.AreEqual(expect, result);
        }
    }
}
