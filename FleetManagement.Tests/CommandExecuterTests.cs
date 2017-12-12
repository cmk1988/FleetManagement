using FleetManagement.Tests.Mocks;
using FleetManagementConsole.Dtos;
using FleetManagementConsole.Enums;
using FleetManagementConsole.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Tests
{
    [TestFixture]
    public class CommandExecuterTests
    {
        private vehicleManagerMock vehicleManager;
        private ConsoleMock console;
        private VehicleParserMock vehicleParser;
        private GarageManagerMock garageManager;
        private GarageParserMock garageParser;
        private ICsvImporter csvImporter;
        IFileInputOutput file;

        private CommandExecuter CreateSut()
        {
            vehicleManager = new vehicleManagerMock();
            console = new ConsoleMock();
            vehicleParser = null;
            garageManager = new GarageManagerMock();
            garageParser = new GarageParserMock();
            csvImporter = null;
            file = null;
            return new CommandExecuter(vehicleManager, console, vehicleParser, garageManager, garageParser, csvImporter, file);
        }

        [Test]
        public void Add_MethodsCalledCorrectly()
        {
            uint count = 5;
            bool wasCalled = false;
            var sut = CreateSut();
            var garage = new Garage();
            garageParser.ParseReturn = garage;
            garageParser.ParseAction = (IConsoleInputOutput a, out uint b) => { b = 5; };
            garageManager.AddGarageAction = (a, b) =>
            {
                if (a == garage && b == count)
                    wasCalled = true;
            };

            sut.Execute(Commands.Add, "g");

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void Garage_MethodsCalledCorrectly()
        {
            var str = "1";
            bool wasCalled = false;
            var garages = new List<Garage>{ new Garage() };
            var sut = CreateSut();
            garageManager.GetAllGaragesReturn = garages;
            garageManager.SelectGarageAction = (a) =>
            {
                if (a == garages[0])
                    wasCalled = true;
            };

            sut.Execute(Commands.Garage, str);

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void DeleteGarage_MethodsCalledCorrectly()
        {
            var str = "1";
            bool wasCalled = false;
            var garages = new List<Garage> { new Garage() };
            var sut = CreateSut();
            garageManager.GetAllGaragesReturn = garages;
            garageManager.DeleteGarageReturn = true;
            garageManager.DeleteGarageAction = (a) =>
            {
                if (a == garages[0])
                    wasCalled = true;
            };

            sut.Execute(Commands.DeleteGarage, str);

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void GetFreePlacesCount_MethodsCalledCorrectly()
        {
            var str = "1";
            bool wasCalled = false;
            var garages = new List<Garage> { new Garage() };
            var sut = CreateSut();
            garageManager.GetAllGaragesReturn = garages;
            garageManager.DeleteGarageReturn = true;
            garageManager.GetFreePlacesCountAction = (a) =>
            {
                if (a == garages[0])
                    wasCalled = true;
            };
            garageManager.GetFreePlacesCountReturn = new FreeParkingPlaces { Free = 0, Total = 0, IsSelected = true };

            sut.Execute(Commands.GarageInfo, str);

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void Park_MethodsCalledCorrectly()
        {
            var str = "1";
            bool wasCalled = false;
            var garages = new List<Garage> { new Garage() };
            var cars = new Dictionary<Vehicle, ParkingPlaceOutput> { { new Car(), null } };
            var sut = CreateSut();
            vehicleManager.FindCarsByLicensePlateReturn = cars;
            vehicleManager.AssignParkingPlaceAction = (a,b) => 
            {
                if (a==cars.ElementAt(0).Key && b== garageManager.GetParkingPlaceReturn)
                    wasCalled = true;
            };
            garageManager.GetAllGaragesReturn = garages;
            garageManager.DeleteGarageReturn = true;
            garageManager.GetParkingPlaceReturn = new ParkingPlaceOutput();
            garageManager.GetFreePlacesCountReturn = new FreeParkingPlaces { Free = 0, Total = 0, IsSelected = true };

            sut.Execute(Commands.Select, str);
            sut.Execute(Commands.Park, str);

            Assert.IsTrue(wasCalled);
        }
    }
}
