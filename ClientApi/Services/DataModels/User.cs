using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ClientApi.Services.DataModels;

public class User
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [BsonElement("profilepic")]
    [JsonPropertyName("profilepic")]
    public string? Profilepic { get; set; }

    [BsonElement("createdAt")]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [BsonElement("__v")]
    [JsonPropertyName("__v")]
    public int Version { get; set; }




}
