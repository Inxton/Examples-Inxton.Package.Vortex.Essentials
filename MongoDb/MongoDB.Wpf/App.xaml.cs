using HansPlc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MongoDB.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            Entry.HansPlc.Connector.ReadWriteCycleDelay = 100;
            Entry.HansPlc.Connector.BuildAndStart();
        }
    }
}
