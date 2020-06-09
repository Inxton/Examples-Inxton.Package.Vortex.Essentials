using HansPlc;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxDB.LineProtocol.Client;
using InfluxDB.LineProtocol.Payload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vortex.Connector;
using Vortex.Connector.ValueTypes;

namespace InfluxDB.Wpf.Influx
{
    public class Gatherer : INotifyPropertyChanged
    {
        public Gatherer(InfluxDbClient client, string databaseName)
        {
            Client = client;
            DatabaseName = databaseName;
            this.Register();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly string DatabaseName;
        private readonly InfluxDbClient Client;    
        private readonly fbInfluxPerformanceLogging influx = HansPlc.Entry.HansPlc.prgInflux._influx;    

        private void Register()
        {                                          
            // Subscribe for the change of the '_logStart' variable
            influx._logStart.Subscribe((sender, a) =>
            {
                SavePoint();
            });
        }

        private void SavePoint()
        {
            // Let's retrieve all value items from the our 'influx._data' twin.
            var primitives = influx._data.GetValueTags();

            if (influx._logStart.Synchron > influx._logDone.Synchron)
            {
                try
                {
                    // Reads the data structure;
                    influx._data.Read();

                    // Create fresh instance for payload
                    var point = new InfluxData.Net.InfluxDb.Models.Point()
                    {
                        Name = "plc-perf",
                    };


                    // Create point 
                    /* Here we iterate over all primitives (base type) of the twin object
                     * and add them to the field dictionay where the key is the attribute name of the
                     * primitive variable and value is the 'LastValue' read above using extension
                     * method 'Read'. 
                     */
                    foreach (var primitive in primitives)
                    {
                        point.Fields[primitive.AttributeName] = ((dynamic)primitive).LastValue;
                    }

                    // Write payload
                    Client.Client.WriteAsync(point, dbName: DatabaseName).Wait();

                    NumberOfRecords++;

                    influx._data.Maximum.Synchron = 0;
                    influx._data.Minimum.Synchron = OnlinerUDInt.MaxValue;

                    // Tell the plc that the operation is done
                    influx._logDone.Synchron = influx._logStart.Synchron;              
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Oooops, something is wrong; here's what: {ex.ToString()}", "Oooooops, that's painful", MessageBoxButton.OK);
                    App.Current.Shutdown();
                }
            }
        }
    
        int numberOfRecords;
        public int NumberOfRecords
        {
            get => numberOfRecords;
            set
            {
                if (numberOfRecords == value)
                {
                    return;
                }

                numberOfRecords = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfRecords)));
            }
        }
    }
}
