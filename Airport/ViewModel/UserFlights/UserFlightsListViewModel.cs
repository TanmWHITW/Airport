﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.IO;
using Airport.NET;

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

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<UserFlightsItemViewModel> mItems;

        #endregion

        #region Public Properties

        public string TodayDay => DateTime.Now.ToString("dd", CultureInfo.InvariantCulture);

        public string TodayMonth => DateTime.Now.ToString("MM", CultureInfo.InvariantCulture);


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

        /// <summary>
        /// The day to search for when we do a date search search
        /// </summary>
        public string SearchDay
        {
            get => mSearchDay;
            set
            {
                // Check value is different
                if (mSearchDay == value)
                    return;

                // Update value
                mSearchDay = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchDay))
                    return;
            }
        }

        /// <summary>
        /// The month to search for when we do a date search search
        /// </summary>
        public string SearchMonth
        {
            get => mSearchMonth;
            set
            {
                // Check value is different
                if (mSearchMonth == value)
                    return;

                // Update value
                mSearchMonth = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchMonth))
                    return;
            }
        }

        #endregion

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchFlightIdCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }
        public ICommand SearchFlightDateCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand SortPlaneCommand { get; set; }
        public ICommand SortDepartureDateCommand { get; set; }
        public ICommand SortArrivalCityCommand { get; set; }
        public ICommand SortPassengersCommand { get; set; }



        public UserFlightsListViewModel()
        {
            // Create commands
            SearchFlightIdCommand = new RelayCommand(SearchFlightId);
            ClearSearchCommand = new RelayCommand(ClearSearch);
            SearchFlightDateCommand = new RelayCommand(SearchFlightDate);
            SortIdCommand = new RelayCommand(SortId);
            SortPlaneCommand = new RelayCommand(SortPlane);
            SortDepartureDateCommand = new RelayCommand(SortDepartureDate);
            SortPassengersCommand = new RelayCommand(SortPassengers);

            Items = new ObservableCollection<UserFlightsItemViewModel>();

            string filePath = "C:/Users/Public/Documents/data.json";

            LoadData(filePath);

            SetTodayFlights(TodayDay, TodayMonth);
        }

        public void SortId()
        {
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Id));
        }
        public void SortPlane()
        {
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Plane));
        }
        public void SortDepartureDate()
        {
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.DepartureDateTime));
        }
        public void SortPassengers()
        {
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(FilteredItems.OrderBy(o => o.Passengers));
        }


        public void SearchFlightId()
        {

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
                Items.Where(item => item.Id.Contains(SearchText) && (item.DepartureDateTime.Month.Equals(Int32.Parse(SearchMonth))) && (item.DepartureDateTime.Day.Equals(Int32.Parse(SearchDay)))));

            // Set last search text
            mLastSearchText = SearchText;
        }

        public void SearchFlightDate()
        {

            // If we have no search date, or no items
            if (string.IsNullOrEmpty(SearchDay) || string.IsNullOrEmpty(SearchMonth) || Items == null || Items.Count() <= 0)
            {

                // Make filtered list the same
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items ?? Enumerable.Empty<UserFlightsItemViewModel>());

                // Set last search day
                mLastSearchDay = SearchDay;

                // Set last search month
                mLastSearchMonth = SearchMonth;

                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item =>
                                                                                               item.DepartureDateTime.Month.Equals(Int32.Parse(TodayMonth))
                                                                                            && item.DepartureDateTime.Day.Equals(Int32.Parse(TodayDay))));
                return;
            }
            // Find all items that contain the chosen Date
            FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item =>
                                                                                               item.DepartureDateTime.Month.Equals(Int32.Parse(SearchMonth))
                                                                                            && item.DepartureDateTime.Day.Equals(Int32.Parse(SearchDay))));
            // Set last search day
            mLastSearchDay = SearchDay;

            // Set last search month
            mLastSearchMonth = SearchMonth;
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
            SearchFlightDate();
        }

        #region Private Helpers

        private void LoadData(string path)
        {
            if (File.Exists(path))
            {
                Items = JsonConvert.DeserializeObject<ObservableCollection<UserFlightsItemViewModel>>(File.ReadAllText(path));
                Items = new ObservableCollection<UserFlightsItemViewModel>(Items.OrderBy(o => o.Id));
            }
        }

        private void SetTodayFlights(string day, string month)
        {
            if ((!string.IsNullOrEmpty(day) || !string.IsNullOrEmpty(month)))
            {
                FilteredItems = new ObservableCollection<UserFlightsItemViewModel>(Items.Where(item =>
                                                                                               item.DepartureDateTime.Month.Equals(Int32.Parse(TodayMonth))
                                                                                            && item.DepartureDateTime.Day.Equals(Int32.Parse(TodayDay))));
            }
        }

        #endregion

    }
}
