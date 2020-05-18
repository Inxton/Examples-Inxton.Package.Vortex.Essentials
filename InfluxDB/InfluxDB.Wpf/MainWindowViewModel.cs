using HansPlc;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vortex.Presentation.Wpf;

namespace InfluxDB.Wpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {       
        public MainWindowViewModel()
        {
            PLC = Entry.HansPlc;

            InfluxQuery = "select * from /./ where time > now() - 1m";

            this.RetrieveDataCommand = new RelayCommand(a => RetrieveData());            
        }

        private void RetrieveData()
        {
            Influx.Retriever.RetrieveData(string.IsNullOrEmpty(InfluxQuery) ? "select * from /./" : InfluxQuery);      
            Points?.Clear();
            Points = Influx.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.LastExecTime)).ToList();
        }

        public Influx.PlcPerformanceData Influx { get; } = new Influx.PlcPerformanceData();

        public HansPlcTwinController PLC { get; }

        public RelayCommand RetrieveDataCommand { get; }

        string influxQuery;
        public string InfluxQuery
        {
            get => influxQuery;
            set
            {
                if (influxQuery == value)
                {
                    return;
                }

                influxQuery = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InfluxQuery)));
            }
        }

        IList<DataPoint> points;
        public IList<DataPoint> Points
        {
            get => points; private set
            {
                if (points == value)
                {
                    return;
                }

                points = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Points)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
