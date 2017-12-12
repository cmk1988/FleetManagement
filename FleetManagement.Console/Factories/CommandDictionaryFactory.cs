using FleetManagementConsole.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Factories
{
    public class CommandDictionaryFactory
    {
        public static Dictionary<string,Commands> Create()
        {
            return new Dictionary<string, Commands>
            {
                { "?", Commands.Help },
                { "help", Commands.Help },
                { "add ", Commands.Add },
                { "a ", Commands.Add },
                { "select ", Commands.Select },
                { " select ", Commands.Select },
                { "s ", Commands.Select },
                { " s ", Commands.Select },
                { "tax", Commands.Tax },
                { " tax", Commands.Tax },
                { "t", Commands.Tax },
                { " t", Commands.Tax },
                { "output", Commands.Output },
                { " output", Commands.Output },
                { "o", Commands.Output },
                { " o", Commands.Output },
                { "delete ", Commands.DeleteGarage },
                { "del ", Commands.DeleteGarage },
                { "delete", Commands.Delete },
                { "del", Commands.Delete },
                { "exit", Commands.Exit },
                { "quit", Commands.Exit },
                { "close", Commands.Exit },
                { "park", Commands.Park },
                { "p", Commands.Park },
                { "garage ", Commands.Garage },
                { "g ", Commands.Garage },
                { "garage", Commands.GarageInfo },
                { "g", Commands.GarageInfo },
                { "garageinfo", Commands.GarageInfo },
                { "gi", Commands.GarageInfo },
                { "restore", Commands.Restore },
                { "restart", Commands.Restore },
                { "re", Commands.Restore },
                { "inv", Commands.SelectInvalid },
                { "import ", Commands.ImportCsv },
                { "i ", Commands.ImportCsv },
            };
        }
    }
}
