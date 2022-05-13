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
        public string Airport { get; set; }
        public TimeSpan FlightTime { get; set; }
        public TimeSpan TimeZoneDifference { get; set; }
    }
}
