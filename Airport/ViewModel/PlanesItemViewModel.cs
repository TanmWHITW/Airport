using Airport.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class PlanesItemViewModel : BaseViewModel
    {
        public string Plane { get; set; }
        public int Id { get; set; }
        public string PlaneWithId { get; set; }
        public int MaxPassengers { get; set; }
    }
}
