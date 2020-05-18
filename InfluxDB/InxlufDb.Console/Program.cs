using HansPlc;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortex.Connector;

namespace Influx.Console
{
    class Program
    {
        const string ServerUrl = "http://localhost:8086/";
        const string DatabaseName = "ws";

        private static fbInfluxPerformanceLogging influx_data_controller = Entry.HansPlc.prgInflux._influx;
        private static int record_since_app_start;
        private static (int top, int left) consoleCursorPosition;
        private static IEnumerable<IValueTag> primitives;

        private static void Register(IInfluxDbClient client)
        {
            record_since_app_start = 0;

            // Let's retrieve all value items from the our 'influx._data' twin.
            primitives = influx_data_controller._data.GetValueTags();

            System.Console.WriteLine("\n-------------------------------------------------------------------");
            consoleCursorPosition = (top: System.Console.CursorTop, left: System.Console.CursorLeft);
            System.Console.WriteLine("\n-------------------------------------------------------------------");

            // Subscribe for the change of the '_logStart' variable
            influx_data_controller._logStart.Subscribe((sender, a) =>
            {              
                SavePoint(client);
            });
        }

        private static void SavePoint(IInfluxDbClient client)
        {                       
            if (influx_data_controller._logStart.Synchron > influx_data_controller._logDone.Synchron)
            {
                try
                {
                    // Reads the data structure;
                    influx_data_controller._data.Read();

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
                    client.Client.WriteAsync(point, dbName: DatabaseName).Wait();

                    System.Console.SetCursorPosition(consoleCursorPosition.left, consoleCursorPosition.top);
                    System.Console.WriteLine($"Records since app started: {++record_since_app_start}");

                    // Tell the plc that the operation is done
                    influx_data_controller._logDone.Synchron = influx_data_controller._logStart.Synchron;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Oooops, something is wrong; here's what: {ex.ToString()}");                    
                }
            }
        }

        static void Main(string[] args)
        {
           
            // Start the operation on the plc twin
            HansPlc.Entry.HansPlc.Connector.ReadWriteCycleDelay = 0;
            HansPlc.Entry.HansPlc.Connector.BuildAndStart();

            var client = new InfluxDbClient(ServerUrl,
                                       string.Empty,
                                       string.Empty,
                                       InfluxDbVersion.Latest,
                                       QueryLocation.FormData);

            // Recreate database
            ReCreate_DropCreate_Database(client);

            // Register for writing to InfluxDb
            Register(client);


            System.Console.Read();
        }

        private static void ReCreate_DropCreate_Database(IInfluxDbClient client)
        {
            if (client.Database.GetDatabasesAsync().Result.Where(p => p.Name == DatabaseName).Count() == 0)
            {
                client.Database.CreateDatabaseAsync(DatabaseName).Wait();
            }
            else
            {
                client.Database.DropDatabaseAsync(DatabaseName).Wait();
                client.Database.CreateDatabaseAsync(DatabaseName).Wait();
            }
        }
    }
}
