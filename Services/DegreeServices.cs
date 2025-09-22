using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class DegreeServices
{

    public readonly IMongoCollection<Degree> _degree;

    public DegreeServices(DbContext dbContext)
    {
        _degree = dbContext.GetCollection<Degree>("Degree");
    }

    public async Task CreateDegree(Degree degree)
    {
        await _degree.InsertOneAsync(degree);
    }

    

}
