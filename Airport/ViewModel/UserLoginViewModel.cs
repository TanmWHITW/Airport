using Airport.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

/// <summary>
/// Can write test cases already
/// TO DO: not done!
/// </summary>

namespace Airport
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class UserLoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool UserLoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand UserLoginCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand AdminLoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserLoginViewModel()
        {
            // Create commands
            UserLoginCommand = new RelayCommand(async () => await UserLoginAsync());
            AdminLoginCommand = new RelayCommand(async () => await AdminLoginAsync());
        }


        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <returns></returns>
        public async Task UserLoginAsync()
        {
            await RunCommand(() => this.UserLoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.UserFlights);
            });
        }

        /// <summary>
        /// Move to Admin Login Page
        /// </summary>
        public async Task AdminLoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminLogin);

            await Task.Delay(1);
        }
    }
}