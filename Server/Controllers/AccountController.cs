using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using Server.DataAccess;
using Shared.Helpers.Account;
using Shared.Model.Users;

namespace Server.Controllers;

[Controller]
[Route("api/[controller]")]
public class AccountController(IConfiguration configuration) : BaseController
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

    #region Utils

    public string GenerateJwt(AccountInfoModel accountInfo)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, accountInfo.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, "Admin")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    #endregion

}