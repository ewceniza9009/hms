using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RoomManagement.API.Data;
using RoomManagement.API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<RoomDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// This is a helper function to seed data
async Task SeedDatabase(WebApplication webApp)
{
    using var scope = webApp.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<RoomDbContext>();

    // Seed Room Types
    if (await dbContext.RoomTypes.CountDocumentsAsync(FilterDefinition<RoomType>.Empty) == 0)
    {
        var standardRoomType = new RoomType { Name = "Standard Queen", BasePrice = 5000, MaxOccupancy = 2, Description = "A comfortable room with a queen-sized bed." };
        var deluxeRoomType = new RoomType { Name = "Deluxe King", BasePrice = 7500, MaxOccupancy = 2, Description = "A spacious room with a king-sized bed and ocean view.", DefaultAmenities = new List<string> { "Mini-bar", "Wi-Fi", "HD TV" } };

        await dbContext.RoomTypes.InsertManyAsync(new[] { standardRoomType, deluxeRoomType });
        
        // Seed Rooms only after room types are created
        if (await dbContext.Rooms.CountDocumentsAsync(FilterDefinition<Room>.Empty) == 0)
        {
            var rooms = new List<Room>
            {
                new Room { RoomNumber = "101", Floor = 1, Status = "Available", RoomTypeId = standardRoomType.Id! },
                new Room { RoomNumber = "102", Floor = 1, Status = "Available", RoomTypeId = standardRoomType.Id! },
                new Room { RoomNumber = "201", Floor = 2, Status = "Available", RoomTypeId = deluxeRoomType.Id!, Features = new List<string> { "Sea View", "Balcony" } },
                new Room { RoomNumber = "202", Floor = 2, Status = "Cleaning", RoomTypeId = deluxeRoomType.Id!, Features = new List<string> { "Sea View", "Balcony" } }
            };
            await dbContext.Rooms.InsertManyAsync(rooms);
        }
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Run the data seeder on startup in development
    await SeedDatabase(app);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();