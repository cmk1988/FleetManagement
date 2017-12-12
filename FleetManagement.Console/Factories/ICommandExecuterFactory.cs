using FleetManagementConsole.Services;

namespace FleetManagementConsole.Factories
{
    public interface ICommandExecuterFactory
    {
        CommandExecuter Create();
    }
}