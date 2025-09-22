using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class DegreeServices : IDegreeServices
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

    public async Task<List<Degree>> GetDegreeData()
    {
        var degreeData = await _degree.Find(a => true).ToListAsync();
        return degreeData;
    }

     public async Task<Degree?> GetDegreeById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return null;
        
        var filter = Builders<Degree>.Filter.Eq(d => d.Id, id);
        return await _degree.Find(filter).FirstOrDefaultAsync();
    }

}
