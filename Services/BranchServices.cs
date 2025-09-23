 using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using ClgManagementServer.Models.RequestModels;
using ClgManagementServer.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class BranchServices : IBranchServices
{
    private readonly IMongoCollection<Branch> _branch;

    public BranchServices(DbContext dbContext)
    {
        _branch = dbContext.GetCollection<Branch>("Branches");
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

    public async Task<Branch> UpdateBranchAsync(string id, UpdateBranchRequest branchRequest)
    {
        var existingBranch = await _branch.Find(a => a.Id == id).FirstOrDefaultAsync();

        if (existingBranch == null) return null;

        existingBranch.Name = branchRequest.Name;
        existingBranch.CourseId = branchRequest.CourseId;

        await _branch.ReplaceOneAsync(a => a.Id == id, existingBranch);
        return existingBranch;
    }

    public async Task<bool> DeleteBranch(string branchId)
    {
        await _branch.DeleteOneAsync(a => a.Id == branchId);
        return true;
    } 
    
    

    

}
