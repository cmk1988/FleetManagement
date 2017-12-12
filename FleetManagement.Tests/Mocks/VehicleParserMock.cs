using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagementConsole.Dtos;

namespace FleetManagement.Tests.Mocks
{
    public class VehicleParserMock : IVehicleParser
    {
        public Vehicle Parse(IConsoleInputOutput str, string parameter)
        {
            throw new NotImplementedException();
        }

        public Vehicle Parse(IConsoleInputOutput str, string parameter, out int parkingPlaceId)
        {
            throw new NotImplementedException();
        }

        public Vehicle Parse(string[] propertyStrings, string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
