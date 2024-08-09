using Client.Repository.Interface;
using Shared.Model.Users;

namespace Client.Repository;

public class UserRepository(HttpClient client) : BaseRepository(client), IUsersRepository
{
    private static readonly string Url = "api/User/";

    private static readonly string UrlGetUsers = Url + "GetUsers";
    
    private static readonly string UrlLogin = Url + "Login";

    private static readonly string UrlRegister = Url + "Register";

    public async Task<List<UserModel>> GetUsers() => await Get<List<UserModel>>(UrlGetUsers);

    public async Task<UserModel> Login(string username, string password) =>
        await Post(UrlLogin, new UserModel
        {
            Username = username,
            Password = password
        });

    public async Task<UserModel> Register(string username, string password) =>
        await Post(UrlRegister, new UserModel
        {
            Username = username, 
            Password = password
        });
}