using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Model.Users;
using Shared.Response;

namespace Client.Repository.Interface;

public interface IAccountRepository
{
    public Task<List<AccountInfoModel>> GetUsers();

    public Task<BaseResponse<AccountInfoModel>> Login(string username, string password);
    
    public Task<BaseResponse<AccountInfoModel>> Register(string username, string password);
}