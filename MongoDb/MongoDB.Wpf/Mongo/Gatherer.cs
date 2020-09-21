using HansPlc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vortex.Connector;
using Vortex.Connector.ValueTypes;

namespace MongoDB.Wpf
{
    public class Gatherer : INotifyPropertyChanged
    {
        public Gatherer(IMongoCollection<PlainstructMongoData> collection)
        {
            Collection = collection;         
            this.Register();
        }

        public event PropertyChangedEventHandler PropertyChanged;
      
        private readonly IMongoCollection<PlainstructMongoData> Collection;    
        private readonly prgMongoDb mongo = HansPlc.Entry.HansPlc.prgMongoDb;    

        private void Register()
        {
            // Subscribe for the change of the '_logStart' variable
            mongo._logStart.Subscribe((sender, a) =>
            {
                SavePoint();
            });
        }

        private void SavePoint()
        {
            // Let's retrieve all value items from the our 'influx._data' twin.
            var primitives = mongo._data.GetValueTags();

            if (mongo._logStart.Synchron > mongo._logDone.Synchron)
            {
                try
                {
                    var plain = mongo._data.CreatePlainerType();
                    mongo._data.FlushOnlineToPlain(plain);

                    plain.id = ObjectId.GenerateNewId();
                    plain.TimeStamp = DateTime.Now;

                    Collection.InsertOne(plain);

                    NumberOfRecords++;

                    mongo._data.Maximum.Synchron = 0;
                    mongo._data.Minimum.Synchron = OnlinerUDInt.MaxValue;

                    // Tell the plc that the operation is done
                    mongo._logDone.Synchron = mongo._logStart.Synchron;              
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
