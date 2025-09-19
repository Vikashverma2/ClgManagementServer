using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
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
        await _college. InsertOneAsync(college);
    }

    public async Task<List<College>> GetCollegesData()
    {
        var collegesData = await _college.Find(a => true).ToListAsync();
        return collegesData;

    }


    public async Task<College> UpdateCollegeAsync(string id, UpdateCollegeRequest request)
    {
        // 1. Try to find the existing college
        var existingCollege = await _college.Find(c => c.Id == id).FirstOrDefaultAsync();

        if (existingCollege == null) return null;

        existingCollege.Name = request.Name;
        existingCollege.Location = request.Location;
        existingCollege.EstablishedYear = request.EstablishedYear;
        existingCollege.ContactNumber = request.ContactNumber;
        existingCollege.Email = request.Email;

        // 3. Replace the old document with the new one
        await _college.ReplaceOneAsync(c => c.Id == id, existingCollege);

        // 4. Return updated object
        return existingCollege;


    }

    public async Task<bool> DeleteCollege(string collegeId)
    {
        await _college.DeleteOneAsync(a => a.Id == collegeId);
        return true;
    }





}
