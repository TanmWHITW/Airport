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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserLoginViewModel()
        {
            // Create commands
            UserLoginCommand = new RelayCommand(async () => await UserLogin());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task UserLogin()
        {
            await RunCommand(() => this.UserLoginIsRunning, async () =>
            {
                await Task.Delay(5000);

            });
        }
    }
}