using System;
using ClgManagementServer.Models;

namespace ClgManagementServer.Services.Interfaces;

public interface IDegreeServices
{

    Task CreateDegree(Degree degree);

}
