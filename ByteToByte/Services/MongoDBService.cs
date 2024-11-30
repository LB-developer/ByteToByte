using ByteToByte.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ByteToByte.Services;

public class MongoDbService
{
    private readonly IMongoCollection<ComparisonModel> _comparisonCollection;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _comparisonCollection = database.GetCollection<ComparisonModel>(mongoDbSettings.Value.CollectionName);
    }

    public async Task<List<ComparisonModel>> GetAsync()
    {
        var filter = Builders<ComparisonModel>.Filter.Eq("type", "Prints");
        return await _comparisonCollection.Find(filter).ToListAsync();
    }
    
}
