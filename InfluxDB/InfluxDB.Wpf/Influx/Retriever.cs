using HansPlc;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace InfluxDB.Wpf.Influx
{
    public class Retriever : INotifyPropertyChanged
    {        
        public Retriever(InfluxDbClient client, string databaseName)
        {
            Client = client;
            DatabaseName = databaseName;
        }

        private readonly IInfluxDbClient Client;
        private readonly string DatabaseName;

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RetrieveData(string query = "select * from /./ where time > now() - 1m")
        {
            try
            {
                var result = Client.Client.QueryAsync(query, dbName: DatabaseName).Result.Where(p => p.Name == "plc-perf").FirstOrDefault();
                var values = result?.Values;
                var columns = result?.Columns;

                if (values == null)
                {
                    return;
                }

                var retVal = new List<PlainInfluxData>();

                foreach (var vals in result.Values)
                {
                    var n = new PlainInfluxData();

                    for (int i = 0; i < columns.Count; i++)
                    {
                        var propInfo = n.GetType().GetProperties().Where(p => p.Name == columns[i]).FirstOrDefault();

                        propInfo.SetValue(n, Convert(propInfo.PropertyType, vals[i]));
                    }

                    retVal.Add(n);
                }

                this.Average = retVal.Average(p => p.LastExecTime);
                this.Max = retVal.Max(p => p.LastExecTime);
                this.Min = retVal.Min(p => p.LastExecTime);
                this.Median = retVal.OrderBy(p => p.LastExecTime)
                                    .Skip((retVal.Count % 2 == 0) ? ((retVal.Count - 1) / 2) : (retVal.Count / 2))
                                    .FirstOrDefault()?.LastExecTime;
                Series = retVal;
            }
            catch (Exception)
            {
                // Ignore
            }                  
        }
        
        public object Convert(Type toType, object value)
        {
            switch (value)
            {
                case Int64 c when toType == typeof(UInt32):
                    return UInt32.Parse(value.ToString());               
                default:
                    return value;
            }
        }

        IEnumerable<PlainInfluxData> series;
        public IEnumerable<PlainInfluxData> Series
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
