using System;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;

namespace ClgManagementServer.Services.Interfaces;

public interface IStudentServices
{

    Task CreateStudent(Student student);
    Task<List<Student>> GetStudentData();
    Task<Student?> GetStudentById(string id);
    Task<Student> UpdateStudent(string id, StudentRequest studentRequest);
    Task<bool> DeleteStudent(string id);

    

}
