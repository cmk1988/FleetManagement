namespace FleetManagementConsole.Dtos
{
    public abstract class Vehicle
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        public decimal NewPrice { get; set; }
    }
}
