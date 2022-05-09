using Airport.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class CitiesItemViewModel: BaseViewModel
    {
        public string City { get; set; }    
        public DateTimeOffset FlightTime { get; set; }
    }
}
