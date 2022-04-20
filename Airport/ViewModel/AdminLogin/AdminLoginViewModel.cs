using System.Threading.Tasks;
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
    public class AdminLoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The Key of the user
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool AdminLoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand AdminLoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminLoginViewModel()
        {
            // Create commands
            AdminLoginCommand = new RelayCommand(async () => await AdminLogin());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task AdminLogin()
        {
            await RunCommand(() => AdminLoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var username = this.Username;
                var key = this.Key;
            });
        }
    }
}