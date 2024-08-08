using Shared.Model.Users;

namespace Client.Repository.Interface;

public interface IUsersRepository
{
    public Task<List<UserModel>> GetUsers();
}