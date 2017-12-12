using FleetManagementConsole.Enums;

namespace FleetManagementConsole.Services
{
    public interface ICommandExecuter
    {
        void Dispose();
        void Execute(Commands command, string parameter);
    }
}