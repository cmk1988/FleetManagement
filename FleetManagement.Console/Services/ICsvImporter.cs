using System.Collections.Generic;
using FleetManagementConsole.Dtos;

namespace FleetManagementConsole.Services
{
    public interface ICsvImporter
    {
        List<Vehicle> Import(string parameter, bool ignoreFirstLine);
    }
}