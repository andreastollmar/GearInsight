using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace testWoW.Database
{
    internal class Mongo
    {
        public static async Task 

        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Jesper:hejjesper@cluster0.wbk5q6r.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("TheMovieDb");
        var myCollection = database.GetCollection<Models.Movie>("MyMovieCollection");
    }
}
