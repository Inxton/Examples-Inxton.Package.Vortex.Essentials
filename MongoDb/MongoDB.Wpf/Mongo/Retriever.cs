using HansPlc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MongoDB.Wpf
{
    public class Retriever : INotifyPropertyChanged
    {        
        public Retriever(IMongoCollection<PlainstructMongoData> collection)
        {
            Collection = collection;           
        }

        private readonly IMongoCollection<PlainstructMongoData> Collection;

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RetrieveData(FilterDefinition<PlainstructMongoData> filter = null)
        {
            filter = filter == null ? Builders<PlainstructMongoData>.Filter.Where(p => true) : filter;
            
            try
            {
                Series = Collection.Find(filter).ToList();

                this.Average = Series.Average(p => p.LastExecTime);
                this.Max = Series.Max(p => p.LastExecTime);
                this.Min = Series.Min(p => p.LastExecTime);
                this.Median = Series.OrderBy(p => p.LastExecTime)
                                    .Skip((Series.Count() % 2 == 0) ? ((Series.Count() - 1) / 2) : (Series.Count() / 2))
                                    .FirstOrDefault()?.LastExecTime;

            }
            catch (Exception)
            {
                // Ignore
            }                  
        }
        
        
        IEnumerable<PlainstructMongoData> series;
        public IEnumerable<PlainstructMongoData> Series
        {
            get => series;
            set
            {
                if (series == value)
                {
                    return;
                }

                series = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Series)));
            }
        }

        double average;
        public double Average
        {
            get => average; set
            {
                if (average == value)
                {
                    return;
                }

                average = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Average)));
            }
        }

        uint max;
        public uint Max
        {
            get => max; set
            {
                if (max == value)
                {
                    return;
                }

                max = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Max)));
            }
        }

        uint min;
        public uint Min
        {
            get => min; set
            {
                if (min == value)
                {
                    return;
                }

                min = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Min)));
            }
        }

        uint? median;
        public uint? Median
        {
            get => median; set
            {
                if (median == value)
                {
                    return;
                }

                median = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Median)));
            }
        }
    }
}
