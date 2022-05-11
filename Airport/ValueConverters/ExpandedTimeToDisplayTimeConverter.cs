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
    public class ExpandedTimeToDisplayTimeConverter : BaseValueConverter<ExpandedTimeToDisplayTimeConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTime)value;
                return time.ToString("dd MMM HH:mm");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
