﻿using System;

namespace Airport
{
    public class AdminFlightsItemDesignModel : AdminFlightsItemViewModel
    {
        public static AdminFlightsItemDesignModel Instance => new AdminFlightsItemDesignModel();

        public AdminFlightsItemDesignModel()
        {
            Id = "BONK228";
            Plane = "Broyler 777";

            DepartureCity = "Москва";
            DepartureAirport = "SVO";
            DepartureDateTime = DateTime.UtcNow;

            ArrivalCity = "Санкт-Петербург";
            ArrivalAirport = "LED";
            ArrivalDateTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));

            Passengers = 28;
        }
    }
}
