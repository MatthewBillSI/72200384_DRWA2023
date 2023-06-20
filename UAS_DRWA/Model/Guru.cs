using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string GuruName { get; set; } = null!;

    public decimal Kelas { get; set; }

    public string NIP { get; set; } = null!;

 }