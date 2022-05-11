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
    public class IdToDisplayConverter : BaseValueConverter<IdToDisplayConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (string)value;
                return "ID самолета: " + id;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
