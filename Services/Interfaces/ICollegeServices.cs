using System;
using ClgManagementServer.Models;

namespace ClgManagementServer.Services.Interfaces;

public interface ICollegeServices
{

    Task CreateCollege(College college);
    Task<List<College>> GetCollegesData();

}
