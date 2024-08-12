using Client.Repository.Interface;
using Shared.Model.Users;
using Shared.Response;

namespace Client.Repository;

public class AccountRepository(HttpClient client) : BaseRepository(client), IAccountRepository
{
    private static readonly string Url = "api/Account/";

    private static readonly string UrlGetUsers = Url + "GetUsers";
    
    private static readonly string UrlLogin = Url + "Login";

    private static readonly string UrlRegister = Url + "Register";

    public async Task<List<AccountInfoModel>> GetUsers() => GetContent(await Get<List<AccountInfoModel>>(UrlGetUsers));

    public async Task<BaseResponse<AccountInfoModel>> Login(string username, string password) =>
        await Post(UrlLogin, new AccountInfoModel
        {
            Username = username,
            Password = password
        });

    public async Task<BaseResponse<AccountInfoModel>> Register(string username, string password) =>
        await Post(UrlRegister, new AccountInfoModel
        {
            Username = username, 
            Password = password
        });
}