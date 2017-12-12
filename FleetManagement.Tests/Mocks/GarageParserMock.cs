using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagementConsole.Dtos;

namespace FleetManagement.Tests.Mocks
{
    public class GarageParserMock : IGarageParser
    {
        public delegate void OutAction<IConsoleInputOutput, T>(IConsoleInputOutput console, out T t);
        public OutAction<IConsoleInputOutput, uint> ParseAction { get; set; }
        public Garage ParseReturn;

        public Garage Parse(IConsoleInputOutput console, out uint count)
        {
            count = 0;
            ParseAction?.Invoke(console,out count);
            return ParseReturn;
        }
    }
}
