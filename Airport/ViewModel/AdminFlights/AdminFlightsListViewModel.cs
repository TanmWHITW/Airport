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

        public string DepartureCity { get; set; } = "Москва";

        public string DepartureAirport { get; set; } = "SVO";

        public DateTimeOffset DepartureDateTime { get; set; } = DateTimeOffset.Now;

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

                // Update filtered list to match
                FilteredItems = new ObservableCollection<AdminFlightsItemViewModel>(mItems);
            }
        }

        public List<CitiesItemViewModel> Cities { get; set; } = new List<CitiesItemViewModel> { 
            new CitiesItemViewModel
            {
                City = "Санкт-Петербург",
                FlightTime = DateTime.Parse("04:22"),
            } 
        };
        public List<PlanesItemViewModel> Planes { get; set; } = new List<PlanesItemViewModel> {
            new PlanesItemViewModel
            {
                Plane = "Airbus A320",
                Id = 1,
            }
        };

        public ObservableCollection<AdminFlightsItemViewModel> FilteredItems { get; set; }

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

            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<AdminFlightsItemViewModel>();

            var flight = new AdminFlightsItemViewModel
            {
                Id = Id,
                Plane = Plane.Plane,
                PlaneId = Plane.Id,
                DepartureAirport = DepartureAirport,
                DepartureCity = DepartureCity,
                DepartureDateTime = DepartureDateTime,
                ArrivalAirport = ArrivalAirport,
                ArrivalCity = City.City,
                ArrivalDateTime = ArrivalDateTime,
                Passengers = Passengers,
            };
            if (Items.Any(item => item.Id.Equals(flight.Id)))
            {
                Items.Remove(Items.First(item => item.Id.Equals(flight.Id)));
                FilteredItems.Remove(FilteredItems.First(item => item.Id.Equals(flight.Id)));

                Items.Add(flight);
                FilteredItems.Add(flight);
                return;
            }
            Items.Add(flight);
            FilteredItems.Add(flight);
        }

        public void DeleteChosenFlight()
        {
            foreach (var item in Items.ToArray())
                if (item.IsChosen == true)
                {
                    Items.Remove(item);
                    FilteredItems?.Remove(item);
                }
        }
    }
}
