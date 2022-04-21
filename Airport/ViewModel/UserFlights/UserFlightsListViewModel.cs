using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Airport
{
    public class UserFlightsListViewModel: BaseViewModel
    {

        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;


        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<UserFlightsItemViewModel> mItems;

        #endregion

       
        public ObservableCollection<UserFlightsItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<UserFlightsItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    // Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }

        public UserFlightsListViewModel()
        {
            // Create commands
            SearchCommand = new RelayCommand(Search);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            Items = new ObservableCollection<UserFlightsItemViewModel>
            {
                new UserFlightsItemViewModel
                {
                    Id = "BON228",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "12:00",

                    ArrivalCity = "Санкт-Петербург",
                    ArrivalAirport = "LED",
                    ArrivalDateTime = "14:00",

                    Passengers = 110,
                },
                new UserFlightsItemViewModel
                {
                    Id = "DSA421",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "11:00",

                    ArrivalCity = "Екатеринбург",
                    ArrivalAirport = "SVX",
                    ArrivalDateTime = "16:00",

                    Passengers = 154,
                },new UserFlightsItemViewModel
                {
                    Id = "FDASF328",
                    Plane = "Airbus A321neo",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:40",

                    ArrivalCity = "Липецк",
                    ArrivalAirport = "LPK",
                    ArrivalDateTime = "19:00",

                    Passengers = 190,
                },new UserFlightsItemViewModel
                {
                    Id = "BOF432",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "00:00",

                    ArrivalCity = "Нижнекамск",
                    ArrivalAirport = "NBC",
                    ArrivalDateTime = "02:20",

                    Passengers = 135,
                },new UserFlightsItemViewModel
                {
                    Id = "ARB492",
                    Plane = "Airbus А321",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:30",

                    ArrivalCity = "Саранск",
                    ArrivalAirport = "SKX",
                    ArrivalDateTime = "18:57",

                    Passengers = 232,
                },new UserFlightsItemViewModel
                {
                    Id = "BOIG432",
                    Plane = "Boeing 767-200",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "09:55",

                    ArrivalCity = "Череповец",
                    ArrivalAirport = "CEE",
                    ArrivalDateTime = "11:20",

                    Passengers = 142,
                },new UserFlightsItemViewModel
                {
                    Id = "AIR232",
                    Plane = "Airbus A350-900",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "15:40",

                    ArrivalCity = "Анапа",
                    ArrivalAirport = "AAQ",
                    ArrivalDateTime = "17:50",

                    Passengers = 253,
                },new UserFlightsItemViewModel
                {
                    Id = "BOR533",
                    Plane = "Boeing 737-800",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "18:40",

                    ArrivalCity = "Иркутск",
                    ArrivalAirport = "IKT",
                    ArrivalDateTime = "23:55",

                    Passengers = 195,
                },new UserFlightsItemViewModel
                {
                    Id = "SSP322",
                    Plane = "Sukhoi SuperJet 100",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "10:10",

                    ArrivalCity = "Магнитогорск",
                    ArrivalAirport = "MQF",
                    ArrivalDateTime = "14:32",

                    Passengers = 65,
                },new UserFlightsItemViewModel
                {
                    Id = "BOE342",
                    Plane = "Boeing 767-200",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "19:00",

                    ArrivalCity = "Ростов-на-Дону",
                    ArrivalAirport = "ROV",
                    ArrivalDateTime = "22:30",

                    Passengers = 164,
                },new UserFlightsItemViewModel
                {
                    Id = "BON348",
                    Plane = "Boeing 777-300ER",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "12:50",

                    ArrivalCity = "Архангельск",
                    ArrivalAirport = "ARH",
                    ArrivalDateTime = "14:50",

                    Passengers = 126,
                },new UserFlightsItemViewModel
                {
                    Id = "BBD238",
                    Plane = "Boeing 737-400",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "13:00",

                    ArrivalCity = "Магадан",
                    ArrivalAirport = "GDX",
                    ArrivalDateTime = "19:50",

                    Passengers = 100,
                },new UserFlightsItemViewModel
                {
                    Id = "BFD438",
                    Plane = "Airbus А321",

                    DepartureCity = "Москва",
                    DepartureAirport = "SVO",
                    DepartureDateTime = "03:00",

                    ArrivalCity = "Мурманск",
                    ArrivalAirport = "MMK",
                    ArrivalDateTime = "06:40",

                    Passengers = 169,
                },
            };
        }

        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count() <= 0)
            {
                // Make filtered list the same
                
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items ?? Enumerable.Empty<UserFlightsItemViewModel>());

                // Set last search text
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(
                Items.Where(item => item.Id.Contains(SearchText)));

            // Set last search text
            mLastSearchText = SearchText;
        }


        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text...
            if (!string.IsNullOrEmpty(SearchText))
                // Clear the text
                SearchText = string.Empty;
        }
    }
}
