using System.Collections.Generic;
using FleetManagementConsole.Dtos;

namespace FleetManagementConsole.Services
{
    public interface IGarageManager
    {
        void AddGarage(Garage garage, int capacity);
        List<Garage> GetAllGarages();
        ParkingPlaceOutput GetParkingPlace();
        ParkingPlaceOutput GetParkingPlace(int id);
        void ReleaseParkingPlace(ParkingPlaceOutput parkingPlace);
        void SelectGarage(Garage garage);
        FreeParkingPlaces GetFreePlacesCount(Garage garage);
        bool DeleteGarage(Garage garage);
    }
}