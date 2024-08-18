using MongoDB.Bson.Serialization.Attributes;
using Shared.Constantes.Account;

namespace Shared.Model.Users;

[BsonIgnoreExtraElements]
public class AccountInfoModel : BaseModel
{
    public string Username { get; set; } = "";

    public string Password { get; set; } = "";

    public string Role { get; set; } = RoleConstantes.VisitorRole; 
    
    #region Ignored
    
    [BsonIgnore]
    public string JwtToken { get; set; } = "";
    

    #endregion
}