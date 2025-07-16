using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomManagement.API.Entities;

public class RoomType
{
    [BsonId] // Marks this property as the document's primary key (_id).
    [BsonRepresentation(BsonType.ObjectId)] // Represents it as a standard MongoDB ObjectId in the db, but a string in our C# code.
    public string? Id { get; set; }

    [BsonElement("name")] // Explicitly sets the field name in the MongoDB document.
    public required string Name { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("basePrice")]
    public decimal BasePrice { get; set; }

    [BsonElement("maxOccupancy")]
    public int MaxOccupancy { get; set; }

    [BsonElement("defaultAmenities")]
    public List<string> DefaultAmenities { get; set; } = new();
}