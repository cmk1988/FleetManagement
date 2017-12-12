using FleetManagementConsole.Dtos;

namespace FleetManagementConsole.Services
{
    public interface IGarageParser
    {
        Garage Parse(IConsoleInputOutput console, out uint count);
    }
}