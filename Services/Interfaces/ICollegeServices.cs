using System;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;

namespace ClgManagementServer.Services.Interfaces;

public interface ICollegeServices
{

    Task CreateCollege(College college);
    Task<List<College>> GetCollegesData();
    Task<College?> GetCollegeById(string id);
    Task<bool> DeleteCollege(string collegeId);
    Task<College> UpdateCollegeAsync(string id, UpdateCollegeRequest request);

}
