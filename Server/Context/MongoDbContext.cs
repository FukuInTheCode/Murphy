using System.Runtime.InteropServices.JavaScript;
using MongoDB.Driver;

namespace Server.Context;

public class MongoDbContext
{
    private static MongoClient? _client;
    private static readonly object Lock = new();

    public MongoDbContext()
    {
        if (_client != null) return;
        lock (Lock)
        {
            if (_client != null) return;
            _client = new MongoClient(Program.Configuration.GetConnectionString("MongoDB"));
        }
    }

    public IMongoDatabase GetDatabase(string database) => _client!.GetDatabase(database);
}