using MongoDB.Driver;
using Server.DataAccess.Base;
using Shared.Model.Users;

namespace Server.DataAccess;

public class UserMongoAccess : MongoAccessLayer
{
    private const string Database = "Users";

    private const string CollectionUsesInfos = "UserInfos";

    public async Task<List<UserModel>> GetUsers() =>
        await GetCollection<UserModel>(Database, CollectionUsesInfos).Find(x => true).ToListAsync();
}