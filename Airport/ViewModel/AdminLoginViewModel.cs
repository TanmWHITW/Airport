using Airport.NET;
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
        public ICommand UserLoginCommand { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public AdminLoginViewModel()
        {
            // Create commands
            AdminLoginCommand = new RelayCommand(async () => await AdminLoginAsync());
            UserLoginCommand = new RelayCommand(async () => await UserLoginAsync());
        }
        #endregion
        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <returns></returns>
        public async Task AdminLoginAsync()
        {
            await RunCommand(() => AdminLoginIsRunning, async () =>
            {
                var username = Username;
                var key = Key;
                await Task.Delay(1000);
                if (username != "admin" || key != "111")
                {
                    MessageBox.Show("Введен неверный логин или ключ доступа", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AdminFlights);
            });
        }
        public async Task UserLoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.UserFlights);
            await Task.Delay(1);
        }
    }
}