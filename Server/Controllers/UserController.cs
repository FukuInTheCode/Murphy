using Microsoft.AspNetCore.Mvc;
using Server.DataAccess;
using Shared.Model.Users;

namespace Server.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly UserMongoAccess _userMongoAccess = new();
    
    #region Get

    [HttpGet]
    [Route("GetUsers/")]
    public async Task<List<UserModel>> GetUsers() => await _userMongoAccess.GetUsers();

    #endregion

}