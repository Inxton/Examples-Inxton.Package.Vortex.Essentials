using HansPlc;
using MongoDB.Driver;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vortex.Presentation.Wpf;

namespace MongoDB.Wpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {       
        public MainWindowViewModel()
        {
            PLC = Entry.HansPlc;

            From = DateTime.Now;
            To = DateTime.Now.AddMinutes(1);

            this.RetrieveDataCommand = new RelayCommand(a => RetrieveData());            
        }

        private void RetrieveData()
        {
            Mongo.Retriever.RetrieveData(Builders<PlainstructMongoData>.Filter.Where(p => p.TimeStamp >= this.From && p.TimeStamp <= this.To));
            LastValuePoints = Mongo.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.LastExecTime)).ToList();
            MaxValuesPoints = Mongo.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.Maximum)).ToList();
            MinValuesPoints = Mongo.Retriever.Series.Select(p => new DataPoint(p.CycleCount, p.Minimum)).ToList();
        }

        public PlcPerformanceData Mongo { get; } = new PlcPerformanceData();

        public HansPlcTwinController PLC { get; }

        public RelayCommand RetrieveDataCommand { get; }

        DateTime _from;
        public DateTime From
        {
            get => _from;
            set
            {
                if (_from == value)
                {
                    return;
                }

                _from = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(From)));
            }
        }

        DateTime _to;
        public DateTime To
        {
            get => _to;
            set
            {
                if (_to == value)
                {
                    return;
                }

                _to = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(To)));
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
