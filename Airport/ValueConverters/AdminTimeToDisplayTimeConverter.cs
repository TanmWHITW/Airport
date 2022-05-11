using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    /// <summary>
    /// A converter that takes in date and converts it to a user friendly time
    /// </summary>
    public class AdminTimeToDisplayTimeConverter : BaseValueConverter<AdminTimeToDisplayTimeConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTime)value;
            if (parameter == null)
                return time.ToString("dd.MM.yyyy HH:mm");
            else
                return time.ToString("dd.MM.yyyy HH:mm (Местное время)");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
