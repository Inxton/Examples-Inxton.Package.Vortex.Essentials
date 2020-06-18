using HansPlc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Console
{
    class Program
    {
        const string mongoDbConnectionString = "mongodb://localhost:27017";
        const string dataBaseName = "HansPlcDatabase";
        const string collectionName = "HansCollection";

        static void Main(string[] args)
        {
            HansPlc.Entry.HansPlc.Connector.ReadWriteCycleDelay = 0;
            HansPlc.Entry.HansPlc.Connector.BuildAndStart();

            #region Mapping and serialisation settings
            var bsonMap = new BsonClassMap(typeof(PlainstructMongoData));
            bsonMap.AutoMap();
            bsonMap.SetIgnoreExtraElements(true);
            bsonMap.MapIdProperty("id");
            BsonClassMap.RegisterClassMap(bsonMap);

            BsonSerializer.RegisterSerializer(typeof(UInt64), new UInt64Serializer(BsonType.Int64, new RepresentationConverter(true, false)));
            BsonSerializer.RegisterSerializer(typeof(UInt32), new UInt32Serializer(BsonType.Int32, new RepresentationConverter(true, false)));
            BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);
            #endregion

            var client = new MongoDB.Driver.MongoClient(mongoDbConnectionString);
            var database = client.GetDatabase(dataBaseName);
            database.DropCollection(collectionName);
            var collection = database.GetCollection<PlainstructMongoData>(collectionName);
            var mongo = HansPlc.Entry.HansPlc.prgMongoDb;

            #region Reporting frame setup
            System.Console.WriteLine("\n-------------------------------------------------------------------");
            (int top, int left) consoleCursorPosition = (top: System.Console.CursorTop, left: System.Console.CursorLeft);
            System.Console.WriteLine("\n-------------------------------------------------------------------");
            #endregion

            var record_since_app_start = 0;

            mongo._logStart.Subscribe((sender, arguments) => 
            {
                if(mongo._logStart.Synchron > mongo._logDone.Synchron)
                { 
                    var plain = mongo._data.CreatePlainerType();
                    mongo._data.FlushOnlineToPlain(plain);
                    plain.id = ObjectId.GenerateNewId();
                    plain.TimeStamp = DateTime.Now;

                    collection.InsertOne(plain);

                    System.Console.SetCursorPosition(consoleCursorPosition.left, consoleCursorPosition.top);
                    System.Console.WriteLine($"Records since app started: {++record_since_app_start}");

                    mongo._logDone.Synchron = mongo._logStart.Synchron;
                }
            });
            
            System.Console.Read();
        }
    }
}
