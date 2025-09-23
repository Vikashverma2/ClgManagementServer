using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
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

    public async Task<Degree> UpdateDegree(string id, UpdateDegreeRequest updateDegreeRequest)
    {
        var existingDegree = await _degree.Find(d => d.Id == id).FirstOrDefaultAsync();

        if (existingDegree == null) return null;

        existingDegree.Name = updateDegreeRequest.Name;
        existingDegree.DurationYears = updateDegreeRequest.DurationYears;
        existingDegree.CollegeId = updateDegreeRequest.CollegeId;

        await _degree.ReplaceOneAsync(d => d.Id == id, existingDegree);
        return existingDegree;


    }

    public async Task<bool> DeleteDegree(string degreeId)
    {
        await _degree.DeleteOneAsync(a => a.Id == degreeId);
        return true; 
    } 


}
