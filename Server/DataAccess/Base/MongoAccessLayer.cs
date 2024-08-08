using MongoDB.Driver;
using Server.Context;

namespace Server.DataAccess.Base;

public class MongoAccessLayer
{
    private readonly MongoDbContext _client = new MongoDbContext();

    #region Utils

    public IMongoCollection<TModel> GetCollection<TModel>(string database, string collection) =>
        _client.GetDatabase(database).GetCollection<TModel>(collection);

    #endregion
}