using System;
using System.Data.Common;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Services.Interfaces;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class StudentServices : IStudentServices
{
    private readonly IMongoCollection<Student> _student;

    public StudentServices(DbContext dbContext)
    {
        _student = dbContext.GetCollection<Student>("Students");
    }

    public async Task CreateStudent(Student student)
    {
        await _student.InsertOneAsync(student);
    }

    public async Task<List<Student>> GetStudentData()
    {
        var studentData = await _student.Find(a => true).ToListAsync();
        return studentData;
    }
    public async Task<Student?> GetStudentById(string id)
    {
        return await _student
            .Find(a => a.Id == id)
            .FirstOrDefaultAsync();
    }
    



}
