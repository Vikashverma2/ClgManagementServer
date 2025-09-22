using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClgManagementServer.Models;

public class Degree
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public int DurationYears { get; set; }
    public string CollegeId { get; set; }
    public List<string> BranchIds { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


}
