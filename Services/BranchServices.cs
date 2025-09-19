 using System;
using ClgManagementServer.DataBase;
using ClgManagementServer.Models;
using MongoDB.Driver;

namespace ClgManagementServer.Services;

public class BranchServices
{
    private readonly IMongoCollection<Branch> _branch;

    public BranchServices(DbContext dbContext)
    {
        _branch = dbContext.GetCollection<Branch>("Branch");
    }

    

    

}
