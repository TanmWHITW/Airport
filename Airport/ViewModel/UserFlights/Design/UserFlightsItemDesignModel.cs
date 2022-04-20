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
            DepartureDateTime = "12:00";

            ArrivalCity = "Санкт-Петербург";
            ArrivalAirport = "LED";
            ArrivalDateTime = "14:00";

            Passengers = 28;
        }
    }
}
