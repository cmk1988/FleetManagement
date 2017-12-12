using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Factories
{
    public class CommandExecuterFactory : ICommandExecuterFactory
    {
        private IVehicleManager vehilceManager;
        private IConsoleInputOutput console;
        private IVehicleParser vehicleParser;
        private IGarageManager garageManager;
        private IGarageParser garageParser;
        private ICsvImporter csvImporter;
        private IFileInputOutput file;

        public CommandExecuterFactory(
            IVehicleManager vehilceManager, 
            IConsoleInputOutput console,
            IVehicleParser vehicleParser,
            IGarageManager garageManager,
            IGarageParser garageParser,
            ICsvImporter csvImporter,
            IFileInputOutput file)
        {
            this.vehicleParser = vehicleParser;
            this.vehilceManager = vehilceManager;
            this.console = console;
            this.garageManager = garageManager;
            this.garageParser = garageParser;
            this.csvImporter = csvImporter;
            this.file = file;
        }

        public CommandExecuter Create()
        {
            return new CommandExecuter(vehilceManager, console, vehicleParser, garageManager, garageParser, csvImporter, file);
        }
    }
}
