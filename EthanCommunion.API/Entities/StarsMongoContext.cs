using EthanCommunion.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EthanCommunion.API.Entities
{
    public class StarsMongoContext : IStarsContext
    {
        public IMongoDatabase Database;

        public StarsMongoContext()
        {
            //var mongoClient = new MongoClient("mongodb://127.0.0.1");

            //string connectionString =
            //        @"mongodb://ethancommunionmongo:s1W0c1XuzdknDxwVbBjQgOj08WHKfaGYVYZD2WH0Gy8Llh23P1TUCZ8b3pF9saNfWCdeS0wM0N1JxKq7U9fTlg==@ethancommunionmongo.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            //MongoClientSettings settings = MongoClientSettings.FromUrl(
            //  new MongoUrl(connectionString)
            //);
            //settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            //var mongoClient = new MongoClient(settings);

            //var r = client.ListDatabases();

            //var Database = mongoClient.GetDatabase("ethancommunion");
        }

        public void SetContext()
        {
            
        }

        public IMongoCollection<StarDto> Stars
        {
            get
            {
                var mongoClient = new MongoClient("mongodb://127.0.0.1");
                var Database = mongoClient.GetDatabase("ethancommunion");
                return Database.GetCollection<StarDto>("Stars");
            }
        }
    }
}
