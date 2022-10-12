using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ClientApi.Services.DataModels;

public class Categories
{

    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [BsonElement("createdAt")]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [BsonElement("__v")]
    [JsonPropertyName("__v")]
    public int Version { get; set; }
}
