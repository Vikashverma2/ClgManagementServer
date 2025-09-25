using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClgManagementServer.Models;

public class Faculty
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string Department { get; set; }  = string.Empty;
    public List<string> SubjectIds { get; set; } = new();

}
