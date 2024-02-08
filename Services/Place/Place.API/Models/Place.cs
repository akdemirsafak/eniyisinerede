using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Place.API.Models;

public class Place
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string PhotoUrl { get; set; }
}
