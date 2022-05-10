using System;
using Airport.NET;
using Newtonsoft.Json;

namespace Airport
{
    public class UserFlightsItemViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Plane { get; set; }

        public string DepartureCity { get; set; }

        public string DepartureAirport { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public string ArrivalCity { get; set; }

        public string ArrivalAirport { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public int Passengers { get; set; }
    }
}
