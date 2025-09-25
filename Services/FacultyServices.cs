using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class FacultyServices : IFacultyServices
{
    private readonly IMongoCollection<Faculty> _faculty;
    public FacultyServices(DbContext dbContext)
    {
        _faculty = dbContext.GetCollection<Faculty>("Faculties");
    }

    public async Task CreateFaculty(Faculty faculty)
    {
        await _faculty.InsertOneAsync(faculty);
    }

    public async Task<List<Faculty>> GetFacultiesAsync(string id)
    {
        var getFaculites = await _faculty.Find(a => true).ToListAsync();
        return getFaculites;
    }

    public async Task<Faculty?> GetFacultyById(string id)
    {
        var faculty = await _faculty.Find(a => a.Id == id).FirstOrDefaultAsync();
        return faculty;

    }

    public async Task<Faculty> Updateafaculty(string id, FacultyRequest facultyRequest)
    {
        var existingFaculty = await _faculty.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (existingFaculty == null) return null;

        existingFaculty.FullName = facultyRequest.FullName;
        existingFaculty.Email = facultyRequest.Email;
        existingFaculty.Department = facultyRequest.Department;

        await _faculty.ReplaceOneAsync(a => a.Id == id, existingFaculty);
        return existingFaculty;
    }

    public async Task<bool> DeleteFaculty(string id)
    {
        await _faculty.DeleteOneAsync(d => d.Id == id);
        return true;

    }




}
