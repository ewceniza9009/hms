namespace RoomManagement.API.Data;

public class MongoDbSettings
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
    public required string RoomsCollectionName { get; set; }
    public required string RoomTypesCollectionName { get; set; }
}