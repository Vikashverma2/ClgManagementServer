using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class CollegeServices : ICollegeServices
{

    public readonly IMongoCollection<College> _college;

    public CollegeServices(DbContext dbConnection)
    {
        _college = dbConnection.GetCollection<College>("Colleges");
    }

    public async Task CreateCollege(College college)
    {
        await _college.InsertOneAsync(college);
    }

    public async Task<List<College>> GetCollegesData()
    {
        var collegesData = await _college.Find(a => true).ToListAsync();
        return collegesData;

    }   


 



}
