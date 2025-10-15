using System;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;

namespace ClgManagementServer.Services.Interfaces;

public interface IFacultyServices
{
    Task CreateFaculty(Faculty faculty);
    Task<List<Faculty>> GetFacultiesAsync();
    Task<Faculty?> GetFacultyById(string id);
    Task<Faculty> Updateafaculty(string id, FacultyRequest facultyRequest);
    Task<bool> DeleteFaculty(string id);

}
