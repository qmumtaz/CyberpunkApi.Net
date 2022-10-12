using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ClientApi.Services.DataModels;

public class Post
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [BsonElement("desc")]
    [JsonPropertyName("desc")]
    public string Description { get; set; }

    [BsonElement("photo")]
    [JsonPropertyName("photo")]
    public string Photo { get; set; }

    [BsonElement("username")]
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [BsonElement("categories")]
    [JsonPropertyName("categories")]
    public Categories[]? Categories { get; set; }

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
