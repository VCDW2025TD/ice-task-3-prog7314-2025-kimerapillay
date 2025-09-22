using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Memes.Api.Models;

public class Meme
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("userId")]
    public string UserId { get; set; } = default!;

    [BsonElement("title")]
    public string Title { get; set; } = default!;

    // You can store either a URL or Base64; here we assume a remote URL
    [BsonElement("imageUrl")]
    public string ImageUrl { get; set; } = default!;

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
