using System;
using Newtonsoft.Json;

namespace Airport
{
    public class UserFlightsItemViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public DateTimeOffset FlightDateDDMM { get; set; }

        public string Plane { get; set; }

        public string DepartureCity { get; set; }

        public string DepartureAirport { get; set; }

        public DateTimeOffset DepartureDateTime { get; set; }

        public string ArrivalCity { get; set; }

        public string ArrivalAirport { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }

        public int Passengers { get; set; }
    }
}
