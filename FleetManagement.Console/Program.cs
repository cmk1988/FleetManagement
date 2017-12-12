using FleetManagementConsole.Factories;
using FleetManagementConsole.Services;

namespace FleetManagementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 2;
            while(result==2)
            {
                IGarageManager garageManager = new GarageManagerFactory().Create();
                IConsoleInputOutput consoleInputOutput = new ConsoleInputOutput();
                IVehicleManager vehicleManager = VehicleManagerFactory.Create(garageManager);
                IVehicleParser vehicleParser = new VehicleParser();
                IGarageParser garageParser = new GarageParser();
                IFileInputOutput file = new FileInputOutput();
                ICsvImporter csvImporter = new CsvImporter(file, vehicleParser);
                ICommandExecuterFactory commandExecuterFactory = new CommandExecuterFactory(vehicleManager, consoleInputOutput, vehicleParser, garageManager, garageParser, csvImporter, file);
                var commandLineParser = new CommandLineParser(consoleInputOutput, CommandDictionaryFactory.Create(), vehicleManager, commandExecuterFactory);
                while ((result=commandLineParser.ReadCommand()) == 1);
                if (result == 2)
                    consoleInputOutput.WriteInfo("Daten werden wiederhergestellt.");
            }
        }
    }
}
