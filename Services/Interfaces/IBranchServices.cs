using System;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;

namespace ClgManagementServer.Services.Interfaces;

public interface IBranchServices
{
    Task CreateBranch(Branch branch);
    Task<List<Branch>> GetBranchesData();
    Task<Branch?> GetBranchById(string id);
    Task<Branch> UpdateBranchAsync(string id, UpdateBranchRequest branchRequest);
    Task<bool> DeleteBranch(string branchId);


}
