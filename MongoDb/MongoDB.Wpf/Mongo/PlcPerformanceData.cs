using HansPlc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Wpf
{
    public class PlcPerformanceData
    {
        const string mongoDbConnectionString = "mongodb://localhost:27017";
        const string dataBaseName = "HansPlcDatabase";
        const string collectionName = "HansCollection";

        public PlcPerformanceData()
        {           
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
            Client = database.GetCollection<PlainstructMongoData>(collectionName);



            this.Retriever = new Retriever(Client);
            this.Gatherer = new Gatherer(Client);
        }

        private readonly IMongoCollection<PlainstructMongoData> Client;

        public Gatherer Gatherer { get; }
        public Retriever Retriever { get; }       
    }
}
