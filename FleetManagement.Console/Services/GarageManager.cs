using FleetManagementConsole.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementConsole.Services
{
    public class GarageManager : IGarageManager
    {
        private Garage selectedGarage;
        private Dictionary<Garage, List<ParkingPlace>> parkingPlaceDictionary;

        public GarageManager()
        {
            this.parkingPlaceDictionary = new Dictionary<Garage, List<ParkingPlace>>();
        }

        public ParkingPlaceOutput GetParkingPlace()
        {
            var parkingPlace = this.parkingPlaceDictionary[selectedGarage].FirstOrDefault(x => x.IsUsed == false);
            if (parkingPlace!=null)
            {
                parkingPlace.IsUsed = true;
                return new ParkingPlaceOutput()
                {
                    Garage = selectedGarage,
                    ParkingPlace = parkingPlace
                };
            }
            return null;
        }

        public ParkingPlaceOutput GetParkingPlace(int id)
        {
            var parkingPlace = this.parkingPlaceDictionary[selectedGarage].FirstOrDefault(x => x.Id == id && x.IsUsed == false);
            if (parkingPlace != null)
            {
                parkingPlace.IsUsed = true;
                return new ParkingPlaceOutput()
                {
                    Garage = selectedGarage,
                    ParkingPlace = parkingPlace
                };
            }
            return null;
        }

        public void AddGarage(Garage garage, int capacity)
        {
            if (garage == null)
                return;

            this.selectedGarage = garage;
            var list = new List<ParkingPlace>();
            for (int i=0;i<capacity;i++)
            {
                list.Add(new ParkingPlace(id: i+1, isUsed: false));
            }
            this.parkingPlaceDictionary.Add(garage, list);
        }

        public List<Garage> GetAllGarages()
        {
            return new List<Garage>(this.parkingPlaceDictionary.Keys);
        }

        public void SelectGarage(Garage garage)
        {
            this.selectedGarage = garage;
        }

        public void ReleaseParkingPlace(ParkingPlaceOutput parkingPlace)
        {
            parkingPlace.ParkingPlace.IsUsed = false;
        }

        public FreeParkingPlaces GetFreePlacesCount(Garage garage)
        {
            return new FreeParkingPlaces()
            {
                Total = this.parkingPlaceDictionary[garage].Count(),
                Free = this.parkingPlaceDictionary[garage].Count(x => !x.IsUsed),
                IsSelected = garage == selectedGarage
            };
        }

        public bool DeleteGarage(Garage garage)
        {
            if (this.parkingPlaceDictionary[garage].Count(x => x.IsUsed) == 0)
            {
                this.parkingPlaceDictionary.Remove(garage);
                if (selectedGarage == garage)
                    this.selectedGarage = this.parkingPlaceDictionary.FirstOrDefault().Key;
                return true;
            }
            return false;
        }
    }
}
