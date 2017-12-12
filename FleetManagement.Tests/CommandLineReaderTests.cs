using FleetManagementConsole.Services;
using FleetManagementConsole;
using FleetManagementConsole.Dtos;
using NUnit.Framework;
using FleetManagement.Tests.Mocks;
using FleetManagementConsole.Factories;
using System.Collections.Generic;

namespace FleetManagement.Tests
{
    [TestFixture]
    public class CommandLineReaderTests
    {
        [Test]
        public void ReadCommandTest_FindCarsByLicensePlateWasCalled()
        {
            bool isCalled = false;
            var consoleMock = new ConsoleMock("select 1;",null,null);
            var vehicleManagerMock = new vehicleManagerMock((s)=> 
            {
                if(s=="1")
                    isCalled = true;
            });
            vehicleManagerMock.FindCarsByLicensePlateReturn = new Dictionary<Vehicle, ParkingPlaceOutput>();
            var factory = new CommandExecuterFactory(vehicleManagerMock,consoleMock,null,null,null,null,null);
            var sut = new CommandLineParser(consoleMock, CommandDictionaryFactory.Create(),vehicleManagerMock, factory);

            sut.ReadCommand();

            Assert.IsTrue(isCalled);
        }
    }
}