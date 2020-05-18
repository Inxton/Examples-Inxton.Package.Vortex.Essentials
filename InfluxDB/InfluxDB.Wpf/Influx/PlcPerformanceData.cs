using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDB.Wpf.Influx
{
    public class PlcPerformanceData
    {
        const string ServerUrl = "http://localhost:8086/";
        const string DatabaseName = "ws";

        public PlcPerformanceData()
        {
            Client = new InfluxDbClient(ServerUrl,
                                     string.Empty,
                                     string.Empty,
                                     InfluxDbVersion.Latest,
                                     QueryLocation.FormData);

            ReCreate_DropCreate_Database();

            this.Retriever = new Retriever(Client, DatabaseName);
            this.Gatherer = new Gatherer(Client, DatabaseName);
        }

        private readonly InfluxDbClient Client;

        public Gatherer Gatherer { get; }
        public Retriever Retriever { get; }

        private void ReCreate_DropCreate_Database()
        {
            if (Client.Database.GetDatabasesAsync().Result.Where(p => p.Name == "ws").Count() == 0)
            {
                Client.Database.CreateDatabaseAsync("ws").Wait();
            }
            else
            {
                Client.Database.DropDatabaseAsync("ws").Wait();
                Client.Database.CreateDatabaseAsync("ws").Wait();
            }
        }
    }
}
