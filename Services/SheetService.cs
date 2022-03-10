
using cheat_sheat_creater_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace cheat_sheat_creater_api.Services;

public class SheetService
{
    private readonly IMongoCollection<Sheet> _sheetCollection;

    public SheetService(IOptions<DatabaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient( 
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase( 
            DatabaseSettings.Value.DatabaseName);

        _sheetCollection = mongoDatabase.GetCollection<Sheet>( 
            DatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Sheet>> GetAsync() =>
        await _sheetCollection.Find(_ => true).ToListAsync();
    public async Task<Sheet?> GetAsync(string url) =>
        await _sheetCollection.Find(data => data.url == url).FirstOrDefaultAsync();

    public async Task CreateAsync(Sheet inSheet) =>
        await _sheetCollection.InsertOneAsync(inSheet);
}