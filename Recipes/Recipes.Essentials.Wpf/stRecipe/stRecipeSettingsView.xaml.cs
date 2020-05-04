using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HansPlc
{
    /// <summary>
    /// Interaction logic for stReciepeView.xaml
    /// </summary>
    public partial class stRecipeSettingsView : UserControl
    {
        public stRecipeSettingsView()
        {
            InitializeComponent();
        }

        public stRecipeSettingsViewModel _context { get => this.DataContext as stRecipeSettingsViewModel; }              
    }

    public class BooleanToVisibilityInvertedConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            }
            catch (Exception)
            {
                //++ Ignore
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
