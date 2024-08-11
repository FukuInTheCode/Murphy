using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Model.Users;
using Shared.Response;

namespace Client.Repository.Interface;

public interface IUsersRepository
{
    public Task<List<UserModel>> GetUsers();

    public Task<BaseResponse<UserModel>> Login(string username, string password);
    
    public Task<BaseResponse<UserModel>> Register(string username, string password);
}