using System;

namespace ClgManagementServer.Models.RequestModels;

public class FacultyRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string Department { get; set; }  = string.Empty;

}
