using System;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;

namespace ClgManagementServer.Services.Interfaces;

public interface IDegreeServices
{

    Task CreateDegree(Degree degree);
    Task<List<Degree>> GetDegreeData();
    Task<Degree?> GetDegreeById(string id);
    Task<Degree> UpdateDegree(string id, UpdateDegreeRequest updateDegreeRequest);
    Task<bool> DeleteDegree(string degreeId);

}
