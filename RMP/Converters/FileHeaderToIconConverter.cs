using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RMP.Converters
{
    /// <summary>
    /// This is a XAML converter that basically reads a path name/header and based on that 
    /// it adds a Drive or a Folder icon.
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool))]
    public class FileHeaderToIconConverter : IValueConverter
    {
        public static FileHeaderToIconConverter Instance = new FileHeaderToIconConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as string).Contains(@"\"))
            {
                Uri uri = new Uri("pack://application:,,,/RMP;component/Resources/iconHdd.png");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
            else
            {
                Uri uri = new Uri("pack://application:,,,/RMP;component/Resources/iconFolder.png");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
