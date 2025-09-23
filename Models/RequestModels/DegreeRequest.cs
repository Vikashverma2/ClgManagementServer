using System;

namespace ClgManagementServer.Models.RequestModels;

public class UpdateDegreeRequest
{
    public string Name { get; set; } = string.Empty;
    public int DurationYears { get; set; }
    public string CollegeId { get; set; } = string.Empty;

}
