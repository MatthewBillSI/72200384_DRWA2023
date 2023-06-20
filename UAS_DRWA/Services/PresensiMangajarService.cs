using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<Presensimengajar> _presensimengajarCollection;

    public PresensiMengajarService(
        IOptions<UASDrwaDatabaseSettings> uasDrwaDatabaseSettings)
    {
 
               
        var mongoClient = new MongoClient(
            uasDrwaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            uasDrwaDatabaseSettings.Value.DatabaseName);

        _presensimengajarCollection = mongoDatabase.GetCollection<Presensimengajar>(
            uasDrwaDatabaseSettings.Value.PresensimengajarCollectionName);
    }

    public async Task<List<Presensimengajar>> GetAsync() =>
        await _presensimengajarCollection.Find(_ => true).ToListAsync();

    public async Task<Presensimengajar?> GetAsync(string id) =>
        await _presensimengajarCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Presensimengajar newPresensimengajar) =>
        await _presensimengajarCollection.InsertOneAsync(newPresensimengajar);

    public async Task UpdateAsync(string id, Presensimengajar updatedPresensimengajar) =>
        await _presensimengajarCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensimengajar);

    public async Task RemoveAsync(string id) =>
        await _presensimengajarCollection.DeleteOneAsync(x => x.Id == id);
}