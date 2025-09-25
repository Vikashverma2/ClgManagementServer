using System;
using ClgManagementServer.Models;

namespace ClgManagementServer.Services.Interfaces;

public interface IFacultyServices
{
    Task CreateFaculty(Faculty faculty);

}
