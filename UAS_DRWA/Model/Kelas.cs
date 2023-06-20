using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA.Models;

public class Kelas
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    [BsonElement("Name")]
    public string Nama { get; set; } = null!;
 
 }