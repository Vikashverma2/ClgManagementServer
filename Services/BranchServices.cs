 using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class BranchServices
{
    private readonly IMongoCollection<Branch> _branch;

    public BranchServices(DbContext dbContext)
    {
        _branch = dbContext.GetCollection<Branch>("Branch");
    }
    public async Task CreateBranch(Branch branch)
    {
        await _branch.InsertOneAsync(branch);

    }

    public async Task<List<Branch>> GetBranchesData()
    {
        var branchData = await _branch.Find(a => true).ToListAsync();
        return branchData;
    }

    

    

}
