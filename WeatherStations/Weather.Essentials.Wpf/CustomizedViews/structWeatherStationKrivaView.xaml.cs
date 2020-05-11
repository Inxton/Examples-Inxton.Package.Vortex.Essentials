using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HansPlc
{
    /// <summary>
    /// Interaction logic for structWeatherStationMapView.xaml
    /// </summary>
    public partial class structWeatherStationKrivaView : UserControl
    {
        public structWeatherStationKrivaView()
        {
            InitializeComponent();
            this.DataContextChanged += StructWeatherStationMapView_DataContextChanged;         
        }

        private void StructWeatherStationMapView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Map.Navigate(Context.AttributeOpenMap);
        }
        
        private structWeatherStation Context
        {
            get
            {
                return this.DataContext as structWeatherStation;                               
            }
        }
    }
}
