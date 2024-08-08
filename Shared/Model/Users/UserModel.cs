using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Model.Users;

[BsonIgnoreExtraElements]
public class UserModel : BaseModel
{
    public string Username { get; set; } = "";
}