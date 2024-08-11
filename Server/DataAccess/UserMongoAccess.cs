using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Server.DataAccess.Base;
using Shared.Helpers.User;
using Shared.Model.Users;

namespace Server.DataAccess;

public class UserMongoAccess : MongoAccessLayer
{
    private const string Database = "Users";

    private const string CollectionUsesInfos = "UserInfos";

    public async Task<List<UserModel>> GetUsers() =>
        await GetCollection<UserModel>(Database, CollectionUsesInfos).Find(x => true).ToListAsync();

    public async Task<UserModel?> GetUserByAuthInfo(string username)
    {
        var filter = Builders<UserModel>.Filter.Eq(x => x.Username, username);
        var projection = Builders<UserModel>.Projection.Exclude(x => x.Password);
        return await GetCollection<UserModel>(Database, CollectionUsesInfos).Find(filter).Project<UserModel>(projection).FirstOrDefaultAsync();
    }

    public async Task CreateUser(UserModel user) => await GetCollection<UserModel>(Database, CollectionUsesInfos).InsertOneAsync(user);

    public async Task<string> GetUserHashedPwdById(string id) =>
        await GetCollection<UserModel>(Database, CollectionUsesInfos).Find(x => id == x.Id).Project(x => x.Password).FirstOrDefaultAsync();
}