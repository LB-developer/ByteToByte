using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ByteToByte.Models;

public class ContentModel
{
   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
   public ObjectId Id { get; set; }
   
   [BsonElement("type"), BsonRepresentation(BsonType.String)]
   public required string Type { get; set; }
   [BsonElement("language"), BsonRepresentation(BsonType.String)]
   public required string Language { get; set; }
   [BsonElement("content"), BsonRepresentation(BsonType.String)]
   public required string Content { get; set; }
   [BsonElement("explanation"), BsonRepresentation(BsonType.String)]
   public string? Explanation { get; set; }
}

public class ComparisonModel
{
   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
   public ObjectId Id { get; set; }
   [BsonElement("type"), BsonRepresentation(BsonType.String)]
   public required string Type { get; set; }
   [BsonElement("snippets")]
   [JsonPropertyName("Snippets")]
   public required List<ContentModel> Snippets { get; set; } = null!;
}
