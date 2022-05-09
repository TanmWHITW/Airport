using Airport.NET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport
{
    public class AdminFlightsListViewModel : BaseViewModel
    {
        protected ObservableCollection<AdminFlightsItemViewModel> mItems;

        public string Id { get; set; }

        public PlanesItemViewModel Plane { get; set; }

        public string DepartureDateTime { get; set; }

        public string ArrivalCity { get; set; }

        public string ArrivalAirport { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }

        public int Passengers { get; set; }

        public CitiesItemViewModel City { get; set; }

        public ObservableCollection<AdminFlightsItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

            }
        }

        public List<CitiesItemViewModel> Cities { get; set; } = new List<CitiesItemViewModel> { 
            new CitiesItemViewModel
            {
                City = "Санкт-Петербург",
                Airport = "LED",
                FlightTime = TimeSpan.Parse("02:00:00"),
            } 
        };
        public List<PlanesItemViewModel> Planes { get; set; } = new List<PlanesItemViewModel> {
            new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 1,
            }
        };

        public ICommand AddNewFlightCommand { get; set; }
        public ICommand DeleteChosenFlightCommand { get; set; }


        public AdminFlightsListViewModel()
        {
            AddNewFlightCommand = new RelayCommand(AddNewFlight);
            DeleteChosenFlightCommand = new RelayCommand(DeleteChosenFlight);

        }

        public void AddNewFlight()
        {
            if (Items == null)
                Items = new ObservableCollection<AdminFlightsItemViewModel>();

            DateTimeOffset dateTime = DateTimeOffset.Now;

            var flight = new AdminFlightsItemViewModel
            {
                Id = Id,
                Plane = Plane.Plane,
                PlaneId = Plane.Id,
                DepartureAirport = "SVO",
                DepartureCity = "Москва",
                DepartureDateTime = DateTimeOffset.Parse(DepartureDateTime),
                ArrivalAirport = City.Airport,
                ArrivalCity = City.City,
                ArrivalDateTime = DateTimeOffset.Parse(DepartureDateTime).Add(City.FlightTime),
                Passengers = Passengers,
            };
            if (Items.Any(item => item.Id.Equals(flight.Id)))
            {
                Items.Remove(Items.First(item => item.Id.Equals(flight.Id)));
                Items.Add(flight);
                return;
            }
            Items.Add(flight);
        }

        public void DeleteChosenFlight()
        {
            foreach (var item in Items.ToArray())
                if (item.IsChosen == true)
                    Items.Remove(item);
        }
    }
}
