using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace Airport
{
    public class 
        UserFlightsListDesignModel : UserFlightsListViewModel
    {
        public static UserFlightsListDesignModel Instance => new UserFlightsListDesignModel();

        public UserFlightsListDesignModel()
        {
            Items = new ObservableCollection<UserFlightsItemViewModel>
            {
                new UserFlightsItemViewModel
                {
                    Id = "BONK228",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(0)),

                    ArrivalCity = "Санкт-Петербург",
                    ArrivalAirport = "LED",
                    ArrivalDateTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.0)),

                    Passengers = 110,
                },
                new UserFlightsItemViewModel
                {
                    Id = "BINK228",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(1.3)),

                    ArrivalCity = "Екатеринбург",
                    ArrivalAirport = "SVX",
                    ArrivalDateTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(4.2)),

                    Passengers = 154,
                }
            };
        }
    }
}
