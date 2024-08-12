using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Server.DataAccess;
using Shared.Helpers.User;
using Shared.Model.Users;

namespace Server.Controllers;

[Controller]
[Route("api/[controller]")]
public class AccountController : BaseController
{
    private readonly AccountMongoAccess _accountMongoAccess = new();
    
    #region Get

    [HttpGet]
    [Route("GetUsers")]
    public async Task<List<AccountInfoModel>> GetUsers() => await _accountMongoAccess.GetUsers();

    #endregion

    #region Post

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] AccountInfoModel accountInfo)
    {
        var targetUser = await _accountMongoAccess.GetUserByAuthInfo(accountInfo.Username);
        if (targetUser == null)
            return BadRequest(accountInfo);
        var userPwd = await _accountMongoAccess.GetUserHashedPwdById(targetUser.Id);
        if (!AccountHelper.VerifyPassword(accountInfo.Password, userPwd))
            return BadRequest(accountInfo);
        return Ok(targetUser);
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] AccountInfoModel accountInfo)
    {
        var targetUser = await _accountMongoAccess.GetUserByAuthInfo(accountInfo.Username);
        if (targetUser != null) return Conflict(accountInfo);
        accountInfo.Password = AccountHelper.EncryptPassword(accountInfo.Password);
        await _accountMongoAccess.CreateUser(accountInfo);
        accountInfo.Password = string.Empty;
        return Created(accountInfo);
    }

    #endregion

}