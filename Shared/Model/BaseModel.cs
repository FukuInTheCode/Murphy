using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Model;

[BsonIgnoreExtraElements]
public class BaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public string Id { get; set; } = null!;
}