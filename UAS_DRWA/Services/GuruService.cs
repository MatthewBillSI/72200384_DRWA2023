using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class GuruService
{
    private readonly IMongoCollection<Guru> _guruCollection;

    public GuruService(
        IOptions<UASDrwaDatabaseSettings> uasDrwaDatabaseSettings)
    {
 

        var mongoClient = new MongoClient(
            uasDrwaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            uasDrwaDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            uasDrwaDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _guruCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string id) =>
        await _guruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newGuru) =>
        await _guruCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string id, Guru updatedGuru) =>
        await _guruCollection.ReplaceOneAsync(x => x.Id == id, updatedGuru);

    public async Task RemoveAsync(string id) =>
        await _guruCollection.DeleteOneAsync(x => x.Id == id);
}