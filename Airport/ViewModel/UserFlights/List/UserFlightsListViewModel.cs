using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport
{
    public class UserFlightsListViewModel: BaseViewModel
    {
        public ObservableCollection<UserFlightsItemViewModel> Items { get; set; }
    }
}
