using FleetManagementConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagementConsole.Dtos;

namespace FleetManagement.Tests.Mocks
{
    public class GarageManagerMock : IGarageManager
    {
        public Action<Garage, int> AddGarageAction { get; set; }
        public Action<Garage> DeleteGarageAction { get; set; }
        public Action GetAllGaragesAction { get; set; }
        public Action<Garage> GetFreePlacesCountAction { get; set; }
        public Action GetParkingPlaceAction1 { get; set; }
        public Action<int> GetParkingPlaceAction2 { get; set; }
        public Action<ParkingPlaceOutput> ReleaseParkingPlaceAction { get; set; }
        public Action<Garage> SelectGarageAction { get; set; }

        public bool DeleteGarageReturn { get; set; }
        public List<Garage> GetAllGaragesReturn { get; set; }
        public FreeParkingPlaces GetFreePlacesCountReturn { get; set; }
        public ParkingPlaceOutput GetParkingPlaceReturn { get; set; }

        public void AddGarage(Garage garage, int capacity)
        {
            AddGarageAction?.Invoke(garage, capacity);
        }

        public bool DeleteGarage(Garage garage)
        {
            DeleteGarageAction?.Invoke(garage);
            return DeleteGarageReturn;
        }

        public List<Garage> GetAllGarages()
        {
            GetAllGaragesAction?.Invoke();
            return GetAllGaragesReturn;
        }

        public FreeParkingPlaces GetFreePlacesCount(Garage garage)
        {
            GetFreePlacesCountAction?.Invoke(garage);
            return GetFreePlacesCountReturn;
        }

        public ParkingPlaceOutput GetParkingPlace()
        {
            GetParkingPlaceAction1?.Invoke();
            return GetParkingPlaceReturn;
        }

        public ParkingPlaceOutput GetParkingPlace(int id)
        {
            GetParkingPlaceAction2?.Invoke(id);
            return GetParkingPlaceReturn;
        }

        public void ReleaseParkingPlace(ParkingPlaceOutput parkingPlace)
        {
            ReleaseParkingPlaceAction?.Invoke(parkingPlace);
        }

        public void SelectGarage(Garage garage)
        {
            SelectGarageAction?.Invoke(garage);
        }
    }
}
