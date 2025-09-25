using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
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

    public async Task



}
