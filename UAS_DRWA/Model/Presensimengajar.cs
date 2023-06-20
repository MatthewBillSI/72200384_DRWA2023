using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Presensimengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    
    [BsonElement("Name")]
    public string NIP { get; set; } = null!;

    public decimal Tgl { get; set; }
    
    public string Kehardiran { get; set; } = null!;
    [Required]
    public string Kelas { get; set; } = null!;

 }