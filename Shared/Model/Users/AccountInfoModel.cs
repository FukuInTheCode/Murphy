using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Model.Users;

[BsonIgnoreExtraElements]
public class AccountInfoModel : BaseModel
{
    public string Username { get; set; } = "";

    public string Password { get; set; } = "";

    [BsonIgnore]
    public string JwtToken { get; set; } = "";
}