using FleetManagementConsole.Dtos;
using FleetManagementConsole.Enums;
using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class CommandExecuter : IDisposable, ICommandExecuter
    {
        private Dictionary<Vehicle, ParkingPlaceOutput> selectedVehicles;
        private IVehicleManager vehicleManager;
        private IConsoleInputOutput console;
        private IVehicleParser vehicleParser;
        private IGarageManager garageManager;
        private IGarageParser garageParser;
        private ICsvImporter csvImporter;
        private IFileInputOutput file;

        public CommandExecuter(IVehicleManager vehicleManager,
            IConsoleInputOutput consoleInputOutput,
            IVehicleParser vehicleParser,
            IGarageManager garageManager,
            IGarageParser garageParser,
            ICsvImporter csvImporter,
            IFileInputOutput file
            )
        {
            this.selectedVehicles = new Dictionary<Vehicle, ParkingPlaceOutput>();
            this.vehicleManager = vehicleManager;
            this.console = consoleInputOutput;
            this.vehicleParser = vehicleParser;
            this.garageManager = garageManager;
            this.garageParser = garageParser;
            this.csvImporter = csvImporter;
            this.file = file;
        }

        public void Dispose()
        {
        }

        public void Execute(Commands command, string parameter)
        {
            switch (command)
            {
                case Commands.Add:
                    this.add(parameter);
                    break;
                case Commands.Delete:
                    this.delete();
                    break;
                case Commands.Help:
                    this.help();
                    break;
                case Commands.Output:
                    this.output(parameter);
                    break;
                case Commands.Select:
                    this.select(parameter);
                    break;
                case Commands.Tax:
                    this.tax();
                    break;
                case Commands.Park:
                    this.park(parameter);
                    break;
                case Commands.Garage:
                    this.garage(parameter);
                    break;
                case Commands.GarageInfo:
                    this.garageInfo();
                    break;
                case Commands.DeleteGarage:
                    this.deleteGarage(parameter);
                    break;
                case Commands.SelectInvalid:
                    this.selectInvalid();
                    break;
                case Commands.ImportCsv:
                    this.importCsv(parameter);
                    break;
                default:
                    throw new Exception();
            }
        }

        private void add(string parameter)
        {
            Vehicle vehicle;
            if (parameter=="g")
            {
                uint count = 0;
                var garage = garageParser.Parse(console,out count);
                if (count > 0)
                {
                    garageManager.AddGarage(garage, (int)count);
                    console.WriteInfo("Neues Parkhaus hinzugefügt und ausgewählt.");
                }
                else
                    console.WriteError("Parkhaus konnte nicht hinzugefügt werden!");
            }
            else if (parameter.Contains("+"))
            {
                parameter = parameter.Replace("+", "");
                int i = 0;
                vehicle = vehicleParser.Parse(console, parameter, out i);
                if (vehicle != null && vehicleManager.AddVehicle(vehicle, null))
                {
                    vehicleManager.AssignParkingPlace(vehicle, garageManager.GetParkingPlace(i));
                    console.WriteInfo("Fahrzeug hinzugefügt.");
                }
                else
                    console.WriteError("Fahrzeug konnte nicht hinzugefügt werden!");
            }
            else
            {
                vehicle = vehicleParser.Parse(console, parameter);
                if (vehicle != null && vehicleManager.AddVehicle(vehicle, null))
                {
                    vehicleManager.AssignParkingPlace(vehicle, garageManager.GetParkingPlace());
                    console.WriteInfo("Fahrzeug hinzugefügt.");
                }                    
                else
                    console.WriteError("Fahrzeug konnte nicht hinzugefügt werden!");
            }
        }

        private void delete()
        {
            foreach (var item in this.selectedVehicles)
            {
                vehicleManager.Delete(item.Key);
                if (item.Value != null)
                {
                    garageManager.ReleaseParkingPlace(item.Value);
                }
            }
            var word = selectedVehicles.Count == 1 ? "Fahrzeug" : "Fahrzeuge";
            console.WriteInfo($"{selectedVehicles.Count} {word} gelöscht.");
            this.selectedVehicles = new Dictionary<Vehicle, ParkingPlaceOutput>();
        }

        private void help()
        {
            this.console.WriteSelected("\n Befehle: ");
            this.console.WriteLine("help/?                  Hilfe");
            this.console.WriteLine("add/a c/m/t/g/+         PKW, Motorrad, LKW, Parkhaus hinzufügen");
            this.console.WriteLine("import table.csv        PKW, Motorrad, LKW, aus CSV-Datei importieren");
            this.console.WriteLine("garage/g                Parkhäuser inklusive Parkplätze ausgeben");
            this.console.WriteLine("garage/g 1              Parkhaus auswählen");
            this.console.WriteLine("delete/del 1            Parkhaus löschen");
            this.console.WriteLine("inv;...                 fehlerhafte Fahrzeuge auswählen");
            this.console.WriteLine("select/s k-123;...      Fahrzeug auswählen");
            this.console.WriteLine("        ...output/o     Ausgewähltes Fahrzeug ausgeben");
            this.console.WriteLine("        ...tax/t        Steuerschuld berechnen");
            this.console.WriteLine("        ...delete/del   Ausgewähltes Fahrzeug löschen");
            this.console.WriteLine("        ...park/p       Ausgewähltes Fahrzeug umparken");
            this.console.WriteLine("exit/quit/close         Programm beenden");
            this.console.WriteLine("restart/restore/re      Daten zu Programmstart wiederherstellen");
            this.console.WriteSelected("\n Verkettung von Befehlen: ");
            this.console.WriteLine("Mit ; können Sie mehrere Befehle hintereinander ausführen.");
            this.console.WriteLine("Der Befehl \"s ;o;t\" gibt zum Beispiel alle Fahrzeuge aus und berechnet anschließend die Steuerschuld.");
            this.console.WriteLine("Der Befehl \"s 1;del;s ;o\" löscht zum Beispiel Fahrzeug 1 und gibt anschließend alle restlichen Fahrzeuge aus.");
            this.console.WriteSelected("\n Hinweise: ");
            this.console.WriteInfo("Parkhäuser können nur gelöscht werden wenn sie keine Fahrzeuge beinhalten!");
            this.console.WriteInfo("Fahrzeuge können nur hinzugefügt werden wenn das Kennzeichen eindeutig ist!");
        }

        private void output(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                foreach (var item in this.selectedVehicles)
                {
                    console.WriteLine(VehicleStringCreator.GetOutputString(item.Key) + $" Parkhaus: {item.Value?.Garage.City}, {item.Value?.Garage.Zip}, {item.Value?.Garage.Street}, Parkplatz: {item.Value?.ParkingPlace.Id}");
                }
            }
            else if (parameter.StartsWith(" v "))
            {
                parameter = parameter.Replace(" v ", "");
                var data = "";
                foreach (var item in this.selectedVehicles)
                {
                    data += VehicleStringCreator.GetOutputString(item.Key) + "\r\n";                   
                }
                file.WriteLine(parameter, data);
                console.WriteInfo($"Ausgabe in Datei: {parameter}");
            }
            else
            {
                var data = "";
                foreach (var item in this.selectedVehicles)
                {
                    data += VehicleStringCreator.GetOutputString(item.Key) + $" Parkhaus: {item.Value?.Garage.City}, {item.Value?.Garage.Zip}, {item.Value?.Garage.Street}, Parkplatz: {item.Value?.ParkingPlace.Id} \r\n";
                }
                file.WriteLine(parameter, data);
                console.WriteInfo($"Ausgabe in Datei: {parameter}");
            }
            if(this.selectedVehicles.Count==0)
                console.WriteInfo("Es wurden keine Fahrzeuge ausgewählt.");
        }

        private void select(string parameter)
        {
            var result = this.vehicleManager.FindCarsByLicensePlate(parameter);
            foreach (var item in result)
            {
                if(!this.selectedVehicles.Keys.Contains(item.Key))                
                    this.selectedVehicles.Add(item.Key, item.Value);
            }
        }

        private void selectInvalid()
        {
            var result = this.vehicleManager.SelectInvalid();
            foreach (var item in result)
            {
                this.selectedVehicles.Add(item.Key, item.Value);
            }
        }

        private void importCsv(string parameter)
        {
            bool b = true;
            if (parameter.Contains("+"))
            {
                parameter = parameter.Replace("+", "");
                b = false;
            }
            var result = this.csvImporter.Import(parameter, b);
            int count = 0;
            foreach (var item in result)
            {
                if (this.vehicleManager.AddVehicle(item, null))
                    count++;
            }
            var word = count == 1 ? "Fahrzeug" : "Fahrzeuge";
            console.WriteInfo($"{count} {word} importiert.");
        }

        private void tax()
        {
            var tax = 0m;
            foreach (var item in this.selectedVehicles)
            {
                tax+=VehicleTaxCalculator.Calculate(item.Key);
            }
            console.WriteLine($"Steuerschuld: {tax} Euro");
        }

        private void park(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                foreach (var item in this.selectedVehicles)
                {
                    console.WriteInfo("Bitte geben Sie die Parkplatznummer für \"" + item.Key.LicensePlate + "\" ein");
                    var input = console.ReadLine();
                    int parkingPlaceId = 0;
                    ParkingPlaceOutput parkingPlace = null;
                    if (int.TryParse(input, out parkingPlaceId))
                    {
                        parkingPlace = garageManager.GetParkingPlace(parkingPlaceId);
                    }
                    else
                    {
                        parkingPlace = garageManager.GetParkingPlace();
                    }
                    if (item.Value != null)
                        garageManager.ReleaseParkingPlace(item.Value);
                    vehicleManager.AssignParkingPlace(item.Key, parkingPlace);
                    console.WriteInfo("Parkplatz erfolgreich zugewiesen.");
                }
            }
            else
            {
                int garageId = 0;
                var garages = garageManager.GetAllGarages();
                ParkingPlaceOutput parkingPlace = null;
                int i = 0;
                if (int.TryParse(parameter, out garageId) && garageId > 0 && garageId <= garages.Count)
                {
                    garageManager.SelectGarage(garages[garageId - 1]);
                    foreach (var item in this.selectedVehicles)
                    {
                        parkingPlace = garageManager.GetParkingPlace();
                        if (item.Value != null)
                            garageManager.ReleaseParkingPlace(item.Value);
                        vehicleManager.AssignParkingPlace(item.Key, parkingPlace);
                        i++;
                    }
                }
                var word = i == 1 ? "Parkplatz" : "Parkplätze";
                console.WriteInfo($"{i} {word} erfolgreich zugewiesen.");
            }
            this.selectedVehicles = new Dictionary<Vehicle, ParkingPlaceOutput>();
        }

        private void garage(string parameter)
        {
            var garages = garageManager.GetAllGarages();
            int garageId = 0;
            if (int.TryParse(parameter, out garageId) && garageId>0 && garageId <= garages.Count)
            {
                garageManager.SelectGarage(garages[garageId-1]);
                console.WriteInfo("Parkhaus erfolgreich ausgewählt.");
            }
            else
                console.WriteError("Parkhaus konnte nicht ausgewählt werden!");
        }

        private void deleteGarage(string parameter)
        {
            var garages = garageManager.GetAllGarages();
            int garageId = 0;
            if (int.TryParse(parameter, out garageId) && garageId > 0 && garageId <= garages.Capacity)
            {
                if(garageManager.DeleteGarage(garages[garageId - 1]))
                    console.WriteInfo("Parkhaus erfolgreich gelöscht.");
                else
                    console.WriteError("Parkhaus konnte nicht gelöscht werden!");
            }
            else
                console.WriteError("Parkhaus konnte nicht gelöscht werden!");
        }

        private void garageInfo()
        {
            var garages = garageManager.GetAllGarages();
            int i = 0;
            foreach (var garage in garages)
            {
                i++;
                var freePlaces = garageManager.GetFreePlacesCount(garage);
                if (freePlaces.IsSelected)
                    console.WriteSelected($"Parkhaus {i}: {garage.City}, {garage.Zip}, {garage.Street}, Freie Parkplätze: {freePlaces.Free}/{freePlaces.Total}");
                else
                    console.WriteLine($"Parkhaus {i}: {garage.City}, {garage.Zip}, {garage.Street}, Freie Parkplätze: {freePlaces.Free}/{freePlaces.Total}");
            }
        }
    }
}
