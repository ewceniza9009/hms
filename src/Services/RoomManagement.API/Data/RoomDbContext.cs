using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RoomManagement.API.Entities;

namespace RoomManagement.API.Data;

public class RoomDbContext
{
    private readonly IMongoCollection<Room> _roomsCollection;
    private readonly IMongoCollection<RoomType> _roomTypesCollection;

    public RoomDbContext(IOptions<MongoDbSettings> settings)
    {
        // Create a new MongoDB client using the connection string from our settings
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        // Get a reference to the database
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        // Get a reference to our specific collections (tables) within the database
        _roomsCollection = mongoDatabase.GetCollection<Room>(settings.Value.RoomsCollectionName);
        _roomTypesCollection = mongoDatabase.GetCollection<RoomType>(settings.Value.RoomTypesCollectionName);
    }

    // Public properties to allow other parts of our app to access the collections
    public IMongoCollection<Room> Rooms => _roomsCollection;
    public IMongoCollection<RoomType> RoomTypes => _roomTypesCollection;
}