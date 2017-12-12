using FleetManagementConsole.Dtos;

namespace FleetManagementConsole.Services
{
    public interface IVehicleParser
    {
        Vehicle Parse(IConsoleInputOutput str, string parameter);
        Vehicle Parse(IConsoleInputOutput str, string parameter, out int parkingPlaceId);
        Vehicle Parse(string[] propertyStrings, string parameter);
    }
}