using FleetManagementConsole.Dtos;
using FleetManagementConsole.Services;

namespace FleetManagementConsole.Factories
{
    public class GarageManagerFactory
    {
        public GarageManager Create()
        {
            var garageManager = new GarageManager();
            garageManager.AddGarage(new Garage
                {
                    City = "Köln",
                    Street = "Westerwaldstr. 99",
                    Zip = "51105"
                },400
            );
            return garageManager;
        }
    }
}
