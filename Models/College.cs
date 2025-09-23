using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClgManagementServer.Models;

public class College
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int EstablishedYear { get; set; } 
    public string ContactNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    

}
