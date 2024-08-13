using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Server.DataAccess.Base;
using Shared.Model.Users;

namespace Server.DataAccess;

public class AccountMongoAccess : MongoAccessLayer
{
    private const string Database = "Account";

    private const string CollectionUsesInfos = "AccountInfo";

    public async Task<List<AccountInfoModel>> GetUsers() =>
        await GetCollection<AccountInfoModel>(Database, CollectionUsesInfos).Find(x => true).ToListAsync();

    public async Task<AccountInfoModel?> GetUserByAuthInfo(string username)
    {
        var filter = Builders<AccountInfoModel>.Filter.Eq(x => x.Username, username);
        var projection = Builders<AccountInfoModel>.Projection.Exclude(x => x.Password);
        return await GetCollection<AccountInfoModel>(Database, CollectionUsesInfos).Find(filter).Project<AccountInfoModel>(projection).FirstOrDefaultAsync();
    }

    public async Task CreateUser(AccountInfoModel accountInfo) => await GetCollection<AccountInfoModel>(Database, CollectionUsesInfos).InsertOneAsync(accountInfo);

    public async Task<string> GetUserHashedPwdById(string id) =>
        await GetCollection<AccountInfoModel>(Database, CollectionUsesInfos).Find(x => id == x.Id).Project(x => x.Password).FirstOrDefaultAsync();
}