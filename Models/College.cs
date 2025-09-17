using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClgManagementServer.Models;

public class College
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String? Id { get; set; }
    public String Name { get; set; }
    public String location { get; set; }
    public int EstablishedYear { get; set; }
    public int ContactNumber { get; set; }
    
    

}
