using Airport.NET;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Airport
{
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.UserLogin:
                    return new UserLoginPage();

                case ApplicationPage.AdminLogin:
                    return new AdminLoginPage();

                case ApplicationPage.UserFlights:
                    return new UserFlightsPage();

                case ApplicationPage.AdminFlights:
                    return new AdminFlightsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
