using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class CollegeServices : ICollegeServices
{

    public readonly IMongoCollection<College> _college;

    public CollegeServices(DbConnection dbConnection)
    {
        _college = dbConnection.GetCollection<College>("Colleges");
    }

    public async Task CreateCollege(College college)
    {
        await _college.InsertOneAsync(college);
    }



 



}
