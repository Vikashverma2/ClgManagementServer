using System;
using ClgManagementServer.Models;

namespace ClgManagementServer.Services.Interfaces;

public interface IBranchCourse
{
    Task CreateBranch(Branch branch);
    Task<List<Branch>> GetBranchesData();


}
