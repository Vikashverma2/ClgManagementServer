using System;

namespace ClgManagementServer.Models.RequestModels;

public class StudentRequest
{

    public string Name { get; set; } = string.Empty;
    public string Eamil { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string CollegeId { get; set; } = string.Empty;
    public string DegreeId { get; set; } = string.Empty;
    public string BranchId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public int Year { get; set; } = 1;


}
