using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Mapelname { get; set; } = null!;

    public decimal Kelas { get; set; }
    [Required]
    public string NIP { get; set; } = null!;

 }