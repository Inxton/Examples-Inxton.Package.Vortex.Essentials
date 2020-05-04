using HansPlc;
using System.Windows;

namespace Weather.Essentials.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationStatusUpdater.Get.WriteWeatherStationData();
        }
    }

    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Entry.HansPlc.Connector.BuildAndStart();
            PLC = Entry.HansPlc;
        }
        public HansPlcTwinController PLC { get; }
    }
}
