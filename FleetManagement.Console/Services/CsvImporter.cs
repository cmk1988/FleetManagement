using FleetManagementConsole.Dtos;
using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class CsvImporter : ICsvImporter
    {
        private IFileInputOutput file;
        private IVehicleParser vehilceParser;

        public CsvImporter(IFileInputOutput file, IVehicleParser vehilceParser)
        {
            this.file = file;
            this.vehilceParser = vehilceParser;
        }

        public List<Vehicle> Import(string parameter, bool ignoreFirstLine)
        {
            var list = new List<Vehicle>();
            var lines = file.ReadLine(parameter);
            if (lines==null)
                return list;
            if (ignoreFirstLine)
                lines = lines.Skip(1).ToArray();
            foreach (var line in lines)
            {
                var properties = line.Split(',');
                if (properties.Count() == 8)
                    list.Add(vehilceParser.Parse(properties, "c"));
                else if (properties.Count() == 6)
                    list.Add(vehilceParser.Parse(properties, "m"));
                else if (properties.Count() == 7)
                    list.Add(vehilceParser.Parse(properties, "t"));
            }
            return list;
        }        
    }
}
