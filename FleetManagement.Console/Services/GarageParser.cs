using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class GarageParser : IGarageParser
    {
        public Garage Parse(IConsoleInputOutput console, out uint count)
        {
            console.WriteLine("Geben Sie das Parkhaus in folgendem Format ein:");
            console.WriteInfo("Ort, Plz, Straße & Nummer, Anzahl der Parkplätze");
            var str = console.ReadLine();
            var propertyStrings = str.Split(',');
            count = (uint)propertyStrings.Count();
            if (count == 4)
            {
                uint.TryParse(propertyStrings[count - 1], out count);
                return new Garage()
                {
                    City = propertyStrings[0],
                    Zip = propertyStrings[1],
                    Street = propertyStrings[2]
                };
            }
            return null;   
        }
    }
}
