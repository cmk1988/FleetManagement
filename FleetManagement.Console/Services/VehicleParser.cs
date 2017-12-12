using FleetManagementConsole;
using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class VehicleParser : IVehicleParser
    {
        public Vehicle Parse(IConsoleInputOutput console, string parameter)
        {
            string str;
            
            if (parameter == "c")
            {
                console.WriteLine("Geben Sie den PKW in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Hubraum, Leistung, Schadstoffklasse [0-schadstoffarm, 1-normal, 2-Diesel] ");
                str = console.ReadLine();
                var propertyStrings = str.Split(',');
                if (propertyStrings.Count() == 8)
                    return Parse(propertyStrings,parameter);
            }
            else if (parameter == "m")
            {
                console.WriteLine("Geben Sie das Motorrad in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Hubraum");
                str = console.ReadLine();
                var propertyStrings = str.Split(',');
                if (propertyStrings.Count() == 6)
                    return Parse(propertyStrings, parameter);
            }
            else if (parameter == "t")
            {
                console.WriteLine("Geben Sie den LKW in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Anzahl der Achsen, Zuladung in t ");
                str = console.ReadLine();
                var propertyStrings = str.Split(',');
                if (propertyStrings.Count() == 7)
                    return Parse(propertyStrings, parameter);
            }
            return null;
        }

        public Vehicle Parse(string[] propertyStrings, string parameter)
        {
            Vehicle vehicle = null;
            if (parameter == "c")
            {
                vehicle = new Car();
                parseVehicle(propertyStrings, vehicle);
                parseCar(propertyStrings, vehicle as Car);
            }
            else if (parameter == "m")
            {
                vehicle = new Motorcycle();
                parseVehicle(propertyStrings, vehicle);
                parseMotorcycle(propertyStrings, vehicle as Motorcycle);
            }
            else if (parameter == "t")
            {
                vehicle = new Truck();
                parseVehicle(propertyStrings, vehicle);
                parseTruck(propertyStrings, vehicle as Truck);
            }
            return vehicle;
        }

        private void parseVehicle(string[] propertyStrings, Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            int year;
            decimal price;
            int.TryParse(propertyStrings[3], out year);
            decimal.TryParse(propertyStrings[4], out price);
            vehicle.Manufacturer = propertyStrings[0];
            vehicle.Model = propertyStrings[1];
            vehicle.LicensePlate = propertyStrings[2];
            vehicle.Year = year;
            vehicle.NewPrice = price;
        }

        private void parseCar(string[] propertyStrings, Car vehicle)
        {
            if (vehicle == null)
                return;
            
            int capacity;
            int power;
            int pollutantClass;
            int.TryParse(propertyStrings[5], out capacity);
            int.TryParse(propertyStrings[6], out power);
            int.TryParse(propertyStrings[7], out pollutantClass);
            vehicle.Capacity = capacity;
            vehicle.Power = power;
            vehicle.PollutantClass = (PollutantClasses)pollutantClass;
        }

        private void parseMotorcycle(string[] propertyStrings, Motorcycle vehicle)
        {
            if (vehicle == null)
                return;

            int capacity;
            int.TryParse(propertyStrings[5], out capacity);
            vehicle.Capacity = capacity;
        }

        private void parseTruck(string[] propertyStrings, Truck vehicle)
        {
            if (vehicle == null)
                return;

            int axis;
            double payload;
            int.TryParse(propertyStrings[5], out axis);
            double.TryParse(propertyStrings[6], out payload);
            vehicle.Axis = axis;
            vehicle.Payload = payload;
        }

        public Vehicle Parse(IConsoleInputOutput console, string parameter, out int parkingPlaceId)
        {
            parkingPlaceId = 0;
            string[] propertyStrings = null;
            if (parameter == "c")
            {
                console.WriteLine("Geben Sie den PKW in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Hubraum, Leistung, Schadstoffklasse [0-schadstoffarm, 1-normal, 2-Diesel], Parkplatznummer ");
                propertyStrings = this.preParse(console, 923, out parkingPlaceId);
            }
            else if (parameter == "m")
            {
                console.WriteLine("Geben Sie das Motorrad in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Hubraum, Parkplatznummer");
                propertyStrings = this.preParse(console, 7, out parkingPlaceId);
            }
            else if (parameter == "t")
            {
                console.WriteLine("Geben Sie den LKW in folgendem Format ein:");
                console.WriteInfo("Hersteller, Modell, Kennzeichen, Jahr der Erstzulassung, Anschaffungspreis, Anzahl der Achsen, Zuladung in t, Parkplatznummer ");
                propertyStrings = this.preParse(console, 8, out parkingPlaceId);
            }
            return this.Parse(propertyStrings, parameter);
        }

        private string[] preParse(IConsoleInputOutput console, int count, out int parkingPlaceId)
        {
            parkingPlaceId = 0;
            var str = console.ReadLine();
            var propertyStrings = str.Split(',');
            if (propertyStrings.Count() == count)
                int.TryParse(propertyStrings[count-1], out parkingPlaceId);
            return propertyStrings;
        }
    }
}
