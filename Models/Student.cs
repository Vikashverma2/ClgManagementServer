using System;
using System.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClgManagementServer.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string? Id { get; set; }
    public string Name { get; set; }
    public string Eamil { get; set; }
    public string Number { get; set; }
    public string Address { get; set; }
    public string CollegeId { get; set; }
    public string DegreeId { get; set; }
    public string BranchId { get; set; }
    public string StudentId { get; set; }
    public int Year { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;



    

}
