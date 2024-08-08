using Client.Repository.Interface;
using Shared.Model.Users;

namespace Client.Repository;

public class UserRepository(HttpClient client) : BaseRepository(client), IUsersRepository
{
    private static readonly string Url = "api/User/";

    private static readonly string UrlGetUsers = Url + "GetUsers";

    public async Task<List<UserModel>> GetUsers() => await Get<List<UserModel>>(UrlGetUsers);
}