namespace FleetManagementConsole.Dtos
{
    public class Car : Vehicle
    {
        public int Capacity { get; set; }
        public int Power { get; set; }
        public PollutantClasses PollutantClass { get; set; }
    }
}
