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
            LastValuePoints = Influx.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.LastExecTime)).ToList();
            MaxValuesPoints = Influx.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.Maximum)).ToList();
            MinValuesPoints = Influx.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.Minimum)).ToList();
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

        IList<DataPoint> lastValuePoints;
        public IList<DataPoint> LastValuePoints
        {
            get => lastValuePoints; private set
            {
                if (lastValuePoints == value)
                {
                    return;
                }

                lastValuePoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastValuePoints)));
            }
        }

        IList<DataPoint> maxValuesPoints;
        public IList<DataPoint> MaxValuesPoints
        {
            get => maxValuesPoints;
            set
            {
                if (maxValuesPoints == value)
                {
                    return;
                }

                maxValuesPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxValuesPoints)));
            }
        }

        IList<DataPoint> minValuesPoints;
        public IList<DataPoint> MinValuesPoints
        {
            get => minValuesPoints;
            set
            {
                if (minValuesPoints == value)
                {
                    return;
                }

                minValuesPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinValuesPoints)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
