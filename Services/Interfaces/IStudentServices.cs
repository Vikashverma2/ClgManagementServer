using System;
using ClgManagementServer.Models;

namespace ClgManagementServer.Services.Interfaces;

public interface IStudentServices
{

    Task CreateStudent(Student student);
    Task<List<Student>> GetStudentData();
    Task<Student?> GetStudentById(string id);

}
