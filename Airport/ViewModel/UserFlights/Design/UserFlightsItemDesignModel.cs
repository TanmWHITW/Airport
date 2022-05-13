using System;
namespace Airport
{
    public class UserFlightsItemDesignModel : UserFlightsItemViewModel
    {
        public static UserFlightsItemDesignModel Instance => new UserFlightsItemDesignModel();
        public UserFlightsItemDesignModel()
        {
            Id = "BONK228";
            Plane = "Broyler 777";
            DepartureCity = "Москва";
            DepartureAirport = "SVO";
            DepartureDateTime = DateTime.UtcNow;
            ArrivalCity = "Санкт-Петербург";
            ArrivalAirport = "LED";
            ArrivalDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1.3));
            Passengers = 28;
        }
    }
}
