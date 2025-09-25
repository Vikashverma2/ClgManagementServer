using System;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<Student> UpdateStudent(string id, StudentRequest studentRequest)
    {
        var existingStudent = await _student.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (existingStudent == null) return null;

        existingStudent.Name = studentRequest.Name;
        existingStudent.Eamil = studentRequest.Eamil;
        existingStudent.Number = studentRequest.Number;
        existingStudent.Address = studentRequest.Address;
        existingStudent.CollegeId = studentRequest.CollegeId;
        existingStudent.DegreeId = studentRequest.DegreeId;
        existingStudent.BranchId = studentRequest.BranchId;
        existingStudent.StudentId = studentRequest.StudentId;
        existingStudent.Year = studentRequest.Year;

        await _student.ReplaceOneAsync(a => a.Id == id, existingStudent);
        return existingStudent;

    }

    public async Task<bool> DeleteStudent(string id)
    {
        await _student.DeleteOneAsync(a => a.Id == id);
        return true;
    }




}
