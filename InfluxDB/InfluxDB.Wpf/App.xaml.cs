using HansPlc;
using InfluxDB.LineProtocol.Client;
using InfluxDB.LineProtocol.Payload;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vortex.Connector;

namespace InfluxDB.Wpf
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
