using Shared.Model.Users;

namespace Client.Repository.Interface;

public interface IUsersRepository
{
    public Task<List<UserModel>> GetUsers();

    public Task<UserModel> Login(string username, string password);
    
    public Task<UserModel> Register(string username, string password);
}