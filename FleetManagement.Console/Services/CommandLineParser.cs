using FleetManagementConsole.Enums;
using FleetManagementConsole.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class CommandLineParser
    {
        private IConsoleInputOutput console;
        private Dictionary<string, Commands> commandDictionary;
        private IVehicleManager vehicleManager;
        private ICommandExecuterFactory commandExecuterFactory;

        public CommandLineParser(IConsoleInputOutput console, Dictionary<string, Commands> commandDictionary, IVehicleManager vehicleManager, ICommandExecuterFactory commandExecuterFactory)
        {
            this.console = console;
            this.commandDictionary = commandDictionary;
            this.vehicleManager = vehicleManager;
            this.commandExecuterFactory = commandExecuterFactory;
        }

        public int ReadCommand()
        {
            var commandLine = this.console.ReadLine();
            var commands = this.getPartialCommandStrings(commandLine);
            return this.InvokeCommand(commands);
        }

        private List<string> getPartialCommandStrings(string commandString)
        {
            return commandString.Split(';').ToList();
        }

        private int InvokeCommand(List<string> commands)
        {
            bool b = false;
            using (var commandExecuter = commandExecuterFactory.Create())
            {
                foreach (var partialCommand in commands)
                {
                    foreach (var command in commandDictionary)
                    {
                        if (partialCommand.StartsWith(command.Key))
                        {
                            if (command.Value==Commands.Exit)
                                return 0;
                            if (command.Value == Commands.Restore)
                                return 2;
                            var parameter = partialCommand.Replace(command.Key, "");
                            parameter = parameter.Replace(";", "");
                            commandExecuter.Execute(command.Value, parameter);
                            b = true;
                            break;
                        }
                    }
                }
                if (!b)
                    console.WriteError("Befehl nicht gefunden!");
            }

            return 1;
        }
    }
}
