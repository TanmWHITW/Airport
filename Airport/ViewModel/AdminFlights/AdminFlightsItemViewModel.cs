﻿using Airport.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class AdminFlightsItemViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Plane { get; set; }
        
        public int PlaneId { get; set; }

        public string DepartureCity { get; set; }

        public string DepartureAirport { get; set; }

        public DateTimeOffset DepartureDateTime { get; set; }

        public string ArrivalCity { get; set; }

        public string ArrivalAirport { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }

        public int Passengers { get; set; }

        public bool IsChosen { get; set; } = false;


    }
}
