using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace Airport
{
    public class AdminFlightsListDesignModel : AdminFlightsListViewModel
    {
        public static AdminFlightsListDesignModel Instance => new AdminFlightsListDesignModel();

        public AdminFlightsListDesignModel()
        {
            Items = new ObservableCollection<AdminFlightsItemViewModel>
            {
                new AdminFlightsItemViewModel
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
                new AdminFlightsItemViewModel
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
