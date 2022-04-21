using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Airport
{
    public class UserFlightsListDesignModel : UserFlightsListViewModel
    {
        public static UserFlightsListDesignModel Instance => new UserFlightsListDesignModel();


        public UserFlightsListDesignModel()
        {
            Items = new ObservableCollection<UserFlightsItemViewModel>
            {
                new UserFlightsItemViewModel
                {
                    Id = "BON228",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "12:00",

                    ArrivalCity = "Санкт-Петербург",
                    ArrivalAirport = "LED",
                    ArrivalDateTime = "14:00",

                    Passengers = 110,
                },
                new UserFlightsItemViewModel
                {
                    Id = "DSA421",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "11:00",

                    ArrivalCity = "Екатеринбург",
                    ArrivalAirport = "SVX",
                    ArrivalDateTime = "16:00",

                    Passengers = 154,
                }
            };
        }
    }
}
