using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Server.DataAccess;
using Shared.Helpers.User;
using Shared.Model.Users;

namespace Server.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly UserMongoAccess _userMongoAccess = new();
    
    #region Get

    [HttpGet]
    [Route("GetUsers")]
    public async Task<List<UserModel>> GetUsers() => await _userMongoAccess.GetUsers();

    #endregion

    #region Post

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserModel user)
    {
        var targetUser = await _userMongoAccess.GetUserByAuthInfo(user.Username);
        return targetUser == null ? BadRequest(user) : StatusCode(200, targetUser);
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserModel user)
    {
        var targetUser = await _userMongoAccess.GetUserByAuthInfo(user.Username);
        if (targetUser != null) return Conflict(user);
        user.Password = UserHelper.EncryptPassword(user.Password);
        await _userMongoAccess.CreateUser(user);
        user.Password = string.Empty;
        return Created(user);
    }

    #endregion

}