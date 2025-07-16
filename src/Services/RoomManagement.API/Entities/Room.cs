using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RoomManagement.API.Entities;

public class Room
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("roomNumber")]
    public required string RoomNumber { get; set; }

    [BsonElement("roomTypeId")]
    [BsonRepresentation(BsonType.ObjectId)] // This links to a document in the RoomTypes collection.
    public required string RoomTypeId { get; set; }

    [BsonElement("status")]
    public required string Status { get; set; } // e.g., "Available", "Occupied", "Cleaning"

    [BsonElement("floor")]
    public int Floor { get; set; }

    [BsonElement("features")]
    public List<string> Features { get; set; } = new();

    [BsonElement("lastCleanedAt")]
    public DateTime? LastCleanedAt { get; set; }
}