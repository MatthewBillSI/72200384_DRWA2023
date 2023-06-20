using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class PresensiGuruService
{
    private readonly IMongoCollection<Presensiharianguru> _presensiguruCollection;

    public PresensiGuruService(
        IOptions<UASDrwaDatabaseSettings> uasDrwaDatabaseSettings)
    {
 
               
        var mongoClient = new MongoClient(
            uasDrwaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            uasDrwaDatabaseSettings.Value.DatabaseName);

        _presensiguruCollection = mongoDatabase.GetCollection<Presensiharianguru>(
            uasDrwaDatabaseSettings.Value.PresensiguruCollectionName);
    }

    public async Task<List<Presensiharianguru>> GetAsync() =>
        await _presensiguruCollection.Find(_ => true).ToListAsync();

    public async Task<Presensiharianguru?> GetAsync(string id) =>
        await _presensiguruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Presensiharianguru newPresensiharianguru) =>
        await _presensiguruCollection.InsertOneAsync(newPresensiharianguru);

    public async Task UpdateAsync(string id, Presensiharianguru updatedPresensiharianguru) =>
        await _presensiguruCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiharianguru);

    public async Task RemoveAsync(string id) =>
        await _presensiguruCollection.DeleteOneAsync(x => x.Id == id);
}