using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.IO;
using Airport.NET;
using System.Threading.Tasks;
namespace Airport
{
    public class UserFlightsListViewModel : BaseViewModel
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
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchDay;
        protected string mLastSearchDay;
        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchMonth;
        protected string mLastSearchMonth;
        public DateTime mCurrentDate;
        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<UserFlightsItemViewModel> mItems;
        #endregion
        #region Public Properties
        public DateTime CurrentDate { get; set; }
        public DateTime PreviousDate => CurrentDate.AddDays(-1);
        public DateTime NextDate => CurrentDate.AddDays(1);
        public bool IsItemsEmpty => !FilteredItems.Any();
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
            }
        }
        #endregion
        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchFlightsCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand SortPlaneCommand { get; set; }
        public ICommand SortDepartureDateCommand { get; set; }
        public ICommand SortArrivalCityCommand { get; set; }
        public ICommand SortPassengersCommand { get; set; }
        public ICommand SearchFlightPreviousDateCommand { get; set; }
        public ICommand SearchFlightNextDateCommand { get; set; }
        public ICommand SetupTodayFlightsCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public UserFlightsListViewModel()
        {
            // Create commands
            SearchFlightsCommand = new RelayCommand(SearchFlights);
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SortIdCommand = new RelayCommand(SortId);
            SortPlaneCommand = new RelayCommand(SortPlane);
            SortDepartureDateCommand = new RelayCommand(SortDepartureDate);
            SortPassengersCommand = new RelayCommand(SortPassengers);
            SortArrivalCityCommand = new RelayCommand(SortArrivalCity);
            LogoutCommand = new RelayCommand(Logout);
            SearchFlightPreviousDateCommand = new RelayCommand(SearchFlightPreviousDate);
            SearchFlightNextDateCommand = new RelayCommand(SearchFlightNextDate);
            SetupTodayFlightsCommand = new RelayCommand(SetupTodayFlights);
            Items = new ObservableCollection<UserFlightsItemViewModel>();
            string filePath = "C:/Users/Public/Documents/data.json";
            LoadData(filePath);
            CurrentDate = DateTime.Now;
            SetupTodayFlights();
        }
        public void SortId() => FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Id));
        public void SortPlane() => FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Plane));
        public void SortDepartureDate() => FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.DepartureDateTime));
        public void SortArrivalCity() => FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.ArrivalCity));
        public void SortPassengers() => FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Passengers));
        public void SearchFlights()
        {
            if (mLastSearchText == SearchText)
                return;
            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count() <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Enumerable.Empty<UserFlightsItemViewModel>());
                // Set last search text
                mLastSearchText = SearchText;
                return;
            }
            if (DateTime.TryParse(SearchText, out _))
            {
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(
                    Items.Where(item => item.DepartureDateTime.ToString().Contains(SearchText)&& item.DepartureDateTime.Date.Equals(CurrentDate.Date)));
                // Set last search text
                mLastSearchText = SearchText;
                return;
            }
            if(Items.Any(item => item.Id.Contains(SearchText) && item.DepartureDateTime.Date.Equals(CurrentDate.Date)))
            {
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(
                    Items.Where(item => item.Id.Contains(SearchText) && item.DepartureDateTime.Date.Equals(CurrentDate.Date)));
                // Set last search text
                mLastSearchText = SearchText;
                return;
            }
            if(Items.Any(item => item.Plane.Contains(SearchText) && item.DepartureDateTime.Date.Equals(CurrentDate.Date)))
            {
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(
                    Items.Where(item => item.Plane.Contains(SearchText) && item.DepartureDateTime.Date.Equals(CurrentDate.Date)));
                // Set last search text
                mLastSearchText = SearchText;
                return;
            }
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Enumerable.Empty<UserFlightsItemViewModel>());
        }
        public void SearchFlightPreviousDate()
        {
            // If we have no search date, or no items
            if ( Items == null || Items.Count() <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items ?? Enumerable.Empty<UserFlightsItemViewModel>());
                return;
            }
            // Find all items that contain the chosen Date
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item => item.DepartureDateTime.Date.Equals(PreviousDate.Date)));
            CurrentDate = CurrentDate - TimeSpan.FromDays(1);
            ClearSearch();
        }
        public void SetupTodayFlights()
        {
            // If we have no search date, or no items
            if (Items == null || Items.Count() <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items ?? Enumerable.Empty<UserFlightsItemViewModel>());
                return;
            }
            // Find all items that contain the chosen Date
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item => item.DepartureDateTime.Date.Equals(CurrentDate.Date)));
        }
        public void SearchFlightNextDate()
        {
            // If we have no search date, or no items
            if (Items == null || Items.Count() <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items ?? Enumerable.Empty<UserFlightsItemViewModel>());
                return;
            }
            // Find all items that contain the chosen Date
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item => item.DepartureDateTime.Date.Equals(NextDate.Date)));
            CurrentDate += TimeSpan.FromDays(1);
            ClearSearch();
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
            SetupTodayFlights();
        }
        public void Logout() => IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminLogin);
        #region Private Helpers
        private void LoadData(string path)
        {
            if (File.Exists(path))
            {
                Items = JsonConvert.DeserializeObject<ObservableCollection<UserFlightsItemViewModel>>(File.ReadAllText(path));
                Items = new ObservableCollection<UserFlightsItemViewModel>(Items.OrderBy(o => o.Id));
            }
        }
        #endregion
    }
}
